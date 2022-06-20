using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compound : MonoBehaviour
{

    [SerializeField] private Text myText;
    [SerializeField] private Text myDesc;
    [SerializeField] private Text myAmount;

    //holds the name of the compound
    public string compoundString;

    //determines if unlocked
    public bool unlocked;

    //internal id of the compound
    public int id;

    //amount currently owned
    public int amountNum;

    //maximum possible to be owned
    public int maxNum;



    //name of the compound
    public void SetText(string compound)
    {
        myText.text = compound;
        compoundString = compound;
    }

    public void SetDesc(string desc)
    {
        myDesc.text = desc;
    }

    public void SetUnlocked(bool status)
    {
        unlocked = status;
    }

    public void SetID(int newID)
    {
        id = newID;
    }

    public void SetAmount(int amount)
    {
        if (unlocked == false)
        {
            myAmount.text = "";
            return;
        }
       
        //only allows new value if it is less or equal to the max
        if (amount <= maxNum)
        {
            myAmount.text = amount.ToString();
            amountNum = amount;
        }
    }

    public void SetMax(int max)
    {
        maxNum = max;
    }
}
