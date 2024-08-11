using System;
using UnityEngine;
using Object = UnityEngine.Object;



[Serializable]
public class VariablePicker
{
    // Такая схема используется потому что Variable - не объект юнити, и его нельзя назначит через редактор
    [SerializeField] private string variableName;
    [SerializeField] private Object owner;

    public VariableTypes filter = VariableTypes.Any;

    public Variable Variable
    {
        get
        {
            if (owner is Behaviour) return (owner as Behaviour).GetVariable(variableName);

            if (owner is ScriptableVariable) return (owner as ScriptableVariable).Variable;

            return null;
        }
       
    }
    

}


