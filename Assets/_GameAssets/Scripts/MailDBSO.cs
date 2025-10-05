using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MailDatabase", menuName = "Mails/Mail Database")]
public class MailDBSO : ScriptableObject
{
    public List<MailSO> mails = new List<MailSO>();

    // Basit helper: ağırlıklı rastgele seçim
    public MailSO GetRandomWeighted()
    {
        float total = 0f;
        foreach (var m in mails) total += Mathf.Max(0.01f, m.difficultyWeight);
        float r = Random.value * total;
        foreach (var m in mails)
        {
            r -= Mathf.Max(0.01f, m.difficultyWeight);
            if (r <= 0) return m;
        }
        return mails.Count > 0 ? mails[Random.Range(0, mails.Count)] : null;
    }
    public int GetCount()
    {
        return mails.Count;
    }
}
