using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    //quan li tabs
    public enum Tabs
    {
        Shop, Heroes
    }
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private Button Shop;
    [SerializeField] private TextMeshProUGUI shop_text;
    [SerializeField] private GameObject HeroesPanel;
    [SerializeField] private Button Heroes;
    [SerializeField] private TextMeshProUGUI heroes_text;
    private Tabs current_tab;
    public void SetStoreTab(Tabs tab)
    {
        current_tab = tab;
        ShopPanel.SetActive(current_tab == Tabs.Shop);
        HeroesPanel.SetActive(current_tab == Tabs.Heroes);
        Shop.interactable = (current_tab != Tabs.Shop);
        Heroes.interactable = (current_tab != Tabs.Heroes);
        shop_text.color = (current_tab == Tabs.Shop) ? Color.gray : Color.yellow;
        heroes_text.color = (current_tab == Tabs.Heroes) ? Color.gray : Color.yellow;
    }
    public void Shop_Pressed()
    {
        SetStoreTab(Tabs.Shop);
    }
    public void Heroes_Pressed()
    {
        SetStoreTab(Tabs.Heroes);
    }
    private void Start()
    {
        SetStoreTab(Tabs.Heroes);
    }
}
