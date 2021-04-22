using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int day;
    public int currMoney;
    public List<string> ownedMusic;
    public List<string> ownedPianos;
    public List<string> comLetters;
    public bool introCompleted;
    public bool tutorialCompleted;

    public PlayerData(PlayerInfo player)
    {
        day = player.day;
        currMoney = player.currMoney;
        ownedMusic = player.ownedMusic;
        ownedPianos = player.ownedPianos;
        comLetters = player.comLetters;
        introCompleted = player.introCompleted;
        tutorialCompleted = player.tutorialCompleted;
    }
}
