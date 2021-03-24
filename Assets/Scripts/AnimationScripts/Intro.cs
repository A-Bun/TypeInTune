using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameObject flicker, fader;
    public void OnFadeOutComplete()
    {
        Color color;
        color = gameObject.GetComponent<Image>().color;
        color.a = 0f;
        gameObject.GetComponent<Image>().color = color;

        gameObject.SetActive(false);
        flicker.SetActive(true);
    }

    public void OnFadeEndComplete()
    {
        gameObject.SetActive(false);
        fader.GetComponent<Fader>().FadeToNextLevel();
    }
}
