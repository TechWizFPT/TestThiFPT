using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCustom : MonoBehaviour ,IPointerDownHandler
{
    public Button.ButtonClickedEvent onClick;
   
    public bool canClick = true;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(canClick)
        {
             onClick?.Invoke();
        }
    }
}
