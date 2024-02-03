using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    //PlayerPrefs se tra ve mot string rong( "" ) neu GetString khong tim thay key
    //PlayerPrefs se tra ve 0 neu GetInt va GetFloat khong tim thay key
    //khai bao mot singleton class
    private static StoreManager instance;
    public static StoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StoreManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
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
        return PlayerPrefs.GetInt("Coins",Coins);
    }
    public void SaveCoins( int value )
    {
        PlayerPrefs.SetInt("Coins", value);
    }
    private void ShowCoins( int Coins)
    {
        Golds.text = Coins.ToString();
    }
    public void UpdateCoins(int current_coins)
    {
        Coins = current_coins;
        ShowCoins(Coins);
        SaveCoins(Coins);
    }
    public void CheckCoins()
    {
        int amount = PlayerPrefs.GetInt("Coins",Coins);
        ShowCoins(amount);
        SaveCoins(amount);
    }

    // cac ham quan ly ngoai luong
    public void Home_Pressed()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    private void Start()
    {
        SetStoreTab(Tabs.Shop);
        CheckCoins();
    }

}
