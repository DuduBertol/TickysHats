using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSpawner : MonoBehaviour
{

    public List<GameObject> scenarioPrefabs = new List<GameObject>();
    public Transform scenePosition;
    public Transform playerParentPosition;
    public ScenarioManager scenarioManager;
    public GameObject defaultScenario;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameStarted)
        {
            for(int i = 0; i < scenarioManager.isPurchased.Count; i++)
            {
                if(scenarioManager.selectedScenevalue == i && scenarioManager.anySceneSelected && scenarioManager.isPurchased[i])
                {
                    Instantiate<GameObject>(scenarioPrefabs[i], scenePosition.position, Quaternion.identity, playerParentPosition);
                    scenarioManager.anySceneSelected = false;
                    PlayerPrefs.SetInt("SelectedSceneNumber", i);
                    Destroy(defaultScenario);
                }
            }
        }
    }
}
