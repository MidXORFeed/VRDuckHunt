using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteractions : MonoBehaviour {

    /* Miscellaneous */
    // public event Action BackButtonEvent if void delegate with no parameters
    public event Func<IEnumerator> BackButtonEvent;
    
    /* Single Player Menu */
    public event Func<IEnumerator> NewGameButtonEvent;
    public event Func<IEnumerator> WaveProgressionButtonEvent;
    public event Func<IEnumerator> TimeAttackButtonEvent;

    public void BackButtonPressed()
    {
        if (BackButtonEvent != null)
        {
            StartCoroutine(BackButtonEvent());
        }
    }

    public void NewGameButtonPressed()
    {
        if (NewGameButtonEvent != null)
        {
            StartCoroutine(NewGameButtonEvent());
        }
    }

    public void WaveProgressionButtonPressed()
    {
        if (WaveProgressionButtonEvent != null)
        {
            StartCoroutine(WaveProgressionButtonEvent());
        }
    }

    public void TimeAttackButtonPressed()
    {
        if (TimeAttackButtonEvent != null)
        {
            StartCoroutine(TimeAttackButtonEvent());
        }
    }
}
