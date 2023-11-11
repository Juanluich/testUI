using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ScoreButtonController : MonoBehaviour
{
    [SerializeField] List<GameObject> scoreContent = new List<GameObject>();
    [SerializeField] GameObject panel;
    [SerializeField] List<GameObject> panelContentToHide = new List<GameObject>();

    [SerializeField] AudioClip FlipSFX;
    [SerializeField] AudioClip UnFlipSFX;
    AudioSource audiosource;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }
    public void Flip()
    {
        audiosource.PlayOneShot(FlipSFX);
        panel.transform.DORotate(new Vector3(0,transform.rotation.y+180f,0), .7f);
        foreach(var obj in panelContentToHide)
        {
            obj.transform.DOScale(0f, .2f).SetEase(Ease.InBounce);
        }

        StartCoroutine(ShowScoreContent());
        
    }
    public void UnFlip()
    {
        audiosource.PlayOneShot(UnFlipSFX);
        panel.transform.DORotate(new Vector3(0, 0, 0), .7f);
        
        foreach (var content in scoreContent)
        {
            content.transform.DOScale(0f, 0.2f).SetEase(Ease.Linear);
        }
        StartCoroutine(ShowMainContent());
    }
    IEnumerator ShowMainContent()
    {
        yield return new WaitForSeconds(0.25f);
        foreach (var obj in panelContentToHide)
        {
            obj.transform.DOScale(1f, .2f).SetEase(Ease.InBounce);
        }
    }
    IEnumerator ShowScoreContent()
    {
        yield return new WaitForSeconds(0.25f);
        foreach (var content in scoreContent)
        {
            content.transform.DOScale(1f, .2f).SetEase(Ease.InBounce);
        }
    }
}
