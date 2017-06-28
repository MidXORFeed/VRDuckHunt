using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteractions : MonoBehaviour {

    /* Miscellaneous */
    public delegate void BackButtonDelegate();
    public event BackButtonDelegate BackButtonEvent;

    /* Single Player Menu */
    public delegate void SinglePlayerButtonDelegate();
    public delegate void NewGameButtonDelegate();
    public delegate void WaveProgressionButtonDelegate();
    public delegate void QuickShotButtonDelegate();
    public delegate void TimeAttackButtonDelegate();
    
    public event SinglePlayerButtonDelegate SinglePlayerButtonEvent;
    public event NewGameButtonDelegate NewGameButtonEvent;
    public event WaveProgressionButtonDelegate WaveProgressionButtonEvent;
    public event QuickShotButtonDelegate QuickShotButtonEvent;
    public event TimeAttackButtonDelegate TimeAttackButtonEvent;

    public void BackButtonPressed()
    {
        if (BackButtonEvent != null)
        {
            BackButtonEvent();
        }
    }

    public void SinglePlayerButtonPressed()
    {
        if (SinglePlayerButtonEvent != null)
        {
            SinglePlayerButtonEvent();
        }
    }

    public void NewGameButtonPressed()
    {
        if (NewGameButtonEvent != null)
        {
            NewGameButtonEvent();
        }
    }

    public void WaveProgressionButtonPressed()
    {
        if (WaveProgressionButtonEvent != null)
        {
            WaveProgressionButtonEvent();
        }
    }

    public void QuickShotButtonPressed()
    {
        if (QuickShotButtonEvent != null)
        {
            QuickShotButtonEvent();
        }
    }

    public void TimeAttackButtonPressed()
    {
        if (TimeAttackButtonEvent != null)
        {
            TimeAttackButtonEvent();
        }
    }


}
