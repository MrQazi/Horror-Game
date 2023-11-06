using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class ManagerEditro : Editor {
    public int level;
    public override void OnInspectorGUI() {
        var l = level;
        level = EditorGUILayout.IntField("Level", level);
        if (l != level) {
            GameManager.CurrentLevel = level;
        }
        base.OnInspectorGUI();
    }
}
#endif
public class GameManager : MonoBehaviour {
    public GameObject CompletePanel;

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Next() {
        CurrentLevel++;
        Restart();
    }
    public List<Level> levels;
    public static int CurrentLevel {
        get => PlayerPrefs.GetInt("CurrentLevel", 0);
        set => PlayerPrefs.SetInt("CurrentLevel", value);
    }
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start() {
        CurrentLevel %= levels.Count;
        levels[CurrentLevel].gameObject.SetActive(true);
    }


    public void LevelComplete() {
        CompletePanel.SetActive(true);
    }
}
