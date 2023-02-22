
public enum ToggleState
{
	On,
	Off,
	Toogle
}


public static class ToggleStateExtensions
{
	public static bool ToBool(this ToggleState state)
    {
		if (state == ToggleState.On) return true;
		if (state == ToggleState.Off) return false;

		return true;
	}

	public static bool ToBool(this ToggleState state, bool value)
	{
		if (state == ToggleState.On) return true;
		if (state == ToggleState.Off) return false;
		if (state == ToggleState.Toogle) return !value;

		return true;
	}

	public static ToggleState FromBool(this ToggleState state, bool value)
    {
		if (value == true) return ToggleState.On;
		if (value == false) return ToggleState.Off;

		return ToggleState.Off;
    }
}
