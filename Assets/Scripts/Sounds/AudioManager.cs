using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private GameManager gameManager;
    public float randomNumber;
    [SerializeField] public AudioSource generalAudioSource;
    [SerializeField] public List<AudioSource> startAudioList = new List<AudioSource>();
    [SerializeField] public List<AudioSource> gameAudioList = new List<AudioSource>();



    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        DontDestroyOnLoad(this);
            generalAudioSource.mute = false;
            randomNumber = Random.Range(0, 2);
            if(randomNumber < 1f)
            {
                generalAudioSource.clip = startAudioList[0].clip;
                generalAudioSource.Play();
            }
            else
            {
                generalAudioSource.clip = startAudioList[1].clip;
                generalAudioSource.Play();
            }
    }
}
