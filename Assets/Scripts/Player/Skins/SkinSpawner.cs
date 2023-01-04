using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSpawner : MonoBehaviour
{

    public List<GameObject> hatPrefabs = new List<GameObject>();
    public Transform hatPosition;
    public Transform playerParentPosition;
    public Hats hats;
    private GameManager gameManager;
    private bool isInstantiate;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameStarted)
        {
            for(int i = 0; i < hats.isPurchased.Count; i++)
            {
                if(hats.selectedHatvalue == i && hats.anyHatSelected == true && hats.isPurchased[i] && !isInstantiate)
                {
                    Instantiate<GameObject>(hatPrefabs[i], hatPosition.position, Quaternion.identity, playerParentPosition);
                    isInstantiate = true;
                    PlayerPrefs.SetInt("SelectedHatNumber", i);
                }
            }
        }
    }
}
