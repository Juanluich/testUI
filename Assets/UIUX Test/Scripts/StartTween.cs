using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartTween : MonoBehaviour
{
    [SerializeField] float fadeTime = 1f;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] RectTransform rectTransform;

    [SerializeField] List<GameObject> items = new List<GameObject>();

    [SerializeField] AudioClip popUpSFX;
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -10f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
        StartCoroutine(nameof(ItemsAnimation));
    }

    public void PanelFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -10f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(1, fadeTime);

    }

    IEnumerator ItemsAnimation()
    {
        foreach(var item in items)
        {
            item.transform.localScale = Vector3.zero;
        }
        foreach(var item in items)
        {
            audioSource.PlayOneShot(popUpSFX);
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
        
    }
}
