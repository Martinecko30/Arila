using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] private Quest selectedQuest;
    [SerializeField] private List<Quest> allQuests;

    [Header("QuestWindow")]
    [SerializeField] private TMP_Text questName;
    [SerializeField] private TMP_Text questDesc;
    [SerializeField] private TextAsset quest;
    private void Start()
    {
        SetQuest(CreateQuestFromJSON(quest.text));
    }

    public void SetQuest(Quest newQuest)
    {
        selectedQuest = newQuest;
    }

    public Quest CreateQuestFromJSON(string jsonString)
    {
        if (string.IsNullOrEmpty(jsonString)) { return null; }
        return JsonUtility.FromJson<Quest>(jsonString);
    }

    public void AddQuest(Quest newQuest)
    {
        allQuests.Add(newQuest);
        SetQuest(newQuest);
    }

    public void AddQuest(string questJSON)
    {
        AddQuest(CreateQuestFromJSON(questJSON));
    }
}