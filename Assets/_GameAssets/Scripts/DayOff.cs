using System;
using UnityEngine;
using UnityEngine.UI;

public class DayOff : MonoBehaviour
{
    [SerializeField] private Button _dayOff;
    void OnEnable()
    {
        _dayOff.onClick.AddListener(OnDayOff);
    }
    void OnDayOff()
    {
        FindObjectOfType<MailSpawner>()?.TurnOffMails();
        GameManager.Instance.IsMailsDone(true);
        Destroy(gameObject);
    }
}

