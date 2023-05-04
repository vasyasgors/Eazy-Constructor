using System;

[AttributeUsage(AttributeTargets.Field)]
public class VariablePickerFilterAttribute : Attribute
{
    private VariableTypes type;

    public VariableTypes Type { get { return type; } }

    public VariablePickerFilterAttribute(VariableTypes type)
    {
        this.type = type;
    }

    public VariablePickerFilterAttribute(object type)
    {
        this.type = Variable.GetVariableType(type.GetType());
    }
}
