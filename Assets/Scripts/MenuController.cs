using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField NameInput;
    [SerializeField] private TextMeshProUGUI TitleText;

    // Start is called before the first frame update
    void Start()
    {
        TitleText.SetText(string.Format("Best Score : {0} : {1}", DataPersistance.Instance.BestScorePlayer, DataPersistance.Instance.BestScorePoints));
        NameInput.text = DataPersistance.Instance.BestScorePlayer;
    }

    public void StartNew()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void SetPlayerName()
    {
        DataPersistance.Instance.PlayerName = NameInput.text;
    }
}
