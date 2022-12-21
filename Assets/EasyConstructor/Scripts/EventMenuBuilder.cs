using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;

public static class EventMenuBuilder
{


    public static string[] GetAllEventWithProperties()
    {
        List<string> allItems = new List<string>();

        string[] firstLevel = Enum.GetNames(typeof(EventGroups));

     

        for (int i = 0; i < firstLevel.Length; i++)
        {
            string[] secondLevel = new string[0];

        
            if (i == (int)EventGroups.LifeTime) secondLevel = AddEnumToItem(firstLevel[i], typeof(LifeTimeEventType));
            if (i == (int)EventGroups.Mouse) secondLevel = AddEnumToItem(firstLevel[i], typeof(MouseEventType));
            if (i == (int)EventGroups.Keyboard) secondLevel = AddEnumToItem(firstLevel[i], typeof(KeyboardEventType));
            if (i == (int)EventGroups.Collision) secondLevel = AddEnumToItem(firstLevel[i], typeof(ColliderEventType));
            if (i == (int)EventGroups.Trigger) secondLevel = AddEnumToItem(firstLevel[i], typeof(ColliderEventType));
           
            if(secondLevel.Length > 0)
            {
                for (int j = 0; j < secondLevel.Length; j++)
                {
                    string[] thirdLevel = new string[0];

                    if (i == (int)EventGroups.Mouse) thirdLevel = AddArrayToItem(secondLevel[j], EventProperties.GetMouseProperties());
                    if (i == (int)EventGroups.Keyboard) thirdLevel = AddArrayToItem(secondLevel[j], EventProperties.GetKeyboardProperties());
                   // if (i == (int)EventGroups.Collision) thirdLevel = AddArrayToItem(secondLevel[j], EventProperties.GetColliderProperties());
                    if (i == (int)EventGroups.Trigger) thirdLevel = AddArrayToItem(secondLevel[j], EventProperties.GetColliderProperties());

                    if (thirdLevel.Length > 0)
                    {
                        for(int k = 0; k < thirdLevel.Length; k++)
                            allItems.Add(thirdLevel[k]);
                    }
                    else
                    {
                        allItems.Add(secondLevel[j]);
                    }                  
                }
            }
            else
            {
                allItems.Add(firstLevel[i]);
            }
     
        }

        return allItems.ToArray();
    }

    public static string[] AddEnumToItem(string item, Type type)
    {
        List<string> menu = new List<string>();

        foreach(string enumItem in Enum.GetNames(type))
        {
            menu.Add(item + "/" + enumItem);
        }

        return menu.ToArray();
    }

    public static string[] AddArrayToItem(string item, string[] array)
    {
        List<string> menu = new List<string>();

        for(int i = 0; i < array.Length; i++)
        {
            menu.Add(item + "/" + array[i]);
        }

        return menu.ToArray();
    }

  

    /*
    public static string[] AddKeyboardProperties(string item)
    {

        List<string> menu = new List<string>();
        Dictionary<string, List<int>> neededKeyCode = new Dictionary<string, List<int>>();

        List<int> ArrowKeyCode = new List<int>() { 273, 274, 275, 276 };
        List<int> MainKeyCode = new List<int>() { 306, 308, 304, 32, 13 };
        List<int> DigitKeyCode = new List<int>() { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };
        List<int> LatterKeyCode = new List<int>(); for (int i = 282; i < 293; i++) LatterKeyCode.Add(i);
        List<int> FunctionKeyCode = new List<int>(); for (int i = 282; i < 289; i++) FunctionKeyCode.Add(i);
        List<int> OtherKeyCode = new List<int>() {8, 9, 27, 278, 279, 127, 277, 280, 281};

        // Заменить на енамы
        neededKeyCode.Add("Arrow", ArrowKeyCode);
        neededKeyCode.Add("Main", MainKeyCode);
        neededKeyCode.Add("Digit", DigitKeyCode); 
        neededKeyCode.Add("Latters", LatterKeyCode);
        neededKeyCode.Add("Function", FunctionKeyCode);
        neededKeyCode.Add("Other", OtherKeyCode);

        for(int i = 0; i < neededKeyCode.Keys.Count; i++)
        {
            List<int> t = new List<int>();
            neededKeyCode.TryGetValue(neededKeyCode.Keys.ElementAt(i), out t);

            for (int j = 0; j < t.Count; j++)
            {
                menu.Add(item + "/" + neededKeyCode.Keys.ElementAt(i) + "/" + ((KeyCode)t[j]).ToString() ) ;

            }
        }

        return menu.ToArray();
    }
    */
}
