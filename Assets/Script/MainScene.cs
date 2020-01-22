using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Text hScore;
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    private void Start()
    {
        hScore.text = "HighScore : " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}