using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleEffectOnPointerEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.3f, .5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, .5f);
    }
}
