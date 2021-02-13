using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Song", menuName = "Song")]
public class Song : ScriptableObject
{
    public string songTitle = "New Song";
    public AudioClip songAudio = null;
    public float songDuration = 0;
    public int timesPlayed = 0;
    public int songCost = 0;
    public List<int> songSalary = new List<int>();
    public List<int> salaryMarks = new List<int>();
    public bool status = false;
}
