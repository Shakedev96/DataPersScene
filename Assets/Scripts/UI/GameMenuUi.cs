using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuUi : MonoBehaviour
{
    [SerializeField] private Text playerNameText;
    
    

    void Start()
    {
        if(GameScoreSys.Instance != null && playerNameText != null)
        {
            playerNameText.text = "Best Scrore: " + GameScoreSys.Instance.BestScore + " Player: " + GameScoreSys.Instance.PlayerName;
            //GameScoreSys.Instance.SaveUserInfo();
        }
        //GameScoreSys.Instance.SaveUserInfo();
    }
    
        public void BackToMenu()
    {
        GameScoreSys.Instance.SaveUserInfo(); // to save before going back the menu scene
        SceneManager.LoadScene(0);
    }
}

