public enum EventGroups
{
    LifeTime,
    Trigger,
    Collision,
    Mouse,
    Keyboard,
}


public enum LifeTimeEventType
{
    Start,
    Update,
    OnDestroy,
}

public enum MouseEventType
{
    Down,
    Up,
    Pressed,
    ObjectDown,
    ObjectEnter,
    ObjectExit,
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

public enum MouseEventProperties
{ 
    Left,
    Right,
    Middle
}
