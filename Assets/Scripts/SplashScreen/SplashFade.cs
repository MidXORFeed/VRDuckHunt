using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SplashFade : MonoBehaviour {

    public float FADE_TIME = 2.0f;
    public float FADING_DURATION = 3.0f;
    public Image splashImage;
    private string loadLevel = "StartScene";

    private IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(FADE_TIME);
        FadeOut();
        yield return new WaitForSeconds(FADE_TIME);
        SceneManager.LoadScene(loadLevel);
        
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, FADING_DURATION, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, FADING_DURATION, false);
    }
}
