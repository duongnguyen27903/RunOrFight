using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LinkHandler : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text _textBox;
    private Canvas _canvasToCheck;
    [SerializeField] private Camera cameraToUse;
    private void Awake()
    {
        _textBox = GetComponent<TMP_Text>();
        _canvasToCheck = GetComponentInParent<Canvas>();

        if( _canvasToCheck.renderMode == RenderMode.ScreenSpaceOverlay )
        {
            cameraToUse = null;
        }
        else
        {
            cameraToUse = _canvasToCheck.worldCamera;
        }
    }

    public delegate void ClickOnLinkEvent(string keyword);
    //public static event ClickOnLinkEvent OnClickedOnLinkEvent;
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(eventData.position.x, eventData.position.y, 0);
        int linkTaggedText = TMP_TextUtilities.FindIntersectingLink(_textBox, mousePosition,cameraToUse);

        //invoke mot su kien
        //if (linkTaggedText != -1)
        //{
        //    TMP_LinkInfo linkInfo = _textBox.textInfo.linkInfo[linkTaggedText];
        //    OnClickedOnLinkEvent?.Invoke(linkInfo.GetLinkText());
        //}

        // goi link duoc kien ket
        if (linkTaggedText == -1) return;
        TMP_LinkInfo linkInfo = _textBox.textInfo.linkInfo[linkTaggedText];
        string linkId = linkInfo.GetLinkID();
        Application.OpenURL(linkId);
    }
}
