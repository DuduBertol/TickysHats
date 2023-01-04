using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player player;
    private GameManager gameManager;
    private AchievementsManager achievementsManager;
    private ButtonAudioManager buttonAudioManager;


    public int bronzeValue = 1;
    public int silverValue = 2;
    public int goldValue = 3;

    private void Start() 
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
        achievementsManager = FindObjectOfType<AchievementsManager>();
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player") && this.gameObject.CompareTag("BronzeCoin"))// || collision.CompareTag("Bullet") && this.gameObject.CompareTag("BronzeCoin"))
        {
            gameManager.coinAmount += bronzeValue;
            gameManager.totalCoinAmount += bronzeValue;
            achievementsManager.allLongCoinsStorage += bronzeValue;
            buttonAudioManager.CoinSound();
            Destroy(this.gameObject, 0.1f);
        }

        if(collision.CompareTag("Player") && this.gameObject.CompareTag("SilverCoin"))// || collision.CompareTag("Bullet") && this.gameObject.CompareTag("SilverCoin"))
        {
            gameManager.coinAmount += silverValue;
            gameManager.totalCoinAmount += silverValue;
            achievementsManager.allLongCoinsStorage += silverValue;
            buttonAudioManager.CoinSound();
            Destroy(this.gameObject, 0.1f);
        }  

        if(collision.CompareTag("Player") && this.gameObject.CompareTag("GoldCoin"))// || collision.CompareTag("Bullet") && this.gameObject.CompareTag("GoldCoin"))
        {
            achievementsManager.allLongGoldCoins++;
            gameManager.coinAmount += goldValue;
            gameManager.totalCoinAmount += goldValue;
            achievementsManager.allLongCoinsStorage += goldValue;
            buttonAudioManager.CoinSound();
            Destroy(this.gameObject, 0.1f);
        }
    }

}
