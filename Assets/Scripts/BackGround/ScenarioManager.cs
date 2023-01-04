using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{

    [Header("Scenario List")]
    public List<GameObject> selectedScenario = new List<GameObject>();
    public List<int> scenePrice = new List<int>();
    public List<bool> isPurchased = new List<bool>();
    public List<int> isPurchasedValue = new List<int>();

    [Header("Another Variables")]
    public int selectedScenevalue = 0;
    public bool anySceneSelected;
    public Text scenePriceText;

    private GameManager gameManager;
    private ButtonAudioManager buttonAudioManager;
    private GeneralInfos generalInfos;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
        generalInfos = FindObjectOfType<GeneralInfos>();

        selectedScenevalue = PlayerPrefs.GetInt("SelectedSceneNumber");
        anySceneSelected = IntToBool(PlayerPrefs.GetInt("AnySelectedScene"));
        LoadPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        SelectedScenario();
    }

    private void SelectedScenario()
    {

        if(selectedScenevalue < 0)
        {
            selectedScenevalue = selectedScenario.Count - 1;
        }

        if(selectedScenevalue > selectedScenario.Count - 1)
        {
            selectedScenevalue = 0;
        }


        for(int i = 0; i < selectedScenario.Count; i++)
        {
            if(selectedScenevalue == i)
            {
                selectedScenario[i].SetActive(true); //Scene ativa

                if(isPurchased[i])
                {
                    scenePriceText.text = "Purchased";
                }
                else
                {
                    scenePriceText.text = scenePrice[i].ToString() + " COINS";
                }
            }
            else
            {
                selectedScenario[i].SetActive(false);
            }
        }
    }

    public void ButtonPressed()
    {
        anySceneSelected = true;
        PlayerPrefs.SetInt("AnySelectedScene", 1);
    }

    public void RightButton()
    {
        selectedScenevalue++;
    }

    public void LeftButton()
    {
        selectedScenevalue--;
    }

    public void BuyButton()
    {
        IsPurchasedScenario();
    }

    private void IsPurchasedScenario()
    {
        for(int i = 0; i < isPurchased.Count; i++)
        {
            if(selectedScenevalue == i && gameManager.totalCoinAmount >= scenePrice[i] && !isPurchased[i])
            {
                isPurchased[i] = true;
                isPurchasedValue[i] = 1;
                gameManager.totalCoinAmount -= scenePrice[i];
                buttonAudioManager.PurchaseSound();
                generalInfos.scenariosPurchased++;
                SavePlayerPrefs();
            }
        }
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
        isPurchasedValue[0] = PlayerPrefs.GetInt("ScenePurchased0");
        isPurchasedValue[1] = PlayerPrefs.GetInt("ScenePurchased1");
        isPurchasedValue[2] = PlayerPrefs.GetInt("ScenePurchased2");
        isPurchasedValue[3] = PlayerPrefs.GetInt("ScenePurchased3");

        isPurchased[0] = IntToBool(PlayerPrefs.GetInt("ScenePurchased0"));
        isPurchased[1] = IntToBool(PlayerPrefs.GetInt("ScenePurchased1"));
        isPurchased[2] = IntToBool(PlayerPrefs.GetInt("ScenePurchased2"));
        isPurchased[3] = IntToBool(PlayerPrefs.GetInt("ScenePurchased3"));
    }

    private void SavePlayerPrefs()
    {
        if(isPurchased[0])
        {
            PlayerPrefs.SetInt("ScenePurchased0", isPurchasedValue[0]);
        }

        if(isPurchased[1])
        {
            PlayerPrefs.SetInt("ScenePurchased1", isPurchasedValue[1]);
        }

        if(isPurchased[2])
        {
            PlayerPrefs.SetInt("ScenePurchased2", isPurchasedValue[2]);
        }

        if(isPurchased[3])
        {
            PlayerPrefs.SetInt("ScenePurchased3", isPurchasedValue[3]);
        }
    }
    
    #endregion
}
