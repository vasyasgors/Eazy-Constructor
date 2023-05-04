using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[AddComponentMenu("Constructor/UIButton")]
public class UIButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EventHandler OnClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick.ForceInvoke(gameObject, gameObject);
    }
}
