using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    //PlayerPrefs se tra ve mot string rong( "" ) neu khong tim thay key
    //khai bao mot singleton class
    private static StoreManager Instance;
    public static StoreManager instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<StoreManager>();
            }
            return Instance;
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    //quan li tabs
    public enum Tabs
    {
        Shop,Heroes
    }
    [SerializeField] private Button Shop;
    [SerializeField] private Button Heroes;
    private Tabs current_tab;
    public void SetStoreTab( Tabs tab )
    {
        current_tab = tab;
        Shop.interactable = (current_tab != Tabs.Shop);
        Heroes.interactable = (current_tab != Tabs.Heroes);
    }

    //quan ly so luong coins
    [SerializeField] private int Coins;
    [SerializeField] private TextMeshProUGUI Golds;
    public int GetCoins()
    {
        return Coins;
    }
    public void UpdateCoins(int current_coins)
    {
        Coins = current_coins;
        Golds.text = Coins.ToString();
    }

    // cac ham quan ly ngoai luong
    public void Home_Pressed()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        SetStoreTab(Tabs.Shop);
        Golds.text = Coins.ToString();
        //PlayerPrefs.SetString("Coins",Coins.ToString());
        //print(PlayerPrefs.GetString("Coins") == "");
        //PlayerPrefs.DeleteAll();
    }

}
