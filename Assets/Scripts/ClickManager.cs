using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

    public GameManager gm;
    public ElementManager em;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //LOOT GENERATION
    public void GenerateLoot(int planet, int multiplier)
    {

        //used for rng
        float rng;

        //earth generation
        if (planet == gm.earth)
        {
            for (int i = 0; i < em.elementNum; i++)
            {
                rng = Random.Range(0f, 100f);
                //for each element, check if rng is less than the rarity and element is unlocked, if so, change element amount to new value
                if (rng <= em.rarities[i, gm.earth] && em.elementList[i].unlocked == true)
                {
                    em.elementList[i].SetAmount(em.elementList[i].amountNum + multiplier);
                }
            }
        }

    }
}
