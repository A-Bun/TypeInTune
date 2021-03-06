using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public string speakerName;
    [TextArea]
    public string[] sentences;
    public bool isComplete;
}
