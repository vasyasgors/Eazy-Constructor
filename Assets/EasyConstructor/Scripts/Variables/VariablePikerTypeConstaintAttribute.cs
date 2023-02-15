using System;

[AttributeUsage(AttributeTargets.Field)]
public class VariablePickerTypeAttribute : Attribute
{
    private VariableTypes type;

    public VariableTypes Type { get { return type; } }

    public VariablePickerTypeAttribute(VariableTypes type)
    {
        this.type = type;
    }

    public VariablePickerTypeAttribute(object type)
    {
        this.type = Variable.GetVariableTypeFormType(type.GetType());
    }
}
