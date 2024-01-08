using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("RunScene");
    }
    public void SelectCharacterButtonPress()
    {
        SceneManager.LoadScene("SelectCharacter");
    }
}
