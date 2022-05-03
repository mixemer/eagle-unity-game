using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicUI : MonoBehaviour
{
    public bool isMusicOn = true;
    public GameObject MusicOn;
    public GameObject MusicOff;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(Globals.musicKey))
        {
            isMusicOn = PlayerPrefs.GetInt(Globals.musicKey) == 1 ? true : false;
        }
        else
        {
            PlayerPrefs.SetInt(Globals.musicKey, 1);
        }

        UpdateMusic(isMusicOn);
    }

    public void OnMusicOn()
    {
        UpdateMusic(false);
    }

    public void OnMusicOff()
    {
        UpdateMusic(true);
    }

    void UpdateMusic(bool val)
    {
        isMusicOn = val;
        PlayerPrefs.SetInt(Globals.musicKey, isMusicOn ? 1 : 0);
        MusicOn.SetActive(isMusicOn);
        MusicOff.SetActive(!isMusicOn);

        AudioListener.volume = isMusicOn ? 1 : 0;
    }
}
