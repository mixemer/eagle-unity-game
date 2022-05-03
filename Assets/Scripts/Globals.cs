using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : Singleton<Globals>
{
    private string _playerName = "";
    private int _playerScore = 0;
    private int _grandScore = 0;
    // TODO: Add a final score that does not reset on level change and use that for high score

    public int level = 0;
    public int maxLevel = 3;

    public const string musicKey = "music";
    public const string PlayerNameKey = "playerName";
    public const string PlayerScoreKey = "playerScore";
    public const int PointToLevelUp = 10;

    public delegate void LevelUpAction();
    public static event LevelUpAction OnLevelUp;

    private void Start()
    {
        _grandScore = 0;
    }

    public int grandScore
    {
        get
        {
            return _grandScore;
        }
        set
        {
            if (value < 0) value = 0;
            _grandScore = value;
        }
    }

    public string playerName
    {
        get
        {
            if (!PlayerPrefs.HasKey(PlayerNameKey))
            {
                PlayerPrefs.SetString(PlayerNameKey, _playerName);
            }

            return PlayerPrefs.GetString(PlayerNameKey);
        }
        set
        {
            _playerName = value;
            PlayerPrefs.SetString(PlayerNameKey, _playerName);
        }
    }

    public int playerScore
    {
        get
        {
            return _playerScore;
        }
        set
        {
            if (value < 0) value = 0;
            _playerScore = value;
        }
    }

    public void AddScore()
    {
        playerScore += 1;
        grandScore += 1;
        if (playerScore >= PointToLevelUp)
        {
            if (OnLevelUp != null)
            {
                OnLevelUp();
                if (level >= maxLevel)
                {
                    SaveScore(playerName, grandScore);
                }
            }
                
        }
    }

    public void SubScore()
    {
        playerScore -= 1;
        grandScore -= 1;
    }

    public void GoHome()
    {
        playerScore = 0;
        grandScore = 0;
        level = 0;
        SceneManager.LoadScene(level);
    }

    public void Reload()
    {
        grandScore -= playerScore;
        playerScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int _level)
    {
        if (_level > maxLevel)
        {
            return;
        }

        playerScore = 0;
        level = _level;
        SceneManager.LoadScene(level);
    }

    public void NextLevel()
    {
        if (level + 1 > maxLevel)
        {
            return;
        }

        playerScore = 0;
        SceneManager.LoadScene(++level);
    }

    public const string nameKey = "Name";
    public const string scoreKey = "Score";
    public const int maxScores = 5;
    public void SaveScore(string playerName, int playerScore)
    {
        Debug.Log("SaveScore Called: " + playerName + " " + playerScore);
        for (int i = 0; i < maxScores; i++)
        {
            string currentNameKey = nameKey + i;
            string currentScoreKey = scoreKey + i;

            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);
                if (playerScore > currentScore)
                {
                    int tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentScoreKey, playerScore);

                    playerName = tempName;
                    playerScore = tempScore;
                }
            }
            else
            {
                PlayerPrefs.SetString(currentNameKey, playerName);
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                return;
            }
        }
    }
}
