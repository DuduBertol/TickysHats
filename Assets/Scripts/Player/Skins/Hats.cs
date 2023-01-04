using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hats : MonoBehaviour
{
    [Header("Lista de Chapéus")]
    public List<GameObject> selectedHat = new List<GameObject>();
    public List<int> hatPrice = new List<int>();
    public List<bool> isPurchased = new List<bool>();
    public List<int> isPurchasedValue = new List<int>();

    [Header("Another Variables")]
    public int selectedHatvalue = 0;
    public bool anyHatSelected;
    public Text hatPriceText;
    

    private Animator anim;
    private Player player;
    private GameManager gameManager;
    private ButtonAudioManager buttonAudioManager;
    private GeneralInfos generalInfos;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
        generalInfos = FindObjectOfType<GeneralInfos>();

        selectedHatvalue = PlayerPrefs.GetInt("SelectedHatNumber");
        anyHatSelected = IntToBool(PlayerPrefs.GetInt("AnySelectedHat"));
        isPurchased[0] = true;

        LoadPlayerPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        SelectedHat();
        SavePlayerPrefs();
    }

    private void SelectedHat()
    {

        if(selectedHatvalue < 0)
        {
            selectedHatvalue = selectedHat.Count - 1;
        }

        if(selectedHatvalue > selectedHat.Count - 1)
        {
            selectedHatvalue = 0;
        }

        for (int i = 0; i < selectedHat.Count; i++)
        {
            if(selectedHatvalue == i)
            {
                selectedHat[i].SetActive(true); //hat ativo

                if(isPurchased[i])
                {
                    hatPriceText.text = "Purchased";
                }
                else
                {
                    hatPriceText.text = hatPrice[i].ToString() + " coins";
                }
            }
            else
            {
                selectedHat[i].SetActive(false);
            }
        }
    }

    public void ButtonPressed()
    {
        anyHatSelected = true;
        PlayerPrefs.SetInt("AnySelectedHat", 1);
    }

    public void RightButton()
    {
        selectedHatvalue++;
    }

    public void LeftButton()
    {
        selectedHatvalue--;
    }

    public void BuyButton()
    {
        IsPurchasedHat();
    }

    private void IsPurchasedHat()
    {
        for(int i = 0; i < isPurchased.Count; i++)
        {
            if(selectedHatvalue == i && gameManager.totalCoinAmount >= hatPrice[i] && !isPurchased[i])
            {
                isPurchased[i] = true;
                isPurchasedValue[i] = 1;
                gameManager.totalCoinAmount -= hatPrice[i];
                buttonAudioManager.PurchaseSound();
                generalInfos.hatsPurchased++;
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
        isPurchasedValue[0] = PlayerPrefs.GetInt("IsPurchasedValue0");
        isPurchasedValue[1] = PlayerPrefs.GetInt("IsPurchasedValue1");
        isPurchasedValue[2] = PlayerPrefs.GetInt("IsPurchasedValue2");
        isPurchasedValue[3] = PlayerPrefs.GetInt("IsPurchasedValue3");
        isPurchasedValue[4] = PlayerPrefs.GetInt("IsPurchasedValue4");
        isPurchasedValue[5] = PlayerPrefs.GetInt("IsPurchasedValue5");
        isPurchasedValue[6] = PlayerPrefs.GetInt("IsPurchasedValue6");
        isPurchasedValue[7] = PlayerPrefs.GetInt("IsPurchasedValue7");
        isPurchasedValue[8] = PlayerPrefs.GetInt("IsPurchasedValue8");
        isPurchasedValue[9] = PlayerPrefs.GetInt("IsPurchasedValue9");
        isPurchasedValue[10] = PlayerPrefs.GetInt("IsPurchasedValue10");
        isPurchasedValue[11] = PlayerPrefs.GetInt("IsPurchasedValue11");

        isPurchased[0] = IntToBool(PlayerPrefs.GetInt("IsPurchased0"));
        isPurchased[1] = IntToBool(PlayerPrefs.GetInt("IsPurchased1"));
        isPurchased[2] = IntToBool(PlayerPrefs.GetInt("IsPurchased2"));
        isPurchased[3] = IntToBool(PlayerPrefs.GetInt("IsPurchased3"));
        isPurchased[4] = IntToBool(PlayerPrefs.GetInt("IsPurchased4"));
        isPurchased[5] = IntToBool(PlayerPrefs.GetInt("IsPurchased5"));
        isPurchased[6] = IntToBool(PlayerPrefs.GetInt("IsPurchased6"));
        isPurchased[7] = IntToBool(PlayerPrefs.GetInt("IsPurchased7"));
        isPurchased[8] = IntToBool(PlayerPrefs.GetInt("IsPurchased8"));
        isPurchased[9] = IntToBool(PlayerPrefs.GetInt("IsPurchased9"));
        isPurchased[10] = IntToBool(PlayerPrefs.GetInt("IsPurchased10"));
        isPurchased[11] = IntToBool(PlayerPrefs.GetInt("IsPurchased11"));
    }

    private void SavePlayerPrefs()
    {
        if(isPurchased[0])
        {
            PlayerPrefs.SetInt("IsPurchased0", isPurchasedValue[0]);
            PlayerPrefs.SetInt("IsPurchasedValue0", isPurchasedValue[0]);
        }

        if(isPurchased[1])
        {
            PlayerPrefs.SetInt("IsPurchased1", isPurchasedValue[1]);
            PlayerPrefs.SetInt("IsPurchasedValue1", isPurchasedValue[1]);
        }

        if(isPurchased[2])
        {
            PlayerPrefs.SetInt("IsPurchased2", isPurchasedValue[2]);
            PlayerPrefs.SetInt("IsPurchasedValue2", isPurchasedValue[2]);
        }

        if(isPurchased[3])
        {
            PlayerPrefs.SetInt("IsPurchased3", isPurchasedValue[3]);
            PlayerPrefs.SetInt("IsPurchasedValue3", isPurchasedValue[3]);
        }

        if(isPurchased[4])
        {
            PlayerPrefs.SetInt("IsPurchased4", isPurchasedValue[4]);
            PlayerPrefs.SetInt("IsPurchasedValue4", isPurchasedValue[4]);
        }

        if(isPurchased[5])
        {
            PlayerPrefs.SetInt("IsPurchased5", isPurchasedValue[5]);
            PlayerPrefs.SetInt("IsPurchasedValue5", isPurchasedValue[5]);
        }

        if(isPurchased[6])
        {
            PlayerPrefs.SetInt("IsPurchased6", isPurchasedValue[6]);
            PlayerPrefs.SetInt("IsPurchasedValue6", isPurchasedValue[6]);
        }

        if(isPurchased[7])
        {
            PlayerPrefs.SetInt("IsPurchased7", isPurchasedValue[7]);
            PlayerPrefs.SetInt("IsPurchasedValue7", isPurchasedValue[7]);
        }

        if(isPurchased[8])
        {
            PlayerPrefs.SetInt("IsPurchased8", isPurchasedValue[8]);
            PlayerPrefs.SetInt("IsPurchasedValue8", isPurchasedValue[8]);
        }

        if(isPurchased[9])
        {
            PlayerPrefs.SetInt("IsPurchased9", isPurchasedValue[9]);
            PlayerPrefs.SetInt("IsPurchasedValue9", isPurchasedValue[9]);
        }

        if(isPurchased[10])
        {
            PlayerPrefs.SetInt("IsPurchased10", isPurchasedValue[10]);
            PlayerPrefs.SetInt("IsPurchasedValue10", isPurchasedValue[10]);
        }

        if(isPurchased[11])
        {
            PlayerPrefs.SetInt("IsPurchased11", isPurchasedValue[11]); 
            PlayerPrefs.SetInt("IsPurchasedValue11", isPurchasedValue[11]);
        }
    }
    


    #endregion
    

}
