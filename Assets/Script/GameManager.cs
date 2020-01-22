using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject food;
    public GameObject panel;
    public GameObject player;
    public List<Color> color;
    public int[] point;
    public int score = 0;
    public int streak = 1;
    public Text scoreText;
    public Text streakText;
    public TextAsset textFile;     // drop your file here in inspector
    int current_index;
    int prev_index;
    //public int point;
    public List<string> textArray;

    private void Awake()
    {
        SetFoodProperty();
    }

    void Start()
    {
        spawnFood();
    }

    public void SetFoodProperty()
    {
        textArray = textFile.text.Split('\n').ToList();
        //color = new List<Color>[textArray.Count];
        point = new int[textArray.Count];
        for (int i=0; i <textArray.Count; i++)
        {
            string[] s;
            s = textArray[i].Split(' ');
            Color MyColour = Color.clear;
            ColorUtility.TryParseHtmlString(s[0], out MyColour);
            color.Add(MyColour);
            point[i] = int.Parse(s[1]);
        }
        
    }

    public void spawnFood()
    {
        food = Instantiate(foodPrefab);
        food.transform.position = new Vector3(Random.Range(-3.5f, 4.5f), food.transform.position.y, Random.Range(-2.5f, 2.8f));
        current_index = Random.Range(0, point.Length);
        food.GetComponent<MeshRenderer>().material.color = color[current_index];
    }

    public void OnScore()
    {
        if(prev_index == current_index)
        {
            streakText.text = "Streak x " + streak.ToString();
            streak += 1;
        }
        else
        {
            streak = 1;
            streakText.text = "Streak x 0";
        }
        score = score + (point[current_index]*streak);
        scoreText.text = "Score :" + score.ToString();
        prev_index = current_index;
    }
    public void onPlayerDied()
    {
        panel.SetActive(true);
        player.SetActive(false);
        panel.transform.GetChild(0).GetComponent<Text>().text = "Your Score :" + score.ToString();

        int hScore = PlayerPrefs.GetInt("HighScore");

        if (score > hScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

    }
    public void onGameOver()
    {
        SceneManager.LoadScene(0);
    }
}
