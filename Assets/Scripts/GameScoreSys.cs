using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameScoreSys : MonoBehaviour
{
    public static GameScoreSys Instance;
    public string PlayerName {get ; private set;} = "Guest"; //for default name
    public int PlayerScore {get; private set; }

    public int BestScore { get; private set; }

    //private string lastPlayerName = ""; // using this to store the last player name.

    // Start is called before the first frame update
    
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string newName)
    {
        PlayerName = newName;
        //PlayerScore = 0;
    }

     public void Score(int points)
    {
        PlayerScore += points; 

        if (PlayerScore > BestScore)
        {
            BestScore = PlayerScore;
        }
    }

    public void ResetScore()
    {
        PlayerScore = 0;
    }

    
    // SAVING the Data
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveUserInfo()
    {
        SaveData data = new SaveData();
        //values that need to be saved
        data.playerName = PlayerName;
        data.bestScore = BestScore;

        string json = JsonUtility.ToJson(data); // what needs to be converted to json

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json); // where and under what name data is stored, path to the json 

        Debug.Log($"Saved Data: Player: {PlayerName}, Best Score: {BestScore}");
    }

    public void LoadUserInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.playerName;
            BestScore = data.bestScore;


            Debug.Log($"Loaded Data: Player: {PlayerName}, Best Score: {BestScore}");
        }
        else
        {
            Debug.Log("No save file found, starting fresh.");
        }
    }

}
