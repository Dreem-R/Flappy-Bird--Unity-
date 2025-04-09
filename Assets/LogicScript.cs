using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerscore;
    public Text scoretext;
    public GameObject gameover;

    [ContextMenu("Increase Score")]
    public void addscore(int Scoretoadd)
    {
        playerscore++;
        scoretext.text = playerscore.ToString();
    }

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameoverscreen()
    {
        gameover.SetActive(true);
    }
}
