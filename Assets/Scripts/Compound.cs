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

    //two descriptions that can be toggled
    public string description;
    public string howObtain;
    //0 if desc, 1 if obtain
    public int active;

    //determines if unlocked
    public bool unlocked;

    //internal id of the compound
    public int id;

    //amount currently owned
    public int amountNum;

    //maximum possible to be owned
    public int maxNum;

    public Button compoundButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = compoundButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //used to swap between the two different descriptions
        if (active == 0)
        {
            SetActiveDesc(howObtain);
            active = 1;
        } else if (active == 1)
        {
            SetActiveDesc(description);
            active = 0;
        }
    }

    public void SetActive(int act)
    {
        active = act;
    }


    //name of the compound
    public void SetText(string compound)
    {
        myText.text = compound;
        compoundString = compound;
    }

    public void SetDesc(string desc)
    {
        description = desc;
    }

    public void SetObtain(string obtain)
    {
        howObtain = obtain;
    }

    public void SetActiveDesc(string desc)
    {
        myDesc.text = desc;
    }

    public void SetUnlocked(bool status)
    {
        unlocked = status;

        //update the amount to show unlocked
        SetAmount(amountNum);
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
            myAmount.text = amount.ToString() + " / " + maxNum.ToString();
            amountNum = amount;
        }
    }

    public void SetMax(int max)
    {
        maxNum = max;
    }
}
