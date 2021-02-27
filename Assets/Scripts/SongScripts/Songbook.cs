using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Songbook : MonoBehaviour
{
    public Button prevSong, nextSong;
    public TextMeshProUGUI title, artist, times, money, mistakes, duration;
    private Song[] songs;
    private Song currSong;
    private int index;
    private AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        songs = Resources.LoadAll<Song>("Songs");
        index = 0;
        audioS = gameObject.GetComponent<AudioSource>();
        currSong = songs[index];
        audioS.clip = currSong.songAudio;
        SetSongInfo();

        prevSong.gameObject.SetActive(false);

        if (songs.Length == 1)
        {
            nextSong.gameObject.SetActive(false);
        }
    }

    public void SetSongInfo()
    {
        title.text = currSong.songTitle;
        artist.text = currSong.songArtist;
        times.text = "Total times played: " + currSong.timesPlayed.ToString();
        money.text = "Total money made: $" + currSong.totalMoney.ToString();
        mistakes.text = "Total mistakes made: " + currSong.totalMistakes.ToString();
        duration.text = "Song Duration - " + currSong.DetailedDuration();

        audioS.clip = currSong.songAudio;
    }

    public void GoToNextSong()
    {
        index++;
        currSong = songs[index];
        prevSong.gameObject.SetActive(true);

        SetSongInfo();

        if (index >= (songs.Length-1))
        {
            nextSong.gameObject.SetActive(false);
        }
        else
        {
            nextSong.gameObject.SetActive(true);
        }
    }

    public void GoToPrevSong()
    {
        index--;
        currSong = songs[index];
        nextSong.gameObject.SetActive(true);

        SetSongInfo();

        if (index <= 0)
        {
            prevSong.gameObject.SetActive(false);
        }
        else
        {
            prevSong.gameObject.SetActive(true);
        }
    }

    public void PlaySong()
    {
        if (audioS.time == 0)
        {
            audioS.Play();
        }
        else if (!audioS.isPlaying)
        {
            audioS.UnPause();
        }
    }

    public void PauseSong()
    {
        if (audioS.isPlaying)
        {
            audioS.Pause();
        }
    }

    public void StopSong()
    {
        if (audioS.isPlaying)
        {
            audioS.Stop();
        }
    }

    public void RestartSong()
    {
        if (audioS.time > 0)
        {
            audioS.Stop();
            audioS.Play();
        }
    }

    public void CloseSongbook()
    {
        index = 0;
        currSong = songs[index];
        SetSongInfo();
        audioS.Stop();
        prevSong.gameObject.SetActive(false);
        nextSong.gameObject.SetActive(true);
    }
}
