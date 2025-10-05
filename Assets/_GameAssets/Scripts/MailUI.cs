using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MailUI : MonoBehaviour
{
    public TMP_Text senderText;
    public TMP_Text subjectText;
    public TMP_Text bodyText;
    public Button spamButton;
    public Button notSpamButton;

    private MailSO template;

    public void Setup(MailSO t)
    {
        template = t;
        if (senderText) senderText.text = t.sender;
        if (subjectText) subjectText.text = t.subject;
        if (bodyText) bodyText.text = t.body;

        spamButton.onClick.AddListener(OnSpam);
        notSpamButton.onClick.AddListener(OnNotSpam);
    }

    void OnSpam()
    {
        HandleChoice(true);
    }

    void OnNotSpam()
    {
        HandleChoice(false);
    }

    void HandleChoice(bool choseSpam)
    {
        bool correct = (template.isSpam == choseSpam);
        if (!correct)
        {
            // Hatalıysa spawner aracılığıyla hack/jumpscare/gameover
            MailSpawner.Instance.TriggerHackEffect(template);
            // Opsiyonel: eğer ilk yanlış -> GameOver immediately:
            if (/* senin game over şartınsa */ true && !template.causesHack && !template.causesJumpScare)
            {
                FindObjectOfType<GameManager>()?.GameOver();
            }
        }
        else
        {
            // Doğruysa puan ver, UI destroy vs.
            //FindObjectOfType<GameManager>()?.OnMailClassifiedCorrectly(template);
        }

        Destroy(gameObject); // mail kapandı / sınıflandırıldı
    }


    void OnDestroy()
    {
        // cleanup listeners
        spamButton.onClick.RemoveAllListeners();
        notSpamButton.onClick.RemoveAllListeners();
        MailSpawner.Instance.OnMailDestroyed();
    }
}
