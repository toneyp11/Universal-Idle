using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopManager : MonoBehaviour
{
    public ElementManager em;

    [SerializeField] GameObject shopTemplate;

    //number of total shop items in the game
    public int shopNum;

    //array of all entries
    public ShopEntry[] shopList;

    //comfirms that the shop has finished initializing
    public bool initialized;

    // Start is called before the first frame update
    void Awake()
    {
        //read shop.csv
        List<Dictionary<string, object>> shopData = CSVReader.Read("shop");
        shopNum = shopData.Count;

        shopList = new ShopEntry[shopNum];
        initialized = false;


        //populate the element objects
        for (int i = 0; i < shopNum; i++)
        {
            //create a new element object
            GameObject shop = Instantiate(shopTemplate);

            //add the new element to the public array
            shopList[i] = shop.GetComponent<ShopEntry>();

            //set values of the new element
            shopList[i].SetID(i);
            shopList[i].SetText((string)shopData[i]["Name"]);
            shopList[i].SetPrice(Convert.ToInt32(shopData[i]["Price"]), Convert.ToInt32(shopData[i]["Material"]));
            shopList[i].SetDescription((string)shopData[i]["Description"]);
            shopList[i].SetUnlocked(true); //unlock all by default
            shopList[i].SetCompleted(false); //uncompletes all by default

            UpdateUI(shop);
        }

        initialized = true;
    }

    //updates the shop depending on the unlock and completion status of the entry
    public void UpdateUI(GameObject shop)
    {
        ShopEntry entry = shop.GetComponent<ShopEntry>();

        //display only unlocked and uncompleted entrys
        if (entry.unlocked && !entry.completed)
        {
            shop.SetActive(true);
            shop.transform.SetParent(shopTemplate.transform.parent, false);
        } else
        {
            shop.SetActive(false);
            shop.transform.SetParent(shopTemplate.transform.parent, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //determines if any shop entries need updated each time an amount is changed
    public void UpdateColor(int element, int newAmount)
    {

        for (int i = 0; i < shopNum; i++)
        {
            //if element value is now above price, change color to green
            if (shopList[i].material == element && newAmount >= shopList[i].price)
            {
                shopList[i].shopTemplate.GetComponent<Image>().color = new Color32(75, 150, 85, 255);
            }
            //if element value is now below price, change color to gray
            if (shopList[i].material == element && newAmount < shopList[i].price)
            {
                shopList[i].shopTemplate.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
            }
        }
    }

}
