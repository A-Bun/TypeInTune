using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Song", menuName = "Song")]
public class Song : ScriptableObject
{
    public string songTitle = "New Song", songArtist = "Artist Name";
    public AudioClip songAudio = null;
    public float songDuration = 0;
    public int timesPlayed = 0, songCost = 0, totalMistakes = 0, totalMoney = 0;
    public List<int> songSalary = new List<int>();
    public List<int> salaryMarks = new List<int>();
    public bool owned = false;
    public int interval;

    public string DetailedDuration()
    {
        int totalMins, totalSecs, ten = 10, sixty = 60;
        string minsSecs = "error";

        totalMins = (int)(songAudio.length / sixty);
        totalSecs = (int)(songAudio.length - (totalMins * sixty));

        if (totalSecs < ten)
        {
            minsSecs =  totalMins + ":0" + totalSecs;
        }
        else
        {
            minsSecs = totalMins + ":" + totalSecs;
        }

        return minsSecs;
    }
}
