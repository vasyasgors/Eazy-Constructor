using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

// Добавить бокс по контору
// Добавить проверку на возможность сравнения (Сбрасивается условие)
// добавить тип к имени 
// Добавить авто подттягивание свойства если перекидываешь скриптбл обджект с переменными
// Отображение параметров игрового объекта
// Если убираешь, то все должно обнуляться 
// Массив 
// при добавлении объекта имя значение проподает 
// Добавить отдельное отображенеие свойств гейм объекта
// Автоматом должно подхватывать значение, если это переменная

[CustomPropertyDrawer(typeof(Condition))]
public class ConditionDrawer : PropertyDrawer
{
    // TODO: rename
    private Color EmptyBackgroundColor = new Color(0.5f, 0.5f, 0.5f);
    private Color CorrectBackgroundColor = new Color(0.0f, 0.5f, 0.0f);
    private Color ErrorBackgroundColor = new Color(0.5f, 0.0f, 0.0f);

    private string operationTextLabel = "(Operation)";
    private string firstVariableLabel = "(Value)";
    private string secondVariableLabel = "(Value)";

    private Object firstObject;
    private Object secondObject;

    private SerializedProperty firstObjectProperty;
    private SerializedProperty secondObjectProperty;
    private SerializedProperty firstVariableNameProperty;
    private SerializedProperty secondVariableNameProperty;
    private SerializedProperty operationProperty;


    private Condition target;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 20;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.y += 2;
       // GUI.Box(position, GUIContent.none);

        //target = fieldInfo.GetValue(property.serializedObject.targetObject) as Condition;

        EditorGUI.BeginProperty(position, label, property);

        // Чуть уменьшаем отображение
        position.width -= 10;
        position.x += 5;


        //  Calc Rects
        var firstObjectRect = new Rect(position.x, position.y, position.width / 2, 15);
        var secondObjectRect = new Rect(position.x + position.width / 2, position.y, position.width / 2, 15);
		var firstVariableRect = new Rect(position.x, position.y + 17, position.width * 0.4f, 15);
		var conditionRect = new Rect(firstVariableRect.x + firstVariableRect.width, position.y + 17, position.width * 0.2f, 15);
		var secondVariableRect = new Rect(conditionRect.x + conditionRect.width, position.y + 17, position.width * 0.4f, 15);


        // Get Property
        firstObjectProperty = property.FindPropertyRelative("firstObject");
        secondObjectProperty = property.FindPropertyRelative("secondObject");

        firstVariableNameProperty = property.FindPropertyRelative("firstVariableName");
        secondVariableNameProperty = property.FindPropertyRelative("secondVariableName");

        operationProperty = property.FindPropertyRelative("operationString");

        // Get property мalue
        firstObject = firstObjectProperty.objectReferenceValue;
        secondObject = secondObjectProperty.objectReferenceValue;

        
        firstVariableLabel = firstVariableNameProperty.stringValue;
        secondVariableLabel = secondVariableNameProperty.stringValue;

        operationTextLabel = operationProperty.stringValue;

        // Reset
        if (firstObject == null)
            firstVariableLabel = "none";

        if (secondObject == null)
            secondVariableLabel = "none";

        if (firstObject == null || secondObject == null)
            operationTextLabel = "none";

        // Draw box
        //var boxRect = new Rect(position.x - 2, position.y - 3, position.width + 4, 40);
        Color c = GUI.backgroundColor;

        // Get background color
        /*
        if (firstObject == null || secondObject == null || firstVariableNameProperty.stringValue == "" 
            || secondVariableNameProperty.stringValue == "" || operationProperty.stringValue == "") GUI.backgroundColor = EmptyBackgroundColor;
        else if (target.IsCorrect() == true) GUI.backgroundColor = CorrectBackgroundColor;
        else if(target.IsCorrect() == false) GUI.backgroundColor = ErrorBackgroundColor;*/

       // GUI.Box(boxRect, GUIContent.none);
        GUI.Box(position, GUIContent.none);
        GUI.backgroundColor = c;

        // Draw fields
        firstObject = EditorGUI.ObjectField(firstObjectRect, GUIContent.none, firstObject, typeof(Object), true);
        secondObject = EditorGUI.ObjectField(secondObjectRect, GUIContent.none, secondObject, typeof(Object), true);

        if (EditorGUI.DropdownButton(firstVariableRect,  new GUIContent(firstVariableLabel), FocusType.Passive) == true)
        {
            if (firstObject != null)
            {
                GetVariableMenu(firstObject, true).DropDown(firstVariableRect);
            }
        }

        if (EditorGUI.DropdownButton(conditionRect, new GUIContent(operationTextLabel), FocusType.Passive) == true)
        {
            GetConditionMenu().DropDown(conditionRect);
        }


        if (EditorGUI.DropdownButton(secondVariableRect, new GUIContent(secondVariableLabel), FocusType.Passive) == true)
        {
            if (secondObject != null)
            {
                GetVariableMenu(secondObject, false).DropDown(secondVariableRect);
            }
        }

        // Apply Object
        firstObjectProperty.objectReferenceValue = firstObject;
        firstObjectProperty.serializedObject.ApplyModifiedProperties();

        secondObjectProperty.objectReferenceValue = secondObject;
        secondObjectProperty.serializedObject.ApplyModifiedProperties();



        EditorGUI.EndProperty();
    }

    private GenericMenu GetConditionMenu()
    { 
        GenericMenu menu = new GenericMenu();

        // Сделать с помощью метода
        menu.AddItem(new GUIContent("=="), false, UpdateCondition, "==");
        menu.AddItem(new GUIContent("<"), false, UpdateCondition, "<");
        menu.AddItem(new GUIContent(">"), false, UpdateCondition, ">");
        menu.AddItem(new GUIContent("<="), false, UpdateCondition, "<=");
        menu.AddItem(new GUIContent(">="), false, UpdateCondition, ">=");
        menu.AddItem(new GUIContent("!="), false, UpdateCondition, "!=");


        return menu;
    }

    private void UpdateCondition(object data)
    {
        operationProperty.stringValue = data.ToString();
        operationProperty.serializedObject.ApplyModifiedProperties();

        operationTextLabel = data.ToString();
    }

    private void UpdateFirstVariable(object data)
    {
        ConditionOperand operand = data as ConditionOperand;

        firstObjectProperty.objectReferenceValue = operand.SourceObject;
        firstObjectProperty.serializedObject.ApplyModifiedProperties();

        firstVariableNameProperty.stringValue = operand.PropertyName;
        firstVariableNameProperty.serializedObject.ApplyModifiedProperties();

        firstVariableLabel = operand.PropertyName + " Тип";     
    }

    private void UpdateSecondVariable(object data)
    {
        ConditionOperand operand = data as ConditionOperand;

        secondObjectProperty.objectReferenceValue = operand.SourceObject;
        secondObjectProperty.serializedObject.ApplyModifiedProperties();

        secondVariableNameProperty.stringValue = operand.PropertyName;
        secondVariableNameProperty.serializedObject.ApplyModifiedProperties();

        secondVariableLabel = operand.PropertyName + " Тип";
    }

    

  

    // фильтрация свойств
    private GenericMenu GetVariableMenu(Object target, bool isFirstObject)
    {
        // Не искать скрыте компоненты
      //  Debug.Log(target);

        GenericMenu menu = new GenericMenu();

        if (target is Component)
            target = (target as Component).gameObject;

        if (target is GameObject)
        {
 
            Component[] allComponents = (target as GameObject).GetComponents<Component>();

            Debug.Log(allComponents.Length);

            for (int i = 0; i < allComponents.Length; i++)
            {
                Type componentType = allComponents[i].GetType();

                if (allComponents[i].hideFlags == HideFlags.HideInInspector) continue;
                

                var wantedProperties = componentType.GetProperties();

                for (int j = 0; j < wantedProperties.Length; j++)
                {

                    if(isFirstObject == true)
                        menu.AddItem(new GUIContent(allComponents[i].GetType().Name + "/" + wantedProperties[j].Name), false, UpdateFirstVariable,
                            new ConditionOperand(allComponents[i], wantedProperties[j].Name) );

                    if (isFirstObject == false)
                        menu.AddItem(new GUIContent(allComponents[i].GetType().Name + "/" + wantedProperties[j].Name), false, UpdateSecondVariable, 
                            new ConditionOperand(allComponents[i], wantedProperties[j].Name));
                }


            }
        }

        
        if (target is ScriptableObject)
        {
            Type componentType = target.GetType();

            var wantedProperties = componentType.GetFields();

            for (int j = 0; j < wantedProperties.Length; j++)
            {
                if (isFirstObject == true)
                    menu.AddItem(new GUIContent(wantedProperties[j].Name), false, UpdateFirstVariable, new ConditionOperand(target, wantedProperties[j].Name));

                if (isFirstObject == false)
                    menu.AddItem(new GUIContent(wantedProperties[j].Name), false, UpdateSecondVariable, new ConditionOperand(target, wantedProperties[j].Name));
            }
        }

        

        return menu;
    }
}
