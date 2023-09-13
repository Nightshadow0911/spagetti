using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SceneWindow : EditorWindow
{
    private const string PATH = "Assets/Scenes/";

    private SceneType _sceneType;

    [MenuItem("Helper/SceneWindow")]
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(SceneWindow));
        window.maximized = true;
        window.Show();
    }


    private void OnGUI()
    {
        _sceneType = (SceneType)EditorGUILayout.EnumPopup(_sceneType, new GUIStyle(EditorStyles.popup) 
        { 
            alignment = TextAnchor.MiddleCenter,
        });

        if (GUILayout.Button("¿Ãµø"))
        {
            if (Application.isPlaying)
            {
                SceneFader.Instance.FadeToScene((int)_sceneType);
            }
            else
            {
                EditorSceneManager.OpenScene($"{PATH}{_sceneType}.unity");
            }

        }
        
        if (!Application.isPlaying && GUI.changed)
        {
            EditorUtility.SetDirty(this);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
