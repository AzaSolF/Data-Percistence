using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEditor;


public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text updateScore;
    public TextMeshProUGUI displayPlayer;
    

    public GameObject GameOverText;
    
    private bool m_Started = false;
    public int m_Points;
    
    private bool m_GameOver = false;

    public Button menuButton;
    public Button resetButton;
    public Button exitGame;

    public int highScore;
    public string nameScorePlayer;

    private bool paused;
    public GameObject pausedScreen;
    
    // Start is called before the first frame update

    private void Awake()
    {
        LoadName();
        LoadScore();
        DisplayBestScore();
    }

    void Start()
    {
  

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        

        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }

        if (m_GameOver)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangePaused();
        }

    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
        DisplayBestScore();
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        
        Debug.Log("Score of player " + Scene1.menu.playerName + " is " + m_Points);

        if (m_Points > highScore)
        {
            highScore = m_Points;
            nameScorePlayer = Scene1.menu.playerName;
            Debug.Log("Congratulations " + nameScorePlayer + " your score of  " + highScore + "  is the very high");
        }
        else
        {
            HighScore();
            updateScore.text = nameScorePlayer;
        }

        DisplayBestScore();
        SaveScore();
        
    }

    public void Menu()
    {
        
        SceneManager.LoadScene(0);
        
    }

    
    public void LoadName()
    {
        displayPlayer.text = "Playing  " +  Scene1.menu.playerName;
        
    }

    public void HighScore()
    {
        m_Points = highScore;
    }

    public void DisplayBestScore()
    {
        updateScore.text = nameScorePlayer + $"   {highScore}";
        
    }

    public void ResetScore()
    {
        highScore = 0;
        DisplayBestScore();
        SaveScore();
    }

    public void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pausedScreen.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            paused = false;
            pausedScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string nameScorePlayer;
    }

    public void ExitGame()
    {

#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();
#else
    Application.Quit(); // original code to quit Unity Player
    

#endif
    }

    public void SaveScore()
    {
        
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.nameScorePlayer = nameScorePlayer;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            nameScorePlayer = data.nameScorePlayer;

            Debug.Log(nameScorePlayer);
        }

    }

    
}




