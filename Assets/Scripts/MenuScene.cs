using UnityEngine;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    public Button startGameButton;
    public InputField nameText;

    private void Start()
    {
        startGameButton.interactable = false;
        if (Globals.instance.playerName != "")
        {
            nameText.text = Globals.instance.playerName;
            startGameButton.interactable = true;
        }
            
        Time.timeScale = 1;
    }
    public void OnStartGame()
    {
        Globals.instance.playerName = nameText.text;
        Globals.instance.LoadLevel(1);
    }

    public void OnTextFieldChange()
    {
        if (nameText.text.Trim().Length > 1)
        {
            startGameButton.interactable = true;
        }else
        {
            startGameButton.interactable = false;
        }
    }
}
