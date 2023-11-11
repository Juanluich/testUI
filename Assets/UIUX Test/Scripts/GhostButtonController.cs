using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GhostButtonController : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] TextMeshProUGUI textGhostButton;
    Button button;

    Image ghostButtonImage;

    [SerializeField] AudioClip ghostSFX;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponentInParent<AudioSource>();
        ghostButtonImage = GetComponent<Image>();
        button = GetComponentInParent<Button>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOShakePosition(4f,0.8f, 8);
    }


    public void OnClick(Image barButtonImg)
    {
        audioSource.PlayOneShot(ghostSFX);
        barButtonImg.DOFade(0f, 1f);
        ghostButtonImage.DOFade(0f, 1f).SetEase(Ease.Linear);
        textGhostButton.DOFade(0f, 1f);
        StartCoroutine(ResetButton(barButtonImg));
        button.enabled = false;
    }
    IEnumerator ResetButton(Image barButtonImg)
    {
        yield return new WaitForSeconds(5f);

        barButtonImg.DOFade(1f, 1f);
        ghostButtonImage.DOFade(1f, 1f).SetEase(Ease.Linear);
        textGhostButton.DOFade(1f, 1f);
        textGhostButton.DOFade(1f, 1f);
        button.enabled = true;
    }
    
}
