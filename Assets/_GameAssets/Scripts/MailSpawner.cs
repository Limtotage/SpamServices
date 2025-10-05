using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MailSpawner : MonoBehaviour
{
    public static MailSpawner Instance;
    [SerializeField] private GameObject _mailsScreen;
    [SerializeField] private MailDBSO database;
    [SerializeField] private Transform mailParent;
    [SerializeField] private GameObject dayOffMail;
    [SerializeField] private float spawnDelayAfterDestroy = 2f;
    private bool _isMailsOn = false;
    private GameObject currentMail;

    private int mailCount = 0;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }
    void Start()
    {
        if (database == null) Debug.LogError("MailDatabase yok!");
    }
    void TrySpawn()
    {
        if (!_isMailsOn) return;
        if (currentMail != null) return; 
        if (database.GetCount()-1 == mailCount )
        {
            Instantiate(dayOffMail, mailParent);
        }

        var template = database.mails[mailCount];
        if (template == null || template.mailPrefab == null) return;

        currentMail = Instantiate(template.mailPrefab, mailParent);

        var mailUI = currentMail.GetComponent<MailUI>();
        if (mailUI != null)
        {
            mailUI.Setup(template); 
        }
        mailCount++;
    }
    public void OnMailDestroyed()
    {
        currentMail = null;
        StartCoroutine(SpawnAfterDelay());
    }

    IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelayAfterDestroy);
        TrySpawn();
    }

    public void GetMails()
    {
        _mailsScreen.SetActive(true);
        _isMailsOn = true;
        TrySpawn();
    }
    public void TurnOffMails()
    {
        _mailsScreen.SetActive(false);
        _isMailsOn = false;
    }

    public void TriggerHackEffect(MailSO t)
    {
    }
}
