using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject WinPanel;
    public Button NextLevelButton;
    public Text Detail;

    private void Start()
    {
        OnResume();
        if (Globals.instance.level == Globals.instance.maxLevel)
        {
            Detail.text = "Last Level";
            NextLevelButton.interactable = false;
        }
    }

    private void OnEnable()
    {
        Globals.OnLevelUp += OnShowWinPanel;
    }

    private void OnDisable()
    {
        Globals.OnLevelUp -= OnShowWinPanel;
    }

    void OnShowWinPanel()
    {
        OnPause();
        WinPanel.SetActive(true);
    }

    public void OnReloadScene()
    {
        OnResume();
        Globals.instance.Reload();
    }
    public void OnReturnMenu()
    {
        Globals.instance.GoHome();
    }
    public void OnNextLevel()
    {
        Globals.instance.NextLevel();
    }
    public void OnPause()
    {
        //Debug.Log("OnPause Called");
        Time.timeScale = 0;
    }
    public void OnResume()
    {
        //Debug.Log("OnResume Called");
        Time.timeScale = 1;
    }
}
