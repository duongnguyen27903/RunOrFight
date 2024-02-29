using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup FadeIn;
    private bool startFadeIn = false;
    private void Awake()
    {
        FadeIn.alpha = 1.0f;
        StartCoroutine(LoadMenuSence());
    }
    private IEnumerator LoadMenuSence()
    {
        yield return new WaitForSeconds(3f);
        startFadeIn = true;
    }
    private void Update()
    {
        if(startFadeIn)
        {
            FadeIn.alpha -= Time.deltaTime * 0.5f;
        }
        if( FadeIn.alpha <= 0.01)
        {
            SceneManager.LoadSceneAsync("Menu");
        }
    }
}
