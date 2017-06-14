using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteractions : MonoBehaviour {

    /* Single Player Menu */

    public delegate void BackButtonDelegate();
    public delegate void SinglePlayerButtonDelegate();
    public event BackButtonDelegate BackButtonEvent;
    public event SinglePlayerButtonDelegate SinglePlayerButtonEvent;

    public void SinglePlayerButtonPressed()
    {
        if (SinglePlayerButtonEvent != null)
        {
            SinglePlayerButtonEvent();
        }
    }

    public void BackButtonPressed()
    {
        if (BackButtonEvent != null)
        {
            BackButtonEvent();
        }
    }
}
