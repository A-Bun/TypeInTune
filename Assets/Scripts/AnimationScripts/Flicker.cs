using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public GameObject intro;
    public void OnFlickerComplete()
    {
        intro.GetComponent<BarIntroScript>().second = true;
    }
}
