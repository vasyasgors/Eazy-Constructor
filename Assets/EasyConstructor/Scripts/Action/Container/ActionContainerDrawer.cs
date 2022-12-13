using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;
using System.Linq;

[CustomPropertyDrawer(typeof(ActionContainer), true)]
public class ActionContainerDrawer : PropertyDrawer
{

    private const float ActionVerticalOffset = 5;

    private ActionContainer container;

    GameObject gameObject;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + GetFieldActionsHeight(property.FindPropertyRelative("actions"));
      
    }


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // возможно будут траблы и нужно иначе
        container = fieldInfo.GetValue(property.serializedObject.targetObject) as ActionContainer; //  property.serializedObject.targetObject - игровой объект, и в нем находим полем

        gameObject = (property.serializedObject.targetObject as EventHandler).gameObject;

      
        EditorGUI.BeginProperty(position, label, property);

        GUI.Box(position, GUIContent.none);


        // Draw property name
        /*
        Rect nameRect = position;
        nameRect.height = 15;
        EditorGUI.LabelField(nameRect, new GUIContent(property.name), EditorStyles.label);
        */


       // position.y += 15;


        Rect curActionRect = position;

        for(int i = 0; i < property.FindPropertyRelative("actions").arraySize; i++)
        {

            SerializedProperty currentAction = property.FindPropertyRelative("actions").GetArrayElementAtIndex(i);

            curActionRect.height = EditorGUI.GetPropertyHeight(currentAction);

            EditorGUI.PropertyField(curActionRect, currentAction);

            EditorUtility.SetDirty(currentAction.objectReferenceValue);

            // Draw remove Button
            Rect removeButtonRect = curActionRect;
            removeButtonRect.y += 3;
            removeButtonRect.x = position.width - 70;
            removeButtonRect.width = 80;
            removeButtonRect.height = 15;

            if (GUI.Button(removeButtonRect, "Remove"))
            {
                container.RemoveAction(currentAction.objectReferenceValue as ActionBase);
            }

            // Draw  toogle condition
            removeButtonRect = curActionRect;
            removeButtonRect.y += 3;
            removeButtonRect.x = removeButtonRect.width - 70 - 85;
            removeButtonRect.width = 80;
            removeButtonRect.height = 15;

            if (GUI.Button(removeButtonRect, "Condition"))
            {
                container.ToogleActiveCondition(currentAction.objectReferenceValue as ActionBase);
            }


            curActionRect.y += curActionRect.height + ActionVerticalOffset;
        }


        curActionRect.height = 15;



        if (EditorGUI.DropdownButton(curActionRect, new GUIContent("Add Action"), FocusType.Passive))
        {
            BuildAddActionMenu().DropDown(curActionRect);

        }

        EditorGUI.EndProperty();

    }


    private float GetFieldActionsHeight(SerializedProperty actions)
    {
        float height = 0;

        for (int i = 0; i < actions.arraySize; i++)
        {
            SerializedProperty currentAction = actions.GetArrayElementAtIndex(i);

            height += EditorGUI.GetPropertyHeight(currentAction) + ActionVerticalOffset;
        }

        return height;
    }




    private void AddAction(object name)
    {

 
        if (name.ToString() == "Destory Object")
            container.AddAction<DestoryAction>(gameObject);

        if (name.ToString() == "Spawn Object")
            container.AddAction<SpawnAction>(gameObject);

        if (name.ToString() == "Load Level")
            container.AddAction<LoadLevelAction>(gameObject);

        if (name.ToString() == "Rotate")
            container.AddAction<Rotate>(gameObject);

        if (name.ToString() == "Move")
            container.AddAction<Move>(gameObject);

         if (name.ToString() == "Move To") container.AddAction<MoveTo>(gameObject);
         if (name.ToString() == "Move To Random Area") container.AddAction<MoveToRandomArea>(gameObject);




    }


    private GenericMenu BuildAddActionMenu()
    {
        GenericMenu menu = new GenericMenu();

        menu.AddItem(new GUIContent("Destory Object"), false, AddAction, "Destory Object");
        menu.AddItem(new GUIContent("Spawn Object"), false, AddAction, "Spawn Object");
        menu.AddItem(new GUIContent("Load Level"), false, AddAction, "Load Level");
        menu.AddItem(new GUIContent("Rotate"), false, AddAction, "Rotate");
        menu.AddItem(new GUIContent("Move"), false, AddAction, "Move");
        menu.AddItem(new GUIContent("Move To"), false, AddAction, "Move To");
        menu.AddItem(new GUIContent("Move To Random Area"), false, AddAction, "Move To Random Area");


        return menu;

    }

}
