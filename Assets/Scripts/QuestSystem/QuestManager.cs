using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] private Quest selectedQuest;
    [SerializeField] private List<Quest> allQuests;

    [Header("Quest List Canvas")]
    [SerializeField] private Button questPrefab;
    [SerializeField] private Transform questListTransform;
    [SerializeField] private Canvas questListCanvas;

    [Header("Quest Info Canvas")]
    [SerializeField] private TMP_Text questName;
    [SerializeField] private TMP_Text questDesc, questLVL, questGoldRwd, questExpRwd;

    public TextAsset questAsset;

    private List<Button> questButtons = new List<Button>();

    private void Start()
    {
        selectedQuest = CreateQuestFromJSON(questAsset.text);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        allQuests.Add(selectedQuest);
        SelectQuestCanvas();
    }

    public static Quest CreateQuestFromJSON(string jsonString)
    {
        if (string.IsNullOrEmpty(jsonString)) 
            return null;
        return JsonUtility.FromJson<Quest>(jsonString);
    }

    public void AddQuest(Quest newQuest)
    {
        allQuests.Add(newQuest);
    }

    public void AddQuest(string questJSON)
    {
        AddQuest(CreateQuestFromJSON(questJSON));
    }

    public void SelectQuestCanvas()
    {
        CreateQuestButtons();
        SelectQuest(selectedQuest);
    }

    private void CreateQuestButtons()
    {
        DeleteButtons();
        questListCanvas.GetComponent<RectTransform>().sizeDelta = new Vector2(460, 100 * allQuests.Count);
        for (int i = 0; i < allQuests.Count; i++)
        {
            var questButton = Instantiate(questPrefab, questListTransform);

            // Transform
            var rectTrans = questButton.GetComponent<RectTransform>();
            rectTrans.sizeDelta = new Vector2(460, 100);
            rectTrans.localScale = new Vector3(1, 1, 1);
            rectTrans.anchoredPosition = new Vector3(0, -100 * i, 0);

            questButton.GetComponentInChildren<TMP_Text>().text = "(" + allQuests[i].suggestedLevel + ") " + allQuests[i].questName;

            int tempI = i;
            questButton.onClick.AddListener(delegate { 
                SelectQuest(allQuests[tempI]);
            });

            questButtons.Add(questButton);
        }
    }

    public void SelectQuest(Quest quest)
    {
        selectedQuest = quest;
        questName.text = quest.questName;
        questDesc.text = quest.description;
        questLVL.text = quest.suggestedLevel.ToString();
        questGoldRwd.text = quest.gold.ToString();
        questExpRwd.text = quest.experience.ToString();
    }

    private void DeleteButtons()
    {
        for (int i = 0; i < questButtons.Count; i++)
        {
            Destroy(questButtons[i].gameObject);
        }
        questButtons.Clear();
    }
}