using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCustom : MonoBehaviour ,IPointerDownHandler , IPointerUpHandler ,IPointerExitHandler
{
    public Button.ButtonClickedEvent onClick;
    public bool doAnim = true;
    public bool canClick = true;
    Vector3 scaleStart;
    bool enter;
    private void Awake()
    {
        scaleStart = transform.localScale;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(canClick)
        {
            if(doAnim)
            {
                DOTween.Kill(this);
                transform.DOScale(scaleStart * 1.1f, 0.5f);
            }
            enter = true;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if(Input.GetMouseButton(0) == false && enter==true)
        {
            DOTween.Kill(this);
            transform.DOScale(scaleStart, 0.5f);
            if (canClick)
            {
                onClick?.Invoke();
            }
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DOTween.Kill(this);
        enter = false;
        transform.DOScale(scaleStart, 0.5f);
    }
}
