using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public abstract class Popups : MonoBehaviour
{
    public CanvasGroup PopupCanvasGroup;
    public CanvasGroup PopupPanel;

    public virtual void Appear(Action action =null)
    {
        PopupCanvasGroup.alpha = 0;
        PopupCanvasGroup.DOFade(1, GameConstant.TIME_APPEAR_POPUP);
        PopupPanel.transform.localScale = Vector3.zero;
        PopupPanel.transform.DOScale(Vector3.one, GameConstant.TIME_APPEAR_POPUP).SetEase(Ease.OutBack);
        DOVirtual.DelayedCall(GameConstant.TIME_APPEAR_POPUP, () =>
        {
            action?.Invoke();
        });
    }

    public virtual void Disappear(Action action = null)
    {
        PopupCanvasGroup.DOFade(0, GameConstant.TIME_DISAPPEAR_POPUP);
        PopupPanel.transform.DOScale(Vector3.zero, GameConstant.TIME_DISAPPEAR_POPUP).SetEase(Ease.InBack);
        DOVirtual.DelayedCall(GameConstant.TIME_DISAPPEAR_POPUP, () =>
        {
            action?.Invoke();
        });
    }

  
}
