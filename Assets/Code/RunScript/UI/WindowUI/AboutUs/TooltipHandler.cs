using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable] 
public struct TooltipInfos
{
    public string Keyword;
    public Sprite Image;
}

public class TooltipHandler : MonoBehaviour
{
    [SerializeField] private List<TooltipInfos> tooltipContentList;
    [SerializeField] private GameObject tooltipContainer;
    [SerializeField] private TMP_Text tooltipDescriptionTMP;
    [SerializeField] private Image iconDisplay;

    private void Awake()
    {
        //tooltipDescriptionTMP = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        LinkHandler.OnClickedOnLinkEvent += GetTooltipInfo;
    }

    private void OnDisable()
    {
        LinkHandler.OnClickedOnLinkEvent -= GetTooltipInfo;
    }

    private void GetTooltipInfo(string keyword)
    {
        foreach(var info in tooltipContentList)
        {
            if( info.Keyword == keyword)
            {
                if(!tooltipContainer.gameObject.activeInHierarchy)
                {
                    tooltipContainer.gameObject.SetActive(true);
                }
                tooltipDescriptionTMP.text = info.Keyword;
                iconDisplay.sprite = info.Image;
                return;
            }
            print($"Keyword : {keyword} not found");
        }
    }

    public void CloseTooltipInfo()
    {
        if( tooltipContainer.gameObject.activeInHierarchy )
        {
            tooltipContainer.SetActive(false);
        }
    }
}
