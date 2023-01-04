using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("In Game Canvas")]
    [SerializeField] private GameObject canvasPause;
    [SerializeField] private GameObject canvasGameOver;
    [SerializeField] private GameObject canvasGame;
    [SerializeField] private GameObject canvasStartScreen;
    [SerializeField] private GameObject canvasOptions;
    [SerializeField] private GameObject canvasCredits;
    [SerializeField] private GameObject canvasAllHats;
    [SerializeField] private GameObject canvasAboutMe;
    [SerializeField] private GameObject canvasTutorial;
    [SerializeField] private GameObject canvasLeaderboard;
    [SerializeField] private GameObject canvasAchievements;
    [SerializeField] private GameObject canvasLeaderAchiev;
    [SerializeField] private GameObject canvasNextPgAchiev;
    [SerializeField] private GameObject canvasNextPgAchiev2;
    [SerializeField] private GameObject canvasPauseCountdown;
    [SerializeField] private GameObject canvasGeneralInfos;
    [SerializeField] private GameObject canvasPlatineGame;
    [SerializeField] private GameObject canvasMoreCoins;
    [SerializeField] public  GameObject panelDoubleCoins;
    [SerializeField] public  GameObject imageShowCoinsAd;

    [Header("Game Components")]
    public bool gameStarted;
    public bool isPaused;
    public int coinAmount;
    public int totalCoinAmount;
    public int meters;
    public int highMeters;
    public int score;
    public int highScore;
    public Transform playerPos;
    [SerializeField] private bool EnableTutorial;
    [SerializeField] private int EnableTutorialValue;
    [SerializeField] private bool DisableTutorial;
    [SerializeField] private int DisableTutorialValue;
    [SerializeField] public bool EnableAudio;
    [SerializeField] private int EnableAudioValue;
    [SerializeField] public bool DisableAudio;
    [SerializeField] private int DisableAudioValue;

    [Header("UI Elements")]
    [SerializeField] private Text coinAmountText;
    [SerializeField] private Text totalCoinAmountText;
    [SerializeField] private Text totalCoinAmountText2;
    [SerializeField] private Text totalCoinAmountTextPause;
    [SerializeField] private Text metersTextGame;
    [SerializeField] private Text highMetersTextPause;
    [SerializeField] private Text moreXMeters;
    [SerializeField] private Image highMetersBar;
    [SerializeField] private Image highMeterCheck;
    [SerializeField] private Text scoreGO;
    [SerializeField] private Text scoreGame;
    [SerializeField] private Text highScoreGO;
    [SerializeField] private Image highScoreCheck;
    [SerializeField] private Text newHighScoreText;
    [SerializeField] private Text highScorePause;
    [SerializeField] private Text highScoreStart;
    [SerializeField] private Button starButton;
    [SerializeField] private Button starButton2;
    [SerializeField] private AudioClip platineMusic;
    [SerializeField] private AudioSource platineAudioSource;
    [SerializeField] private Text coinAmountAdText;
    public Image displayCoinsAd;
    public Button buttonPlayAdGO;


    [Header("References")]
    private Player player;
    private AchievementsManager achievementsManager;
    private AudioManager audioManager;
    public Hats hats;
    public Leaderboard leaderboard;
    public LeaderboardAchiev leaderboardAchiev;
    private ButtonAudioManager buttonAudioManager;
    public GeneralInfos generalInfos;
    public Animator starAnim;

    // Start is called before the first frame update

    private void Awake() 
    {
        LoadPlayerPrefs();
        player = FindObjectOfType<Player>();
        audioManager = FindObjectOfType<AudioManager>();
        achievementsManager = FindObjectOfType<AchievementsManager>();
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();

        if(EnableAudio || !DisableAudio)
        {
            audioManager.generalAudioSource.mute = false;
            audioManager.randomNumber = Random.Range(0, 2);
            if(audioManager.randomNumber < 1f)
            {
                audioManager.generalAudioSource.clip = audioManager.startAudioList[0].clip;
                audioManager.generalAudioSource.Play();
            }
            else
            {
                audioManager.generalAudioSource.clip = audioManager.startAudioList[1].clip;
                audioManager.generalAudioSource.Play();
            }
        }

        gameStarted = false;
        isPaused = true;
        Time.timeScale = 1;

        totalCoinAmount = PlayerPrefs.GetInt("coinAmountSaved");

        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreStart.text = highScore.ToString() + " PTS.";

        highMeters = PlayerPrefs.GetInt("HighMeters");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isDeath)
        {
            GameOver();
            StartCoroutine(AddScoreRoutine());
            StartCoroutine(AddAchievRoutine());
        }
        HighScoresManager();
        PlatineGameCheck();
        generalInfos.SaveInfos();

        if(EnableAudio || !DisableAudio)
        {
            buttonAudioManager.playerSFX.mute = false;
            buttonAudioManager.coinAudioSource.mute = false;
            buttonAudioManager.audioSourceButton.mute = false;
            audioManager.generalAudioSource.mute = false;
        }
        else if(DisableAudio)
        {
            buttonAudioManager.playerSFX.mute = true;
            buttonAudioManager.coinAudioSource.mute = true;
            buttonAudioManager.audioSourceButton.mute = true;
            audioManager.generalAudioSource.mute = true;
        }
    }
    
    IEnumerator AddScoreRoutine()
    {
        yield return leaderboard.SubmitScoreRoutine(highScore);
    }

    IEnumerator AddAchievRoutine()
    {
        yield return leaderboardAchiev.SubmitScoreRoutine(achievementsManager.achievCount);
    }

    private void HighScoresManager()
    {
        coinAmountAdText.text = "COINS = " + coinAmount.ToString() + "\n\n" + "2x = " + (coinAmount * 2).ToString();

        coinAmountText.text = coinAmount.ToString();
        totalCoinAmountText.text = totalCoinAmount.ToString();
        totalCoinAmountTextPause.text = coinAmount.ToString();
        totalCoinAmountText2.text = totalCoinAmount.ToString();

        PlayerPrefs.SetInt("coinAmountSaved", totalCoinAmount);

        meters = ((int)playerPos.position.x);
        metersTextGame.text = meters.ToString() + " m";
        highMetersTextPause.text = highMeters.ToString() + " m";

        if(meters >= highMeters)
        {
            highMeterCheck.transform.eulerAngles = new Vector2 (0, 0);
            highMetersBar.gameObject.SetActive(true);
        }
        else
        {
            highMeterCheck.transform.eulerAngles = new Vector3 (0, 0, -90);
        }
        if(highMeters - meters >= 0)
        {
            moreXMeters.text = "MORE " + (highMeters - meters).ToString() + "m";
        }

         score = meters * coinAmount / 2;
         scoreGame.text = score.ToString();
    }

    #region Buttons
    public void OnPause()
    {
        isPaused = true;
        Time.timeScale = 0;
        canvasPause.SetActive(true);
        highScorePause.text = highScore.ToString() + " PTS";
    }

    public void Resume()
    {
        canvasPause.SetActive(false);
        canvasPauseCountdown.SetActive(true);
    }

    public void PauseCountdown()
    {
                isPaused = false;
                Time.timeScale = 1;
                canvasPauseCountdown.SetActive(false);
    }

    public void GameOver()
    {
        isPaused = true;
        Time.timeScale = 0;
        canvasGameOver.SetActive(true);
        audioManager.generalAudioSource.clip = null;

        if(score > highScore)
        {
            highScore = score;
            highScoreCheck.transform.eulerAngles = new Vector3 (0, 0, 0);
            newHighScoreText.enabled = true;
        }
        scoreGO.text = "SCORE: " + meters.ToString() + " m X " + coinAmount.ToString() + " COINS = " + scoreGame.text + " PTS";
        highScoreGO.text = "HIGHSCORE: " + highScore.ToString() + " PTS.";
        PlayerPrefs.SetInt("HighScore", highScore);

        if(meters >= highMeters)
        {
            highMeters = meters;
        }
        PlayerPrefs.SetInt("HighMeters", highMeters);
    }

    public void Restart()
    {
        achievementsManager.allLongMeters += meters;
        generalInfos.allLongScores += score;
        generalInfos.gamesPlayed ++;
        SceneManager.LoadScene("SampleScene");
    }

    public void NewGame()
    {
        isPaused = false;
        gameStarted = true;
        canvasStartScreen.SetActive(false);
        canvasGame.SetActive(true);

        if(EnableTutorial)
        {
            canvasTutorial.SetActive(true);
        }
        if(DisableTutorial && !EnableTutorial)
        {
            canvasTutorial.SetActive(false);
        }

        //AUDIO
        if(EnableAudio || !DisableAudio)
        {
            audioManager.randomNumber = Random.Range(0, 3);
            if(audioManager.randomNumber < 1f)
            {
                audioManager.generalAudioSource.clip = audioManager.gameAudioList[0].clip;
                audioManager.generalAudioSource.Play();
            }
            else if (audioManager.randomNumber < 2f)
            {
                audioManager.generalAudioSource.clip = audioManager.gameAudioList[1].clip;
                audioManager.generalAudioSource.Play();
            }
            else
            {
                audioManager.generalAudioSource.clip = audioManager.gameAudioList[2].clip;
                audioManager.generalAudioSource.Play();
            }
        }
    }

    public void Options()
    {
        canvasOptions.SetActive(true);
    }

    public void Return()
    {
        canvasOptions.SetActive(false);
        canvasLeaderboard.SetActive(false);
        canvasGeneralInfos.SetActive(false);
        canvasMoreCoins.SetActive(false);
    }

    public void Quit() 
    {
        Application.Quit();
    }

    public void Credits()
    {
        canvasCredits.SetActive(true);
    }

    public void ReturnCredits()
    {
        canvasCredits.SetActive(false);
    }

    public void AllHats()
    {
        canvasAllHats.SetActive(true);
    }

    public void ReturnAllHats()
    {
        canvasAllHats.SetActive(false);
    }

    public void AboutMe()
    {
        canvasAboutMe.SetActive(true);
    }

    public void ReturnAboutMe()
    {
        canvasAboutMe.SetActive(false);
    }

    public void Achievements()
    {
        canvasAchievements.SetActive(true);
    }

    public void ReturnAchievements()
    {
        canvasAchievements.SetActive(false);
        canvasNextPgAchiev.SetActive(false);
        canvasNextPgAchiev2.SetActive(false);
    }

    public void LeaderAchievements()
    {
        canvasLeaderAchiev.SetActive(true);
    }

    public void ReturnLeaderAchievements()
    {
        canvasLeaderAchiev.SetActive(false);
    }

    public void NextPageAchiev()
    {
        canvasNextPgAchiev.SetActive(true);
        canvasNextPgAchiev2.SetActive(false);
    }
    public void NextPageAchiev2()
    {
        canvasNextPgAchiev2.SetActive(true);
    }

    public void ReturnNextPageAchiev()
    {
        canvasNextPgAchiev.SetActive(false);
    }

    public void GeneralInfos()
    {
        canvasGeneralInfos.SetActive(true);
    }

    public void MoreCoins()
    {
        canvasMoreCoins.SetActive(true);
    }

    public void QuitDisplayCoinsAd()
    {
        displayCoinsAd.gameObject.SetActive(false);
    }

    public void QuitDisplayDoubleCoins()
    {
        panelDoubleCoins.gameObject.SetActive(false);
    }

    public void QuitImageShowCoinsAd()
    {
        imageShowCoinsAd.gameObject.SetActive(false);
    }

    public void OnTutorial()
    {
            DisableTutorial = false;
            DisableTutorialValue = 0;
            EnableTutorialValue = 1;
            SavePlayerPrefs();
            EnableTutorial = !EnableTutorial;
    }

    public void OffTutorial()
    {
            EnableTutorial = false;
            EnableTutorialValue = 0;
            DisableTutorialValue = 1;
            SavePlayerPrefs();
            DisableTutorial = !DisableTutorial;
    }

    //AUDIO
    public void OnAudio()
    {
            DisableAudio = false;
            DisableAudioValue = 0;
            EnableAudioValue = 1;
            SavePlayerPrefs();
            EnableAudio = !EnableAudio;
            buttonAudioManager.audioSourceButton.mute = false;
            audioManager.generalAudioSource.mute = false;
            buttonAudioManager.playerSFX.mute = false;
            buttonAudioManager.coinAudioSource.mute = false;
    }

    public void OffAudio()
    {
            EnableAudio = false;
            EnableAudioValue = 0;
            DisableAudioValue = 1;
            SavePlayerPrefs();
            DisableAudio = !DisableAudio;
            buttonAudioManager.audioSourceButton.mute = true;
            audioManager.generalAudioSource.mute = true;
            buttonAudioManager.playerSFX.mute = true;
            buttonAudioManager.coinAudioSource.mute = true;
    }

    public void LocalDisableTutorial()
    {
        canvasTutorial.SetActive(false);
    }

    public void CompleteLeaderboard()
    {
        canvasLeaderboard.SetActive(true);
    }

    #endregion

    #region PlayerPrefsConfigs

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
    
    public void SavePlayerPrefs()
    {
            PlayerPrefs.SetInt("EnableTutorial", EnableTutorialValue);
            PlayerPrefs.SetInt("DisableTutorial", DisableTutorialValue);
            
            //AUDIO
            PlayerPrefs.SetInt("EnableAudio", EnableAudioValue);
            PlayerPrefs.SetInt("DisableAudio", DisableAudioValue);
    }

    public void LoadPlayerPrefs()
    {
        EnableTutorial = IntToBool(PlayerPrefs.GetInt("EnableTutorial"));
        DisableTutorial = IntToBool(PlayerPrefs.GetInt("DisableTutorial"));

        EnableTutorialValue = PlayerPrefs.GetInt("EnableTutorial");
        DisableTutorialValue = PlayerPrefs.GetInt("DisableTutorial");

        //AUDIO
        EnableAudio = IntToBool(PlayerPrefs.GetInt("EnableAudio"));
        DisableAudio = IntToBool(PlayerPrefs.GetInt("DisableAudio"));

        EnableAudioValue = PlayerPrefs.GetInt("EnableAudio");
        DisableAudioValue = PlayerPrefs.GetInt("DisableAudio");
    }
    
    #endregion


    private void PlatineGameCheck()
    {
        if(achievementsManager.percentualProgress == 100f)
        {
            starButton.gameObject.SetActive(true);
            starButton2.gameObject.SetActive(true);
            starAnim.SetInteger("transition", 1);
        }
    }

    public void PlatineGameCanvas()
    {
        canvasPlatineGame.SetActive(true);
        audioManager.generalAudioSource.clip = null;
        platineAudioSource.Play();
    }

    public void ReturnPlatineGameCanvas()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GiveCoins()
    {
        totalCoinAmount = 999999;
        canvasPlatineGame.SetActive(false);
    }

}