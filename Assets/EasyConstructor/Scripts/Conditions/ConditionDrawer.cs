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

[CustomPropertyDrawer(typeof(Condition))]
public class ConditionDrawer : PropertyDrawer
{

    private string operationTextLabel = "(Operation)";
    private string firstVariableLabel = "(Value)";
    private string secondVariableLabel = "(Value)";

    private Object fistObject;
    private Object secondObject;

    private SerializedProperty firstObjectProperty;
    private SerializedProperty secondObjectProperty;
    private SerializedProperty firstVariableNameProperty;
    private SerializedProperty secondVariableNameProperty;
    private SerializedProperty operationProperty;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + 25;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

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

        operationProperty = property.FindPropertyRelative("operation");

        // Get property мalue
        fistObject = firstObjectProperty.objectReferenceValue;
        secondObject = secondObjectProperty.objectReferenceValue;

        
        firstVariableLabel = firstVariableNameProperty.stringValue;
        secondVariableLabel = secondVariableNameProperty.stringValue;

        operationTextLabel = operationProperty.stringValue;

        // Reset
        if (fistObject == null)
            firstVariableLabel = "none";

        if (secondObject == null)
            secondVariableLabel = "none";

        if (fistObject == null || secondObject == null)
            operationTextLabel = "none";

        // Draw fields
        fistObject = EditorGUI.ObjectField(firstObjectRect, GUIContent.none, fistObject, typeof(Object), true);
        secondObject = EditorGUI.ObjectField(secondObjectRect, GUIContent.none, secondObject, typeof(Object), true);

        if (EditorGUI.DropdownButton(firstVariableRect,  new GUIContent(firstVariableLabel), FocusType.Passive) == true)
        {
            if (fistObject != null)
            {
                GetVariableMenu(fistObject, true).DropDown(firstVariableRect);
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
        firstObjectProperty.objectReferenceValue = fistObject;
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

        firstObjectProperty.objectReferenceValue = operand.sourceObject;
        firstObjectProperty.serializedObject.ApplyModifiedProperties();

        firstVariableNameProperty.stringValue = operand.propertyName;
        firstVariableNameProperty.serializedObject.ApplyModifiedProperties();

        firstVariableLabel = operand.propertyName + " Тип";     
    }

    private void UpdateSecondVariable(object data)
    {
        ConditionOperand operand = data as ConditionOperand;

        secondObjectProperty.objectReferenceValue = operand.sourceObject;
        secondObjectProperty.serializedObject.ApplyModifiedProperties();

        secondVariableNameProperty.stringValue = operand.propertyName;
        secondVariableNameProperty.serializedObject.ApplyModifiedProperties();

        secondVariableLabel = operand.propertyName + " Тип";
    }

  

    // фильтрация свойств
    private GenericMenu GetVariableMenu(Object target, bool isFirstObject)
    {
        // Не искать скрыте компоненты
        Debug.Log(target);

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

        /*
        if (target is ScriptableObject)
        {
            Type componentType = target.GetType();

            Debug.Log(componentType);

            var wantedProperties = componentType.GetFields();

            for (int j = 0; j < wantedProperties.Length; j++)
            {
                if (target == fistObject)
                    menu.AddItem(new GUIContent(wantedProperties[j].Name), false, UpdateFirstVariable, 
                        new ObjectProp(target, wantedProperties[j].Name));

                if (target == secondObject)
                    menu.AddItem(new GUIContent(wantedProperties[j].Name), false, UpdateSecondVariable, 
                        new ObjectProp(target, wantedProperties[j].Name));
            }
        }

        */

        return menu;
    }
}
