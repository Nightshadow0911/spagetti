using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameHelperEditor : Editor
{
    GameManager gm;

    private void OnEnable()
    {
        gm = (GameManager)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.LabelField("Helper", new GUIStyle(EditorStyles.label)
        {
            alignment = TextAnchor.MiddleCenter,
        });

        if (GUILayout.Button("AddScore100"))
        {
            gm.AddScore(100);
        }
        if (GUILayout.Button("IncreaseLife"))
        {
            gm.IncreaseLife();
        }
        if (GUILayout.Button("DecreaseLife"))
        {
            gm.DecreaseLife();
        }
        if (GUILayout.Button("GameClear"))
        {
            gm.Clear();
        }
        if (GUILayout.Button("GameOver"))
        {
            gm.Over();
        }
    }
}
