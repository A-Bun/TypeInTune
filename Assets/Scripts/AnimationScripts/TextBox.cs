using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBox : MonoBehaviour
{
    public bool done;
    public void OnTextBoxClose()
    {
        gameObject.SetActive(false);
        done = true;
    }
}
