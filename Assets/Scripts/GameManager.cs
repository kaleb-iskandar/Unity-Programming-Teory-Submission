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
    [SerializeField]
    private TextMeshProUGUI playerScoreText;
    [SerializeField]
    private TextMeshProUGUI playerHealthText;
    private string playerName { get; set; }
    private int playerScore { get; set; }    
    private int playerHealth { get; set; }
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
        // ABSTRACTION
        LoadGameData();
    }
    [System.Serializable]
    class GameData
    {
        public string playerName;
        public int playerScore;
    }
    // ABSTRACTION
    public void SaveGameData()
    {
        GameData data = new GameData();
        data.playerName = playerName;
        data.playerScore = playerScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    // ABSTRACTION
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
    public void HitByEnemy(int damage)
    {
        playerHealth -= damage;
        playerHealthText.text = "Health: " + playerHealth;
    }
    public void AddPlayerHealth(int health)
    {
        playerHealth += health;
        playerHealthText.text = "Health: " + playerHealth;
    }
    public void SetPlayerHealth(int health)
    {
        playerHealth = health;
        playerHealthText.text = "Health: " + playerHealth;
    }
    public int GetPlayerHealth()
    {
        return playerHealth;
    }
    public void AddScore(int score)
    {
        playerScore += score;
        playerScoreText.text = "Score: " + playerScore;
    }
    // ABSTRACTION
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
        // ABSTRACTION
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
