using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;




// Добавить бокс
// Переключение отображение условия должно быть тут, ВОЗМОЖНо
// Отрефакторить

    /*
[CustomPropertyDrawer(typeof(ActionWrapper), true)]
public class ActionWeapperDrawer : PropertyDrawer
{
    private int fieldHeigth = 15;

    private string ConditionString = "condition";
    private string SerializationString = "serializationString";
    private string ActionType = "actionType";


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int fieldAmount =   GetAction(property).GetType().GetFields().Length;

        return base.GetPropertyHeight(property, label) + fieldHeigth * fieldAmount + 50; // Condition + 50
      
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        position.height = 50;

        EditorGUI.PropertyField(position, property.FindPropertyRelative(ConditionString));

        position.y += 50;

        ActionBase action = GetAction(property);

      

        // надо брать такие же филды как и в юнити
        FieldInfo[] allField = action.GetType().GetFields();

        for (int i = 0; i < allField.Length; i++)
        {
            position.height = 15;

            object val = DrawFieldByFieldInfo(position, allField[i], allField[i].GetValue(action), action);

            if(val != null)
                allField[i].SetValue(action, val);

            position.y += 20;
        }


        string serialize = ActionWrapper.SerializeAction(action);
        property.FindPropertyRelative(SerializationString).stringValue = serialize;
        property.serializedObject.ApplyModifiedProperties();
    }


    private ActionBase GetAction(SerializedProperty property)
    {
        return ActionWrapper.DeserializeAction(property.FindPropertyRelative(SerializationString).stringValue, property.FindPropertyRelative(ActionType).stringValue);
    }

    // Убрать в статик и другого класса (возможно расширения)
    private object DrawFieldByFieldInfo(Rect position, FieldInfo fieldInfo, object value, ActionBase action)
    {
        // My Property
        if (fieldInfo.FieldType.IsSubclassOf(typeof(PropertyBase)) == true) return DrawPropertyByFieldInfo(position, fieldInfo, value as PropertyBase, action);

        // UnityObject
        if (fieldInfo.FieldType.IsSubclassOf(typeof(Object))) return EditorGUI.ObjectField(position, new GUIContent(fieldInfo.Name), value as Object, fieldInfo.FieldType, true);

        // Primitive and struct
        return PrimitiveTypeField(position, new GUIContent(fieldInfo.Name), value);
    }

    // В класс расширения
    private object PrimitiveTypeField(Rect position, GUIContent lable, object value)
    {
        // возможно костыль
       // if (value == null)
         //   value = new object();

        // Add to all unity struct 
        if (value.GetType() == typeof(int)) return EditorGUI.IntField(position, lable, (int) value);
        if (value.GetType() == typeof(float)) return EditorGUI.FloatField(position, lable, (float) value);
        if (value.GetType() == typeof(bool)) return EditorGUI.Toggle(position, lable, (bool) value);
        if (value.GetType() == typeof(string)) return EditorGUI.TextField(position, lable, (string) value);
        if (value.GetType() == typeof(Vector2)) return EditorGUI.Vector2Field(position, lable, (Vector2) value);
        if (value.GetType() == typeof(Vector3)) return EditorGUI.Vector3Field(position, lable, (Vector3) value);

        if (value.GetType().IsEnum == true) return EditorGUI.EnumPopup(position, lable, (Enum) Enum.Parse(value.GetType(), value.ToString()) );

        return null;
    }




    // В отдельный класс
    private object DrawPropertyByFieldInfo(Rect position, FieldInfo fieldInfo, PropertyBase property, ActionBase action)
    {
        FieldInfo modeField = property.GetType().GetField("mode");
        FieldInfo valueField = property.GetType().BaseType.GetField("value", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo variableField = property.GetType().BaseType.GetField("variable", BindingFlags.NonPublic | BindingFlags.Instance);


        PropertyMode mode = (PropertyMode) modeField.GetValue(property);

      
        position.width -= 40;
        if (mode == PropertyMode.Value)
        {

            object val = PrimitiveTypeField(position, new GUIContent(fieldInfo.Name), valueField.GetValue(property));

            valueField.SetValue(property, val);
        }


        if (mode == PropertyMode.Variable)
        {

            // Сделать отображение так, чтобы была ссылка и на переменную и отображалась значение переменной
            Variable fvar = (Variable) variableField.GetValue(property);


            // fvar = (Variable) EditorGUI.ObjectField(position, new GUIContent(fieldInfo.Name), fvar, variableField.FieldType, false);

            //variableField.SetValue(property, fvar);\
           // Debug.Log(action.variableContainer.intVariables.Count);
            //variableField.SetValue(property, action.logic.WrapperVariables[0].Value);




        }



  
        position.x += position.width;
        position.width = 40;


        if (GUI.Button(position, "↕"))
        {

           if (mode == PropertyMode.Value)
                modeField.SetValue(property,PropertyMode.Variable);

            if (mode == PropertyMode.Variable)
            {
                modeField.SetValue(property, PropertyMode.Value);

                // Обнуляем переменную чтобы бралось значение из установленного в эдиторе
                // Обнулять не удобно
                // property.FindPropertyRelative("variable").objectReferenceValue = null;

                //property.serializedObject.ApplyModifiedProperties();
            }
        }

        
        return property;
    }







}
*/