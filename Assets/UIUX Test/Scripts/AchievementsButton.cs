using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class AchievementsButton : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip clip;

    [SerializeField] List<GameObject> collectables = new List<GameObject>();
    [SerializeField] List<GameObject> mainContent = new List<GameObject>();

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickOnAchievement()
    {
        audioSource.PlayOneShot(clip);
        HideContent();
        foreach (var item in collectables)
        {
            item.transform.DOScale(1f, .5f).SetEase(Ease.OutBounce);
        }
    }

    void HideContent()
    {
        foreach (var content in mainContent)
        {
            content.transform.DOScale(0f, 0.2f).SetEase(Ease.Linear);
        }
    }
    public void CloseAchivements()
    {
        foreach (var item in collectables)
        {
            item.transform.DOScale(0f, .5f).SetEase(Ease.OutBounce).OnComplete(()=> 
            {
                foreach (var content in mainContent)
                {
                    content.transform.DOScale(1f, 0.2f).SetEase(Ease.Linear);
                }
            });
        }
        
    }
}
