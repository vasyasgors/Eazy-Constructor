using UnityEngine;


public struct KeyboardEventHandlerProperties
{
    public KeyCode keyCode;
    public EventGroups eventType;
}

[System.Serializable]
public class KeyboardEventHandler : EventHandler
{


    public KeyCode keyCode;
    public EventGroups eventType;

    public void  AssignPropertis(KeyboardEventHandlerProperties properties)
    {
        this.keyCode = properties.keyCode;
        this.eventType = properties.eventType;

        DispalyName = "Keyboard " + eventType.ToString() + " - " + keyCode;
    }

    
    public void Invoke(KeyCode keyCode, UnityEngine.EventType type)
    {

        //  Debug.Log(this.keyCode + "  " + keyCode + " | "+ this.eventType + " " +  type);

        //  if (this.keyCode == keyCode && this.eventType == type)
        {
            base.Invoke();
        }
    }


}

