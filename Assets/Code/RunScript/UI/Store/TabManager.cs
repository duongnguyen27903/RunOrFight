using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI shop_text;
    [SerializeField] private TextMeshProUGUI heroes_text;

    public void Shop_Pressed()
    {
        StoreManager.Instance.SetStoreTab(StoreManager.Tabs.Shop);
        shop_text.color = Color.gray;
        heroes_text.color = Color.yellow;
    }
    public void Heroes_Pressed()
    {
        StoreManager.Instance.SetStoreTab(StoreManager.Tabs.Heroes);
        heroes_text.color = Color.gray;
        shop_text.color = Color.yellow;
    }
    private void Start()
    {
        shop_text.color = Color.gray;
        heroes_text.color = Color.yellow;
    }
}
