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
[CustomPropertyDrawer(typeof(ActionBase), true)]
public class ActionDrawer : PropertyDrawer
{

    private int propertyFieldHeight;

    // Рассчитать высоту
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        var data = property.objectReferenceValue as ActionBase;




        if (data == null) return 1;

        // Скрытие 
        if (data.HideProperties == true)
            return base.GetPropertyHeight(property, label) + 10;


        SerializedObject serializedObject = new SerializedObject(data); // вызывает ошибку

        if (serializedObject == null) return 1;

        SerializedProperty prop = serializedObject.GetIterator();

        // Get heigth
        propertyFieldHeight = 0;

        // Оформить в метод
        if (prop.NextVisible(true))
        {
            do
            {
                if (prop.name == "m_Script") continue;
                if (prop.name == "owner") continue;


                if (prop.name == "gameObject")
                {
                    if (data.Owner == ActionOwner.Specified)
                    {
                        Debug.Log("sdfs");
                        propertyFieldHeight += 20;
                      
                    }
                    continue;


                }

                if (prop.name == "condition")
                {
                    bool isActive = prop.FindPropertyRelative("isActive").boolValue;

                    if (isActive == true)
                    {
                        propertyFieldHeight += 50;
                       
                    }
                    continue;


                }
                

                 propertyFieldHeight += 20;
                

            } while (prop.NextVisible(false));
        }


        return base.GetPropertyHeight(property, label) + propertyFieldHeight + 10;

    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {


        var data = property.objectReferenceValue as ActionBase;


        if (data == null) return;


        SerializedObject serializedObject = new SerializedObject(data);
        SerializedProperty prop = serializedObject.GetIterator();



        Rect enumRect = new Rect();
        if (data.HideProperties == true)
        {

            EditorGUI.LabelField(position, data.GetHideString());
        }
        else
        {
            // Получаем область для отображение элемената
            Rect rect = position;
            rect.height = 15;

            // Коррекция области для отображение всего
            //rect.x += 15;
            //rect.width -= 30;

            // Нужно нарисовать 2 бокса разных цветов
            GUI.backgroundColor = Color.white;
            Rect boxRect = new Rect(position.x, position.y, position.width, position.height);

            GUI.Box(boxRect, GUIContent.none);

            EditorGUI.LabelField(rect, new GUIContent(data.GetType().Name.Replace("Action", "")), EditorStyles.boldLabel);
        

            
            float w = rect.width;
            rect.x += 280;
            rect.width = 100;

            enumRect = new Rect(rect.position, rect.size);


            rect.x -= 280;
            rect.width = w;

            // EditorGUI.PropertyField(rect, property.FindPropertyRelative("onwer")); 



            // Horizontal line
            // Мигает
            //Rect rectLine = new Rect(position.x - 4, position.y + 20, position.width + 8, 1);
            //EditorGUI.DrawRect(rectLine, Color.black);


            EditorGUI.indentLevel = 0;
            rect.y += 30;

            // Оформить по нормальному
            if (prop.NextVisible(true))
            {
                do
                {
                    if (prop.name == "m_Script") continue;

                 
                    if(prop.name == "gameObject")
                    {

                        if (data.Owner == ActionOwner.Specified)
                        {
                            EditorGUI.PropertyField(rect, prop);
                            rect.y += 20;
                        }

                        continue;



                    }

                    if (prop.name == "condition")
                    {
                        bool isActive = prop.FindPropertyRelative("isActive").boolValue;

                        if (isActive == true)
                        {
                            EditorGUI.PropertyField(rect, prop);
                            rect.y += 45;
        
                        }

                        continue;

                    }
                 
                 
                    if (prop.name == "owner")
                    {
                           
                        EditorGUI.PropertyField(enumRect, prop,  GUIContent.none);
                        continue;
                    }
                     
                      

                    EditorGUI.PropertyField(rect, prop);
                    rect.y += 20;
                        
                  






                } while (prop.NextVisible(false));
            }

            serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = 0;
        }




    }








}