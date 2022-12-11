using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

[CustomPropertyDrawer(typeof(EventHandler), true)]
public class EventHandlerDrawer : PropertyDrawer
{

    private int propertyFieldHeight;

    EventHandler eventHandler;

    // Рассчитать высоту
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {

        /*
        var data = property.objectReferenceValue as EventHandler;
        SerializedObject serializedObject = new SerializedObject(data);

        SerializedProperty prop = serializedObject.GetIterator();

        // Get heigth
        propertyFieldHeight = 0;

        if (prop.NextVisible(true))
        {
            do
            {
                Debug.Log(prop);

                if (prop.name == "m_Script") continue;

                propertyFieldHeight += 20;
                

            } while (prop.NextVisible(false));
        }


        return base.GetPropertyHeight(property, label) + propertyFieldHeight + 10;
        */
        return base.GetPropertyHeight(property, label);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        /*
        var data = property.objectReferenceValue as EventHandler;




        SerializedObject serializedObject = new SerializedObject(data);
        SerializedProperty prop = serializedObject.GetIterator();


        // Нужно нарисовать 2 бокса разных цветов
        GUI.backgroundColor = Color.white;
        Rect boxRect = new Rect(position.x - 4, position.y, position.width + 8, position.height);

        GUI.Box(boxRect, GUIContent.none);

        Rect rect = position;
        rect.height = 15;

        EditorGUI.LabelField(rect, new GUIContent(data.GetType().Name.Replace("Action", "")), EditorStyles.boldLabel);

        // Horizontal line
        Rect rectLine = new Rect(position.x - 4, position.y + 20, position.width + 8, 1);
        EditorGUI.DrawRect(rectLine, Color.black);



        rect.y += 30;

        if (prop.NextVisible(true))
        {
            do
            {
                Debug.Log(prop);

                if (prop.name == "m_Script") continue;

                EditorGUI.PropertyField(rect, prop);
                rect.y += 20;


            } while (prop.NextVisible(false));
        }

        serializedObject.ApplyModifiedProperties();
        */
    }





    private void AddAction(object name)
    {

        if(name.ToString() == "Destory Object")
            eventHandler.AddAction<DestoryAction>();

        if (name.ToString() == "Spawn Object")
            eventHandler.AddAction<SpawnAction>();

        if (name.ToString() == "Load Level")
            eventHandler.AddAction<LoadLevelAction>();

    

    }


    private GenericMenu BuildAddActionMenu()
    {
        GenericMenu menu = new GenericMenu();

        menu.AddItem(new GUIContent("Destory Object"), false, AddAction, "Destory Object");
        menu.AddItem(new GUIContent("Spawn Object"), false, AddAction, "Spawn Object");
        menu.AddItem(new GUIContent("Load Level"), false, AddAction, "Load Level");


        return menu;

    }

}
