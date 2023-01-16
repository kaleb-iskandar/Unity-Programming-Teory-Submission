using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private TMP_InputField playerNameInput;
    private string playerName { get; set; }
    private int playerScore { get; set; }

    private GameData gameData { get; set; }
    void Awake()
    {
        if (Instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();
    }
    [System.Serializable]
    class GameData
    {
        public string playerName;
        public int playerScore;
    }
    public void SaveGameData()
    {
        GameData data = new GameData();
        data.playerName = playerName;
        data.playerScore = playerScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            gameData = data;
        }
    }
    bool IsPlayerNameSet()
    {
        if (playerNameInput.text.Length > 0)
        {
            playerName = playerNameInput.text;
            return true;
        }
        else
        {
            Debug.LogWarning("PlayerName input field cannot be empty!");
            return false;
        }
    }
    public void Play()
    {
        if (IsPlayerNameSet())
        {
            SceneManager.LoadScene(1);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
