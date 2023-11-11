using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExtraButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Tweener shakeTween;
    [SerializeField] float bounceDuration;
    [SerializeField] float swapDuration;
    [SerializeField] float scale;

    [SerializeField] GameObject extraPanel;

    bool clicked = false;

    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip extraButtonSFX;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!clicked){
            shakeTween = transform.DOScale(1.3f, bounceDuration); } 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!clicked){
            shakeTween = transform.DOScale(1f, bounceDuration);}  
    }

    public void OnClickScaleToZero()
    {
        audiosource.PlayOneShot(extraButtonSFX);
        clicked = true;
        StartCoroutine(ShowExtraPanel(0.5f));
        transform.DOScale(0f, swapDuration).SetEase(Ease.OutBounce);
    }
    IEnumerator ShowExtraPanel(float delay)
    {
        yield return new WaitForSeconds(delay);
        extraPanel.SetActive(true);
        extraPanel.transform.DOScale(1f, swapDuration).SetEase(Ease.OutBounce);
    }

    public void HideExtraButtons()
    {
        extraPanel.SetActive(false);
        extraPanel.transform.DOScale(0f, swapDuration).SetEase(Ease.InBounce);
        
    }
    IEnumerator HideExtraButtonDelay()
    {
        yield return new WaitForSeconds(4f);
        transform.DOScale(1f, .5f).SetEase(Ease.InBounce);
    }

    void ResetScale() { transform.DOScale(new Vector3(1, 1, 1), 0.1f); }

}
