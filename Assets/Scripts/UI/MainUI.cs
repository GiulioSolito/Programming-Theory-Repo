using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainUI : MonoSingleton<MainUI>
{
    [SerializeField] public TextMeshProUGUI livesUI;
    [SerializeField] public TextMeshProUGUI scoreUI;
    [SerializeField] public GameObject gameOverUI;

    public void RetryGame() // ABSTRACTION
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() // ABSTRACTION
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}
