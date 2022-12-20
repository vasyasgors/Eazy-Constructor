using System.Collections;
using UnityEngine;
using UnityEditor;

using System;

using Object = UnityEngine.Object;
using System.Reflection;



public enum EventGroups
{
    Create,
    Destroy,
    EveryFrame,
    Mouse,
    Keyboard,
    Collision,
    Trigger,
    Other
}


public enum MouseEventProperties
{
    Left,
    Middle,
    Right
}



public enum MouseEventType
{
    Down,
    Up,
    Pressed,
    ObjectEnter,
    ObjectLeave,
    ObjectDown,
    ObjectClick,
    WheelUp,
    WheelDown
}

public enum KeyboardEventType
{
    Down,
    Up,
    Pressed
}

public enum ColliderEventType
{
    Enter,
    Exit,
    Stay
}

[CustomEditor(typeof(Logic), true)]
public class LogicEditor : Editor
{


    private Logic logic;
    private SerializedProperty keyboaedEventHandlers;

    void OnEnable()
    {
        keyboaedEventHandlers = serializedObject.FindProperty("KeyboardHandlers");
    }

    private GenericMenu addEventMenu;



    public override void OnInspectorGUI()
    {


        logic = target as Logic;

        if (addEventMenu == null)
            addEventMenu = BuildAddEventHandlersMenu();

        for (int i = 0; i < keyboaedEventHandlers.arraySize; i++)
        {
            EditorGUILayout.PropertyField(keyboaedEventHandlers.GetArrayElementAtIndex(i));

            Rect rect = GUILayoutUtility.GetLastRect();
            rect.x = rect.width - 50;
            rect.width = 50;
            rect.height = 15;

            if (GUI.Button(rect, new GUIContent("x")))
            {



                Debug.Log(i);
                  logic.RemoveEventHandler(i);
                


            }

            EditorGUILayout.Space();
      
        }

        Rect menuRect = EditorGUILayout.GetControlRect();

        if (EditorGUILayout.DropdownButton(new GUIContent("Add Event"), FocusType.Passive))
        {

           // string[] a = EventMenuBuilder.GetAllItems();
           // for (int i = 0; i < a.Length; i++)
            {
              //  Debug.Log(a[i]);
            }
              addEventMenu.DropDown(menuRect);
        }

        if (GUILayout.Button(new GUIContent("Clear Events")))
        {
            logic.ClearEventHandlers();
        }



    }

    public void F()
    {

    }

    public void AddEventHandler(object properties)
    {

        if(properties is KeyboardEventHandlerProperties)
        {
           
            KeyboardEventHandler keyboardEvent = (KeyboardEventHandler) Activator.CreateInstance(typeof(KeyboardEventHandler));
            keyboardEvent.AssignPropertis( (KeyboardEventHandlerProperties) properties);

            Debug.Log(keyboardEvent);

            logic.AddEventHandler(keyboardEvent);
        }

    
    }

    public GenericMenu BuildAddEventHandlersMenu()
    {
        GenericMenu menu = new GenericMenu();


        string[] allItems = EventMenuBuilder.GetAllItems();

        Debug.Log(allItems.Length);

        for(int i = 0; i < allItems.Length; i++)
        {
            menu.AddItem(new GUIContent(allItems[i]), false, F);
        }

        return menu;
        /*
        string[] eventMenu = EventMenuBuilder.BuildEventMenu();

        string[] eventTypes = new string[0];



        for (int i = 0; i < eventMenu.Length; i++)
        {
            if (i == (int) EventGroups.Mouse) eventTypes = EventMenuBuilder.AddEnumName(eventMenu[i], typeof(MouseEventType));
            if (i == (int) EventGroups.Keyboard) eventTypes = EventMenuBuilder.AddEnumName(eventMenu[i], typeof(KeyboardEventType));
            if (i == (int) EventGroups.Collision) eventTypes = EventMenuBuilder.AddEnumName(eventMenu[i], typeof(ColliderEventType));
            if (i == (int) EventGroups.Trigger) eventTypes = EventMenuBuilder.AddEnumName(eventMenu[i], typeof(ColliderEventType));

            
            for (int j = 0; j < eventTypes.Length; j++)
            {
                menu.AddItem(new GUIContent(eventTypes[j]), false, F);
            }

            if(eventTypes.Length == 0)
                menu.AddItem(new GUIContent(eventMenu[i]), false, F);



          

        
            /*
            if ((EventGroups)Enum.Parse(typeof(EventGroups), eventMenu[i]) == EventGroups.KeyboardPressed
            || (EventGroups)Enum.Parse(typeof(EventGroups), eventMenu[i]) == EventGroups.KeyboardDown
            || (EventGroups)Enum.Parse(typeof(EventGroups), eventMenu[i]) == EventGroups.KeyboardUp)
            {
                string[] keyboards = EventMenuBuilder.AddKeyboardButton(eventMenu[i]);

                for (int j = 0; j < keyboards.Length; j++)
                {
                    menu.AddItem(new GUIContent(keyboards[j]), false, F);
                }
            }

            else
            {
                menu.AddItem(new GUIContent(eventMenu[i]), false, F);
            }

            if (i == 2 || i == 5 || i == 8 || i == 11 || i == 14)
                menu.AddSeparator("");
                *
        }
    */
        return menu;
    }

    public GenericMenu BuildKeyCodeMenu()
    {
        GenericMenu menu = new GenericMenu();

        foreach (int i in Enum.GetValues(typeof(EventGroups)))
        {
            KeyboardEventHandlerProperties keyboardEventHandler = new KeyboardEventHandlerProperties();
          //  keyboardEventHandler.keyCode = (KeyCode)i;
           // keyboardEventHandler.eventType = EventType.ContextClick;

            menu.AddItem(new GUIContent(((EventGroups)i).ToString()), false, AddEventHandler, keyboardEventHandler as object);
        }

        return menu;
    }

}
