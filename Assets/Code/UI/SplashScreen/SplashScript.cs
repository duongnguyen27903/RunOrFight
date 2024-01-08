using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    
    private void Awake()
    {
        StartCoroutine(LoadMenuSence());
    }
    private IEnumerator LoadMenuSence()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MenuScene");
    }
}
