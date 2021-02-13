using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Letter", menuName = "Letter")]
public class Letter : ScriptableObject
{
    public string title = "New Letter";
    [TextArea] // used for TypeTracker only!!
    public List<string> sentences = new List<string>();
    public List<bool> completedSentences = new List<bool>();
    public bool isComplete;
    public Sprite paper;
    public Song song;
    public int interval;

    //public void ResetLetter()
    //{
    //    sentences.Clear();
    //    isComplete = false;
    //    paper = null;
    //}
}
