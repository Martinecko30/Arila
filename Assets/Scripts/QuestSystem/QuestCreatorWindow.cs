using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEditor;
using UnityEngine;

public class QuestCreatorWindow : EditorWindow
{
    [MenuItem("Window/Quest Creator Window")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(QuestCreatorWindow));
    }

    void OnGUI()
    {
        Quest quest = new Quest();

        string questName = "Default";
        QuestCategory questCategory = QuestCategory.MainQuest;
        string description = "Default description";
        int suggestedLevel = 3;

        int gold = 10;
        int experience = 20;

        List<SubGoal> subGoals = new List<SubGoal>();



        GUILayout.Label("Quest Settings", EditorStyles.boldLabel);
        questName = EditorGUILayout.TextField("Quest Name", questName);
        description = EditorGUILayout.TextField("Quest Description", description);
        questCategory = (QuestCategory)EditorGUILayout.EnumPopup("Quest Category", questCategory);
        suggestedLevel = EditorGUILayout.IntField("Suggested Level", suggestedLevel);
        gold = EditorGUILayout.IntField("Gold reward", gold);
        experience = EditorGUILayout.IntField("Experience reward", experience);

        int subGoalCount = 1;
        subGoalCount = EditorGUILayout.IntField("Count of sub goals", subGoalCount);

        /*
        for(int i = 0; i < subGoalCount; i++)
        {
            string subName = "Default";
            string subDescription = "Default description";
            Vector2 goalPosition = Vector2.zero;
            bool useRadius = true;
            float radius = 16;
            Color circleColor = Color.white;

            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            subName = EditorGUILayout.TextField("Sub Name", subName);
            subDescription = EditorGUILayout.TextField("Sub Description", subDescription);
            goalPosition = EditorGUILayout.Vector2Field("Location", goalPosition);
            useRadius = EditorGUILayout.Toggle("Use radius", true);
            radius = EditorGUILayout.FloatField("Radius", 16);
            circleColor = EditorGUILayout.ColorField("Radius color", Color.white);

            subGoals[i].subName = subName;
            subGoals[i].subDescription = subDescription;
            subGoals[i].goalPosition = goalPosition;
            subGoals[i].useRadius = useRadius;
            subGoals[i].radius = radius;
            subGoals[i].circleColor = circleColor;
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }*/




        if (GUILayout.Button("Create"))
        {
            quest.questName = questName;
            quest.description = description;
            quest.suggestedLevel = suggestedLevel;
        }
    }
}
