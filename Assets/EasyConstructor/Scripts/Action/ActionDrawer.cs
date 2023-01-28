using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(ActionBase), true)]
public class ActionDrawer : PropertyDrawer
{
    private const float headerHeight = 15.0f;
    private const float shortHeight = 0.0f;
    private const float shortTab = 0.0f;
    private const float verticalFieldSpace = 3.0f;
    private const float HeaderButtonsWidth = 40.0f;
    private const float generalSettingFieldWidth = 30.0f;
    private const float generalSettingLabeWidth = 40.0f;
    private const float ownerEnumWidth = 65.0f;

    private Color headerBackgroundColor = new Color(0.73f, 0.73f, 0.73f);


    // Рассчитать высоту
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float height = 0;

        var action = property.objectReferenceValue as ActionBase;

        if (action == null) return height;

        if (action.HideProperties == true)
            return headerHeight + shortHeight;

 

        SerializedProperty[] visibleProperties = GetVisibleSerializedProperties(action);

        for (int i = 0; i < visibleProperties.Length; i++)
        {
            height += EditorGUI.GetPropertyHeight(visibleProperties[i]) + verticalFieldSpace;
        }

        return height + headerHeight + verticalFieldSpace;

    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.Box(position, GUIContent.none);

        var action = property.objectReferenceValue as ActionBase;

        if (action == null) return;

        // Calc rect 
        Rect headerRect = new Rect(position.x, position.y, position.width, headerHeight);

        // Draw header box
        Color prevColor = GUI.backgroundColor;
        GUI.backgroundColor = headerBackgroundColor;
        GUI.Box(headerRect, GUIContent.none);
        GUI.backgroundColor = prevColor;

        // Draw title action
        EditorGUI.LabelField(headerRect, new GUIContent(action.GetType().Name.Replace("Action", "")), EditorStyles.boldLabel);

        // Draw remove buttons
        Rect buttonRect = new Rect(position.x + position.width - HeaderButtonsWidth, position.y, HeaderButtonsWidth, headerHeight);
        if(GUI.Button(buttonRect, new GUIContent("✖")))
        {
            action.ToRemove = true;
        }

        // Draw hide buttons
        buttonRect.x -= HeaderButtonsWidth;
        if(GUI.Button(buttonRect, new GUIContent("▼")))
        {
            action.HideProperties = !action.HideProperties;
        }

        // Draw condition buttons
        buttonRect.x -= HeaderButtonsWidth;
        if(GUI.Button(buttonRect, new GUIContent("?")))
        {

            if(action.HideProperties == false)
            {
                action.Condition.ToggleActive();
            }
           
        }

        // Draw owner enums
        buttonRect.x -= ownerEnumWidth;
        buttonRect.width = ownerEnumWidth;
        action.Owner = (ActionOwner)EditorGUI.EnumPopup(buttonRect, action.Owner);

        // Draw loop field
        /*
        buttonRect.x -= generalSettingFieldWidth;
        buttonRect.width = generalSettingFieldWidth;
        action.Loop = EditorGUI.IntField(buttonRect, action.Loop);

        buttonRect.x -= generalSettingLabeWidth;
        buttonRect.width = generalSettingLabeWidth;
        EditorGUI.LabelField(buttonRect, new GUIContent("Loop:"));

        // Draw delay field
        buttonRect.x -= generalSettingFieldWidth;
        buttonRect.width = generalSettingFieldWidth;
        action.Delay = EditorGUI.FloatField(buttonRect, action.Delay);

        buttonRect.x -= generalSettingLabeWidth;
        buttonRect.width = generalSettingLabeWidth;
        EditorGUI.LabelField(buttonRect, new GUIContent("Delay:"));
        */


        position.y += headerHeight;


        // Draw short description 
        if (action.HideProperties == true)
        {
            position.height = shortHeight;
            position.x += shortTab;
            EditorGUI.LabelField(position, new GUIContent(action.GetShortDescription()));
            return;
        }

        // Draw action fields
        position.y += verticalFieldSpace;
        SerializedProperty[] visibleProperties = GetVisibleSerializedProperties(action);
       
        for (int i = 0; i < visibleProperties.Length; i++)
        {
            position.height = EditorGUI.GetPropertyHeight(visibleProperties[i]);

            EditorGUI.PropertyField(position, visibleProperties[i]);

            visibleProperties[i].serializedObject.ApplyModifiedProperties();

            position.y += position.height + verticalFieldSpace;
        }
    }

    public SerializedProperty[] GetVisibleSerializedProperties(ActionBase action)
    {
        List<SerializedProperty> allProperties = new List<SerializedProperty>();

        // вызывает ошибку
        SerializedObject serializedObject = new SerializedObject(action); 

        if (serializedObject == null) return null;

        SerializedProperty property = serializedObject.GetIterator();

        if (property.NextVisible(true))
        {
            do
            {
                if (property.name == "m_Script") continue;
                if (property.name == "owner") continue;

                if (property.name == "gameObject")
                {
                    if (action.Owner == ActionOwner.Specific) allProperties.Add(property.Copy());

                    continue;
                }

                if (property.name == "condition")
                {
                    // Вероятно стоит другое условие
                    if (property.FindPropertyRelative("isActive").boolValue == true) allProperties.Add(property.Copy());

                    continue;
                }

                allProperties.Add(property.Copy());

            } while (property.NextVisible(false));
        }

        return allProperties.ToArray();
    }








}