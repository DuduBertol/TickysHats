using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour
{
    public int allLongCoinsStorage;
    public int allLongMeters;
    public int allLongGoldCoins;
    public int allLongEnemies;
    public int achievCount;
    [SerializeField] private Text counterText;
    [SerializeField] private Text counterText2;
    [SerializeField] private Text counterText3;
    [SerializeField] public float percentualProgress;
    [SerializeField] private Text percentualProgressText;
    
    public List<bool> isAchieved = new List<bool>();
    public List<int> isAchievedValue = new List<int>();
    public List<GameObject> markers = new List<GameObject>(); // markers são os marcadores que indicam se ele conquistou ou não o achiev.


    private GameManager gameManager;
    private ButtonAudioManager buttonAudioManager;
    private GeneralInfos generalInfos;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
        generalInfos = FindObjectOfType<GeneralInfos>();
        LoadPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        MarkerManager();
        CoinsAchievements();
        MetersAchievements();
        GoldCoinsAchievements();
        EnemyAchievements();
        PurchaseAchievements();
        PercentualProgress();
        SavePlayerPrefs();
    }

    private void MarkerManager()
    {
        for(int i = 0; i < isAchieved.Count; i++)
        {
            if(isAchieved[i])
            {
                markers[i].SetActive(true);
                isAchievedValue[i] = 1;
            }
        }

        if(achievCount > 18)
        {
            achievCount = 18;
        }
        counterText.text = "( " + achievCount.ToString() + " / 18 )";
        counterText2.text = counterText.text;
        counterText3.text = counterText.text;
    }

    private void CoinsAchievements()
    {
        PlayerPrefs.SetInt("AllLongCoins", allLongCoinsStorage);

        //COINS ACHIEVEMENTS
        if(allLongCoinsStorage >= 1000 && !isAchieved[0]) // Partidas para alcançar: 20
        {
            isAchieved[0] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
        if(allLongCoinsStorage >= 4000 && !isAchieved[1]) // Partidas para alcançar: 80
        {
            isAchieved[1] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
        if(allLongCoinsStorage >= 10000 && !isAchieved[2]) // Partidas para alcançar: 200
        {
            isAchieved[2] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
        if(allLongCoinsStorage >= 20000 && !isAchieved[3]) // Partidas para alcançar: 400
        {
            isAchieved[3] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
    }

    private void MetersAchievements()
    {
        PlayerPrefs.SetInt("AllLongMeters", allLongMeters);

        //METERS ACHIEVEMENTS
        if(allLongMeters >= 3000 && !isAchieved[4]) // Partidas para alcançar: 20
        {
            isAchieved[4] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
        if(allLongMeters >= 10000 && !isAchieved[5]) // Partidas para alcançar: 65
        {
            isAchieved[5] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
        if(allLongMeters >= 25000 && !isAchieved[6]) // Partidas para alcançar: 160
        {
            isAchieved[6] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
        if(allLongMeters >= 50000 && !isAchieved[7]) // Partidas para alcançar: 320
        {
            isAchieved[7] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
    }

    private void GoldCoinsAchievements()
    {
        PlayerPrefs.SetInt("AllLongGoldCoins", allLongGoldCoins);

        //GOLD COINS ACHIEVEMENTS
        if(allLongGoldCoins >= 100 && !isAchieved[8]) // Partidas para alcançar: 20
        {
            isAchieved[8] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
        if(allLongGoldCoins >= 400 && !isAchieved[9]) // Partidas para alcançar: 80
        {
            isAchieved[9] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
        if(allLongGoldCoins >= 1000 && !isAchieved[10]) // Partidas para alcançar: 200
        {
            isAchieved[10] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
        if(allLongGoldCoins >= 2000 && !isAchieved[11]) // Partidas para alcançar: 400
        {
            isAchieved[11] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
    }

    private void EnemyAchievements()
    {
        PlayerPrefs.SetInt("AllLongEnemies", allLongEnemies);

        //ENEMIES ACHIEVEMENTS
        if(allLongEnemies >= 25 && !isAchieved[12]) // Partidas para alcançar: 50
        {
            isAchieved[12] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }

        if(allLongEnemies >= 100 && !isAchieved[13]) // Partidas para alcançar: 200
        {
            isAchieved[13] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }

        if(allLongEnemies >= 250 && !isAchieved[14]) // Partidas para alcançar: 500
        {
            isAchieved[14] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }

        if(allLongEnemies >= 500 && !isAchieved[15]) // Partidas para alcançar: 1000
        {
            isAchieved[15] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
    }

    private void PurchaseAchievements()
    {
        //HATS
        if(generalInfos.hatsPurchased >= 12 && !isAchieved[16])
        {
            isAchieved[16] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        } 

        //SCENARIOS
        if(generalInfos.scenariosPurchased >= 4 && !isAchieved[17])
        {
            isAchieved[17] = true;
            achievCount++;
            percentualProgress += 5.5f; 
            buttonAudioManager.AchievementSound();
        }
    }

    private void PercentualProgress()
    {
        if(percentualProgress > 93.5)
        {
            percentualProgress = 100f;
        }
        percentualProgressText.text = percentualProgress.ToString() + "% COMPLETE";
        PlayerPrefs.SetFloat("PercentualProgress", percentualProgress);
    }

    #region PlayerPrefsConfig
    //PlayerPrefs salvando os valores bools
    public bool IntToBool (int a)
        {
            if(a != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    public int BoolToInt (bool b)
        {
            if(b)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    private void LoadPlayerPrefs()
    {
        achievCount = PlayerPrefs.GetInt("achievCount");
        allLongCoinsStorage = PlayerPrefs.GetInt("AllLongCoins");
        allLongMeters = PlayerPrefs.GetInt("AllLongMeters");
        allLongGoldCoins = PlayerPrefs.GetInt("AllLongGoldCoins");
        allLongEnemies = PlayerPrefs.GetInt("AllLongEnemies");
        percentualProgress = PlayerPrefs.GetFloat("PercentualProgress");

        isAchieved[0] = IntToBool(PlayerPrefs.GetInt("IsAchieved0"));
        isAchieved[1] = IntToBool(PlayerPrefs.GetInt("IsAchieved1"));
        isAchieved[2] = IntToBool(PlayerPrefs.GetInt("IsAchieved2"));
        isAchieved[3] = IntToBool(PlayerPrefs.GetInt("IsAchieved3"));
        isAchieved[4] = IntToBool(PlayerPrefs.GetInt("IsAchieved4"));
        isAchieved[5] = IntToBool(PlayerPrefs.GetInt("IsAchieved5"));
        isAchieved[6] = IntToBool(PlayerPrefs.GetInt("IsAchieved6"));
        isAchieved[7] = IntToBool(PlayerPrefs.GetInt("IsAchieved7"));
        isAchieved[8] = IntToBool(PlayerPrefs.GetInt("IsAchieved8"));
        isAchieved[9] = IntToBool(PlayerPrefs.GetInt("IsAchieved9"));
        isAchieved[10] = IntToBool(PlayerPrefs.GetInt("IsAchieved10"));
        isAchieved[11] = IntToBool(PlayerPrefs.GetInt("IsAchieved11"));
        isAchieved[12] = IntToBool(PlayerPrefs.GetInt("IsAchieved12"));
        isAchieved[13] = IntToBool(PlayerPrefs.GetInt("IsAchieved13"));
        isAchieved[14] = IntToBool(PlayerPrefs.GetInt("IsAchieved14"));
        isAchieved[15] = IntToBool(PlayerPrefs.GetInt("IsAchieved15"));
        isAchieved[16] = IntToBool(PlayerPrefs.GetInt("IsAchieved16"));
        isAchieved[17] = IntToBool(PlayerPrefs.GetInt("IsAchieved17"));
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("achievCount", achievCount);

        if(isAchieved[0])
        {
            PlayerPrefs.SetInt("IsAchieved0", isAchievedValue[0]);
        }
        if(isAchieved[1])
        {
            PlayerPrefs.SetInt("IsAchieved1", isAchievedValue[1]);
        }
        if(isAchieved[2])
        {
            PlayerPrefs.SetInt("IsAchieved2", isAchievedValue[2]);
        }
        if(isAchieved[3])
        {
            PlayerPrefs.SetInt("IsAchieved3", isAchievedValue[3]);
        }
        if(isAchieved[4])
        {
            PlayerPrefs.SetInt("IsAchieved4", isAchievedValue[4]);
        }
        if(isAchieved[5])
        {
            PlayerPrefs.SetInt("IsAchieved5", isAchievedValue[5]);
        }
        if(isAchieved[6])
        {
            PlayerPrefs.SetInt("IsAchieved6", isAchievedValue[6]);
        }
        if(isAchieved[7])
        {
            PlayerPrefs.SetInt("IsAchieved7", isAchievedValue[7]);
        }
        if(isAchieved[8])
        {
            PlayerPrefs.SetInt("IsAchieved8", isAchievedValue[8]);
        }
        if(isAchieved[9])
        {
            PlayerPrefs.SetInt("IsAchieved9", isAchievedValue[9]);
        }
        if(isAchieved[10])
        {
            PlayerPrefs.SetInt("IsAchieved10", isAchievedValue[10]);
        }
        if(isAchieved[11])
        {
            PlayerPrefs.SetInt("IsAchieved11", isAchievedValue[11]);
        }
        if(isAchieved[12])
        {
            PlayerPrefs.SetInt("IsAchieved12", isAchievedValue[12]);
        }
        if(isAchieved[13])
        {
            PlayerPrefs.SetInt("IsAchieved13", isAchievedValue[13]);
        }
        if(isAchieved[14])
        {
            PlayerPrefs.SetInt("IsAchieved14", isAchievedValue[14]);
        }
        if(isAchieved[15])
        {
            PlayerPrefs.SetInt("IsAchieved15", isAchievedValue[15]);
        }
        if(isAchieved[16])
        {
            PlayerPrefs.SetInt("IsAchieved16", isAchievedValue[16]);
        }
        if(isAchieved[17])
        {
            PlayerPrefs.SetInt("IsAchieved17", isAchievedValue[17]);
        }
    }
    
    #endregion
    
}
