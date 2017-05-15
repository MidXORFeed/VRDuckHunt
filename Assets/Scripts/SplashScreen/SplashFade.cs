using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SplashFade : MonoBehaviour {

    public float WAIT_FADE_TIME = 3.0f;
    public float FADING_DURATION = 1.5f;
    public Image splashImage;
    public int loadLevel;

    private IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(WAIT_FADE_TIME);
        FadeOut();
        yield return new WaitForSeconds(WAIT_FADE_TIME);
        LoadingScreenManager.LoadScene(loadLevel);
        
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
