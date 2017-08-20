using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderAnimation : MonoBehaviour {

    public string animationClipName;
    public Animation animation;

    public void SetFrame(float frame)
    {
        animation[animationClipName].speed = 0;
        animation[animationClipName].time = frame;
        animation.Play(animationClipName);
    }
}
