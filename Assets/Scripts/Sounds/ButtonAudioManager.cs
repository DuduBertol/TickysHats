using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource audioSourceButton;
    [SerializeField] private AudioClip offSound;
    [SerializeField] private AudioClip onSound;
    [SerializeField] private AudioClip purchaseSound;
    [SerializeField] private AudioClip achievementSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip highScoreSound;
    [SerializeField] public AudioSource coinAudioSource;

    [Header("Player")]
    [SerializeField] public AudioSource playerSFX;
    [SerializeField] private List<AudioClip> runSound = new List<AudioClip>();
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip shotSound;
    [SerializeField] private AudioClip damageSound;

    private GameManager gameManager;
    private AudioManager audioManager;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void OffSound()
    {
        audioSourceButton.PlayOneShot(offSound);
        gameManager.OffAudio();
    }

    public void OnSound()
    {
        audioSourceButton.PlayOneShot(onSound);
        gameManager.OnAudio();
    }

    public void PurchaseSound()
    {
       audioSourceButton.PlayOneShot(purchaseSound);
    }

    public void AchievementSound()
    {
       audioSourceButton.PlayOneShot(achievementSound);
    }

    public void GameOverSound()
    {
       audioSourceButton.PlayOneShot(gameOverSound);
    }

    public void HighScoreSound()
    {
        if(gameManager.score > gameManager.highScore)
        {
            audioSourceButton.PlayOneShot(highScoreSound);
        }
        else
        {
            GameOverSound();
        }
    }

    public void PlayerShotSound()
    {
        playerSFX.PlayOneShot(shotSound);
    }

    public void PlayerRunSound()
    {
        playerSFX.PlayOneShot(runSound[Random.Range(0, runSound.Count)]);
    }

    public void PlayerJumpSound()
    {
        playerSFX.PlayOneShot(jumpSound);
    }

    public void CoinSound()
    {
        coinAudioSource.Play();
    }

    public void BulletDamageSound()
    {
        audioSourceButton.PlayOneShot(damageSound);
    }

}
