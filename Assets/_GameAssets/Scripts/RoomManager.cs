using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject _pcScreen;
    [SerializeField] private GameObject _room;
    [SerializeField] private GameObject _electric;
    [SerializeField] private Image _blackoutImage; 
    [SerializeField] private float _fadeDuration = 1f;
    private bool isDark = false;
    private bool _pcOn = false;
    void Update()
    {
        if (_pcOn && Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlayClick();
        }
    }

    public void PCON()
    {
        _pcScreen.SetActive(true);
        _pcOn = true;
        _room.SetActive(false);
        SoundManager.Instance.PlayPCON();
    }
    public void PCOFF()
    {
        _pcScreen.SetActive(false);
        _pcOn = false;
        _room.SetActive(true);
    }
    public void TriggerBlackout()
    {
        if (!isDark) StartCoroutine(FadeToBlack());
        else StartCoroutine(FadeToClear());
    }

    IEnumerator FadeToBlack()
    {
        isDark = true;
        float t = 0;
        while (t < _fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / _fadeDuration);
            _blackoutImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator FadeToClear()
    {
        isDark = false;
        float t = 0;
        while (t < _fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / _fadeDuration);
            _blackoutImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
