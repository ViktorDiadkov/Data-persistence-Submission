using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI recordText;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
Application.Quit();
#endif
    }

    private void Start()
    {
        GameData.Load();
        if (GameData.Instance != null && GameData.BestUser != null)
        {
            recordText.text = $"Best Score : {GameData.BestUser} : {GameData.RecordScore}";
        }
    }
}
