using UnityEngine;

[System.Serializable]
public class KeyboardEventHandler : EventHandler
{
    public KeyCode keyCode;
    public EventType eventType;

    public KeyboardEventHandler(KeyCode keyCode, EventType eventType)
    {
        this.keyCode = keyCode;
        this.eventType = eventType;

        DispalyName = "Keyboard " + eventType.ToString() + " - " + keyCode;
    }

    public void Invoke(KeyCode keyCode, UnityEngine.EventType type)
    {

      //  Debug.Log(this.keyCode + "  " + keyCode + " | "+ this.eventType + " " +  type);

        if (this.keyCode == keyCode && this.eventType == type)
        {
            base.Invoke();
        }
    }

    


}

