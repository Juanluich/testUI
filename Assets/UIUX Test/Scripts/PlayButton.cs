using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayButton : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip playSFX;

    [SerializeField] List<GameObject> mainPanelContent = new List<GameObject>();

    [SerializeField] Transform circleBackground;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClickPlay()
    {
        audioSource.PlayOneShot(playSFX);
        foreach(GameObject go in mainPanelContent)
        {
            go.transform.DOScale(0f, 1f).SetEase(Ease.OutBounce);
        }
        circleBackground.DOScale(4f, 1f).SetEase(Ease.OutBounce);
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3f);
        foreach (GameObject go in mainPanelContent)
        {
            go.transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
        }
        circleBackground.DOScale(1f, .5f).SetEase(Ease.Linear);
    }
}
