using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text[] names;
    public Text[] scores;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        // fake scores
        if (!PlayerPrefs.HasKey("Score0"))
        {
            Globals.instance.SaveScore("Mehmet", 50);
            Globals.instance.SaveScore("Ali", 10);
            Globals.instance.SaveScore("An", 32);
        }

        PopulateList();
    }

    void PopulateList()
    {
        for (int i = 0; i < Globals.maxScores; i++)
        {
            string curNameKey = Globals.nameKey + i;
            string curScoreKey = Globals.scoreKey + i;
            if (PlayerPrefs.HasKey(curNameKey))
            {
                names[i].text = PlayerPrefs.GetString(curNameKey);
                scores[i].text = PlayerPrefs.GetInt(curScoreKey).ToString();
            }
            else
            {
                names[i].gameObject.SetActive(false);
                scores[i].gameObject.SetActive(false);
            }
        }
    }
}
