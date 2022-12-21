public enum EventGroups
{
    LifeTime,
    Mouse,
    Keyboard,
    Collision,
    Trigger,
}


public enum LifeTimeEventType
{
    Create,
    Destroy,
    Update
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