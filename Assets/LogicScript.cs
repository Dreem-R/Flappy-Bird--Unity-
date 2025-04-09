using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerscore;
    public Text scoretext;
    public GameObject gameover;
    public Text scoredisplay;
    public Text highestscored;
    public int highscore;

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
        loadhighscore();
        scoredisplay.text = "Current Score : " + playerscore.ToString();
        if (playerscore > highscore)
        {
            Savehighscore();
        }
        highestscored.text = "Highest Score : " + highscore.ToString();
        gameover.SetActive(true);
    }

    private void loadhighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    private void Savehighscore()
    {
        PlayerPrefs.SetInt("Highscore",playerscore);
        PlayerPrefs.Save();
    }
}
