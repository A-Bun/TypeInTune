using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class Player : ScriptableObject
{
    public int currMoney = 0;
    public bool introCompleted;
}
