using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject _intro;
    [SerializeField] private GameObject _warning;
    [SerializeField] private TMP_Text _Days;
    [SerializeField] private GameObject _thanksForPlaying;

    private bool _isMailsDone = false;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(Daycounts());
    }
    IEnumerator Daycounts()
    {
        _Days.text = "Day " + (SceneManager.GetActiveScene().buildIndex + 1);
        yield return new WaitForSeconds(1);
        _Days.text = "";
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(Intro());
        }
    }
    IEnumerator Intro()
    {
        _intro.SetActive(true);
        yield return new WaitForSeconds(8);
        SoundManager.Instance.PlayMusic();
        _intro.SetActive(false);
    }
    IEnumerator Warning()
    {
        _warning.SetActive(true);
        yield return new WaitForSeconds(3);
        _warning.SetActive(false);
    }

    public void IsMailsDone(bool key)
    {
        _isMailsDone = key;
    }
    public void nextDay()
    {
        if (_isMailsDone&&SceneManager.GetActiveScene().buildIndex == 2)
        {
            _thanksForPlaying.SetActive(true);
            Time.timeScale = 0;
        }
        if (_isMailsDone)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            StartCoroutine(Warning());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        SoundManager.Instance.PlayGameOver();
        Time.timeScale = 0;

    }
    public void RetryGame()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }
    public void RetryDay()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CatSound()
    {
        SoundManager.Instance.PlayMeow();
    }
}
