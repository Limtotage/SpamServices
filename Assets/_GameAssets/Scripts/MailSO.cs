using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MailTemplate", menuName = "Mails/Mail Template")]
public class MailSO : ScriptableObject
{
    [Header("Core")]
    public string sender;
    public string subject;
    [TextArea(3,6)]
    public string body;
    public bool isSpam;            // true ise aslında spam

    [Header("Presentation")]
    public GameObject mailPrefab;  // prefab that contains UI layout (sender, subject, body)
    public Sprite icon;

    [Header("Gameplay Effects")]
    public bool causesHack;        // yanlış tıklanırsa hack effect (örn. mouse invert)
    public bool causesJumpScare;   // yanlış tıklanırsa jumpscare
    public float difficultyWeight = 1f; // spawn seçimlerinde ağırlık

    [Header("Optional")]
    public float minSpawnDelay = 0f; // mail için spesifik spawn kısıtlaması
    public float maxSpawnDelay = 0f;
}
