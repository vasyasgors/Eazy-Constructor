using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;




public static class EventProperties
{
    public const string None = "None";


    public static string[] GetColliderProperties()
    {
        List<string> menu = new List<string>();

        for (int i = 0; i < UnityEditorInternal.InternalEditorUtility.tags.Length; i++)
        {
            menu.Add(UnityEditorInternal.InternalEditorUtility.tags[i]);
        }


        return menu.ToArray();
    }

    public static string[] GetMouseProperties()
    {
        List<string> menu = new List<string>();

        menu.Add("Left");
        menu.Add("Middle");
        menu.Add("Right");

        return menu.ToArray();
    }


    public static string[] GetKeyboardProperties()
    {

        List<string> menu = new List<string>();
        Dictionary<string, List<int>> neededKeyCode = new Dictionary<string, List<int>>();

        List<int> ArrowKeyCode = new List<int>() { 273, 274, 275, 276 };
        List<int> MainKeyCode = new List<int>() { 306, 308, 304, 32, 13 };
        List<int> DigitKeyCode = new List<int>() { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57 };
        List<int> LatterKeyCode = new List<int>(); for (int i = 282; i < 293; i++) LatterKeyCode.Add(i);
        List<int> FunctionKeyCode = new List<int>(); for (int i = 282; i < 289; i++) FunctionKeyCode.Add(i);
        List<int> OtherKeyCode = new List<int>() { 8, 9, 27, 278, 279, 127, 277, 280, 281 };

        // Заменить на енамы
        neededKeyCode.Add("Arrow", ArrowKeyCode);
        neededKeyCode.Add("Main", MainKeyCode);
        neededKeyCode.Add("Digit", DigitKeyCode);
        neededKeyCode.Add("Latters", LatterKeyCode);
        neededKeyCode.Add("Function", FunctionKeyCode);
        neededKeyCode.Add("Other", OtherKeyCode);

        for (int i = 0; i < neededKeyCode.Keys.Count; i++)
        {
            List<int> t = new List<int>();
            neededKeyCode.TryGetValue(neededKeyCode.Keys.ElementAt(i), out t);

            for (int j = 0; j < t.Count; j++)
            {
                menu.Add((((KeyCode) t[j])).ToString());

            }
        }

        return menu.ToArray();
    }


}
