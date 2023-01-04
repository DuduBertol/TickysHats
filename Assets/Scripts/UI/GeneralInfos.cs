using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralInfos : MonoBehaviour
{
    [Header("TEXTS")]
    [SerializeField] private List<Text> generalInfosTexts = new List<Text>();

    [Header("Values")]
    public int gamesPlayed;
    public int hatsPurchased;
    public int scenariosPurchased;
    public int allLongScores;

    private AchievementsManager achievementsManager;
    private GameManager gameManager;
    void Start()
    {
        achievementsManager = FindObjectOfType<AchievementsManager>();
        gameManager = FindObjectOfType<GameManager>();
        LoadInfos();
        InfoUpdater();
    }

    private void InfoUpdater()
    {
        generalInfosTexts[0].text = "GAMES PLAYED: " + gamesPlayed.ToString();

        generalInfosTexts[1].text = "COINS COLLECTED: " + achievementsManager.allLongCoinsStorage.ToString();

        generalInfosTexts[2].text = "GOLD COINS COLLECTED: " + achievementsManager.allLongGoldCoins.ToString();

        generalInfosTexts[3].text = "HATS PURCHASED: " + hatsPurchased.ToString();

        generalInfosTexts[4].text = "SCENARIOS PURCHASED: " + scenariosPurchased.ToString();
        
        generalInfosTexts[5].text = "ENEMIES DEFEATED: " + achievementsManager.allLongEnemies;

        generalInfosTexts[6].text = "RUNNING METERS: " + achievementsManager.allLongMeters;

        generalInfosTexts[7].text = "HIGHMETERS: " + gameManager.highMeters;

        generalInfosTexts[8].text = "ALL SCORES: " + allLongScores.ToString();

        generalInfosTexts[9].text = "HIGHSCORE: " + gameManager.highScore;
    }

    public void SaveInfos()
    {
        PlayerPrefs.SetInt("gamesPlayed",gamesPlayed);
        PlayerPrefs.SetInt("hatsPurchased", hatsPurchased);
        PlayerPrefs.SetInt("scenarioPurchased", scenariosPurchased);
        PlayerPrefs.SetInt("allScores", allLongScores);
    }

    private void LoadInfos()
    {
        gamesPlayed = PlayerPrefs.GetInt("gamesPlayed");
        hatsPurchased = PlayerPrefs.GetInt("hatsPurchased");
        scenariosPurchased = PlayerPrefs.GetInt("scenarioPurchased");
        allLongScores = PlayerPrefs.GetInt("allScores");
    }

}
