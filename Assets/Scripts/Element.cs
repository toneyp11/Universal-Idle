using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{

    [SerializeField] private Text myText;
    [SerializeField] private Text myAmount;
    public int amountNum;
    public string elementString;
    public bool unlocked;
    public int id;
    public Color color;

    public ShopManager sm;
    public GameObject elementTemplate;

    //name of the element
    public void SetText(string element)
    {
        myText.text = element;
        elementString = element;
    }

    //amount of the element possessed by the player
    public void SetAmount(int amount)
    {
        myAmount.text = amount.ToString();
        amountNum = amount;
        if (sm.initialized == true)
        {
            sm.UpdateColor(id, amount);
        }
    }

    public void SetUnlocked(bool status)
    {
        unlocked = status;

        //if unlocked, display color
        if (unlocked)
        {
            GetComponent<Image>().color = color;
        }
    }

    public void SetID(int newID)
    {
        id = newID;
    }

    public void SetColor(string colorString)
    {
        ColorUtility.TryParseHtmlString(colorString, out color);
    }

}
