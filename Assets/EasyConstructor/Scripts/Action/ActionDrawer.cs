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
//[CustomPropertyDrawer(typeof(ActionBase), true)]
public class ActionDrawer : PropertyDrawer
{

    private int propertyFieldHeight = 15;

    // Рассчитать высоту
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        int amountParametrs = property.FindPropertyRelative("paramAm").intValue;

        return base.GetPropertyHeight(property, label) + 4 * propertyFieldHeight;
      
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        Debug.Log(property.FindPropertyRelative("type"));

        int amountParametrs = 4;// property.FindPropertyRelative("ParametrAmount").intValue;




    
        if (amountParametrs > 0)
        {
            position.height = propertyFieldHeight;

            SerializedProperty[] allParametrs = GetAllParametr(property, amountParametrs);



            for (int i = 0; i < allParametrs.Length; i++)
            {
             //   EditorGUI.PropertyField(position, allParametrs[i], new GUIContent("ПАРАМЕТР"));



                position.y += propertyFieldHeight;
            }
        }

        property.serializedObject.ApplyModifiedProperties();



    }

    
    public SerializedProperty[] GetAllParametr(SerializedProperty property, int amount)
    {
        SerializedProperty[] allParametrs = new SerializedProperty[amount];



        if(amount >= 1) allParametrs[0] = property.FindPropertyRelative("parametr1");
        if(amount >= 2) allParametrs[1] = property.FindPropertyRelative("parametr2");
        if(amount >= 3) allParametrs[2] = property.FindPropertyRelative("parametr3");
        if(amount >= 4) allParametrs[3] = property.FindPropertyRelative("parametr4");



        return allParametrs;
    }

    





}
