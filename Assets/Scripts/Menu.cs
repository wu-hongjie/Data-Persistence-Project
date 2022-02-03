using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField playerNameInput;

    private string playerName;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = DataManager.Instance.GetBestScore();
        playerNameInput.text = DataManager.Instance.playerName;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void StartGame()
    {
        DataManager.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
