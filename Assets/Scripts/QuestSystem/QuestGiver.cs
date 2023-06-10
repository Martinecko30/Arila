using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private TextAsset questJSON;

    public void Interact()
    {
        QuestManager.Instance.AddQuest(questJSON.text);
    }
}
