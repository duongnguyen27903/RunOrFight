using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeroCard : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private Image hero_image;
    [SerializeField] private TextMeshProUGUI hero_name;
    [SerializeField] private int price;
    [SerializeField] public bool owned;
    [SerializeField] public bool Iselected;
    [SerializeField] private TextMeshProUGUI statement;
    [SerializeField] private Image statement_button;
    [SerializeField] private Button SelectButton;
    [SerializeField] private Sprite selected;
    [SerializeField] private Sprite not_select;
    [SerializeField] private Sprite not_owned;
    [SerializeField] private int current_hero;

    private HeroesContainer heroesContainer;
    private void Start()
    {
        heroesContainer = FindObjectOfType<HeroesContainer>();
    }
    public void Init( Hero hero, int current)
    {
        id = hero.id;
        current_hero = current;
        hero_image.sprite = hero.sprite;
        hero_name.text = hero.name;
        owned = hero.owned;
        Iselected = hero.selected;
        price = hero.price;
        if( hero.owned )
        {
            if( hero.selected )
            {
                statement.text = "Selected";
                statement_button.sprite = selected;
                SelectButton.interactable = !Iselected;
            }
            else
            {
                statement.text = "Select";
                statement_button.sprite = not_select;
            }
        }
        else
        {
            statement.text = price.ToString();
            statement_button.sprite = not_owned;
        }
    }

    public void PurchaseHero()
    {
        int amount = StoreManager.Instance.GetCoins();
        if ( price <= amount )
        {
            statement.text = "Select";
            statement_button.sprite = not_select;
            heroesContainer.UnlockHero(current_hero);
            StoreManager.Instance.UpdateCoins(amount - price);
        }
        else
        {
            print("not enough coins");
        }
    }
    public void SelectHero()
    {
        if( owned == true)
        {
            Iselected = true;
            PlayerPrefs.SetInt("selected_hero", id);
            statement.text = "Selected";
            statement_button.sprite = selected;
            SelectButton.interactable = !Iselected;
            heroesContainer.FindSelectedHero(current_hero);
        }
        else
        {
            PurchaseHero();
        }
    }
    public void UnSelectHero()
    {
        Iselected = false;
        statement.text = "Select";
        statement_button.sprite = not_select;
        SelectButton.interactable = !Iselected;
    }
}
