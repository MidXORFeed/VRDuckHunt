using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderAnimation : MonoBehaviour {

    public Animation animation;

    public void SetFrame(float frame)
    {
        animation["SliderPullAnimation"].speed = 0;
        animation["SliderPullAnimation"].time = frame;
        animation.Play("SliderPullAnimation");
    }
}
