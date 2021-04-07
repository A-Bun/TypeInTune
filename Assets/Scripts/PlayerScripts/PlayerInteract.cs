using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Player player;

    public void SetMoney()
    {
    }

    public int GetMoney()
    {
        return player.currMoney;
    }

    public void IncMoney(int amount)
    {
        player.currMoney += amount;
    }

    public bool DecMoney(int amount)
    {
        bool bought;
        if(player.currMoney - amount < 0)
        {
            bought = false;
        }
        else
        {
            bought = true;
            player.currMoney -= amount;
        }

        return bought;
    }

    public bool GetIntroStatus()
    {
        return player.introCompleted;
    }

    public void SetIntroStatus(bool status)
    {
        player.introCompleted = status;
    }

    public bool GetTutorialStatus()
    {
        return player.tutorialCompleted;
    }

    public void SetTutorialStatus(bool status)
    {
        player.tutorialCompleted = status;
    }
}
