using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MainMenuUi : MonoBehaviour
{
    private TMP_InputField nameInput;
    [SerializeField] private TextMeshProUGUI showUser;
    
    // Start is called before the first frame update
    void Start()
    {
        nameInput = GetComponentInChildren<TMP_InputField>();
        showUser = GetComponentInChildren<TextMeshProUGUI>();
        //showUser = GameObject.Find("UserHighScore").GetComponent<TextMeshProUGUI>();
        //ShowUserInfo();
    }

    public void StoreName()
    {
        if(!string.IsNullOrEmpty(nameInput.text))
        {
            GameScoreSys.Instance.SetPlayerName(nameInput.text);
            Debug.Log("Name Stored Woop" + nameInput.text);
            ShowUserInfo();
        }
    }

    public void StartGame()
    {
        
        //StoreName();
        
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        if(EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    public void SaveUserName()
    {
        GameScoreSys.Instance.SaveUserInfo();
    }

    public void LoadUserName()
    {
        GameScoreSys.Instance.LoadUserInfo();
        //GameScoreSys.Instance.SetPlayerName(nameInput.text);
        ShowUserInfo();

    }
    
    private void ShowUserInfo()
    {
        if(showUser != null && GameScoreSys.Instance != null)
        {
            showUser.text = $"Best Score: {GameScoreSys.Instance.BestScore} Player: {GameScoreSys.Instance.PlayerName}";
        }
    }

}
