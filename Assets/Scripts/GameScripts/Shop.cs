using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PlayerInteract pi;
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        SetMoney();
    }

    public void SetMoney()
    {
        moneyText.text = "$" + pi.GetMoney();
    }

    public void BuyItem(int cost)
    {
        bool enoughMoney;
        enoughMoney = pi.DecMoney(cost);
        if(enoughMoney)
        {
            Debug.Log("Item Bought!");
        }
        else
        {
            Debug.Log("Insufficient Funds! Item not bought.");
        }
    }
}
