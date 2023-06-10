using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Quest
{
    [Header("Quest details")]
    public string questName = "Default";
    public QuestCategory questCategory = QuestCategory.MainQuest;
    public string description = "Default description";
    public int suggestedLevel = 1;

    [Header("Completion Rewards")]
    public int gold = 0;
    public int experience = 0;

    [Header("Sub Goals")]
    public List<SubGoal> subGoals = new List<SubGoal>();
}

public enum QuestCategory
{
    MainQuest,
    SecondaryQuest
}