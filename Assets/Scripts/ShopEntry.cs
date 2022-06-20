using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEntry : MonoBehaviour
{

    [SerializeField] private Text myText;
    [SerializeField] private Text myPrice;
    [SerializeField] private Text myDescription;
    public int price;
    public int material;
    public bool unlocked;
    public bool completed;
    public int id;

    //0 to unlock a planet
    //1 to unlock an element
    //2 to unlock a new game system
    public int unlockType;

    //holds the value of what id to unlock
    public int unlockValue;

    public ElementManager em;
    public Button shopButton;
    public GameObject shopTemplate;
    public ShopManager sm;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = shopButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void TaskOnClick()
    {
        //check if player can afford the shop entry
        if (em.elementList[material].amountNum >= price)
        {
            SetCompleted(true);
            sm.UpdateUI(shopTemplate);
            //take the cost from the player
            em.elementList[material].SetAmount(em.elementList[material].amountNum - price);
        }
    }

    //unlocks whatever is specified by the hopEntry csv fields
    public void Unlock()
    {

    }

    public void SetText(string shop)
    {
        myText.text = shop;
    }

    public void SetPrice(int newPrice, int mat)
    {
        myPrice.text = newPrice.ToString() + " " + em.eStrings[mat];
        price = newPrice;
        material = mat;
    }

    public void SetUnlocked(bool status)
    {
        unlocked = status;
    }

    public void SetCompleted(bool status)
    {
        completed = status;
    }

    public void SetDescription(string description)
    {
        myDescription.text = description;
    }

    public void SetID(int newID)
    {
        id = newID;
    }

}
