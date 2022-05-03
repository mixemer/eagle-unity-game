using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text Score;
    /*public Text Name;*/
    public Text Level;

    private void Start()
    {
        /*Name.text = Globals.instance.playerName;*/
    }

    private void Update()
    {
        Score.text = Globals.instance.playerScore.ToString();
        Level.text = Globals.instance.level.ToString();
    }
}
