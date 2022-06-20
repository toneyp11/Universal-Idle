using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{

    [SerializeField] GameObject planetTemplate;

    //number of planets. Can change over time
    public const int planetNum = 2;

    //array of all planets
    public PlanetButton[] planetList;

    // Start is called before the first frame update
    void Awake()
    {
        planetList = new PlanetButton[planetNum];

        //populate the planet objects
        for (int i = 0; i < planetNum; i++)
        {
            //create a new planet object
            GameObject planet = Instantiate(planetTemplate);

            //add the new planet to the public array
            planetList[i] = planet.GetComponent<PlanetButton>();

            //ui handling
            planet.SetActive(true);
            planet.transform.SetParent(planetTemplate.transform.parent, false);

            //set values of the new element
            planetList[i].SetText(planetStrings[i]);
            planetList[i].SetID(i);
            planetList[i].SetSprite(sprites[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //list of planet names
    public static readonly string[] planetStrings = { "Earth", "Moon" };

    //list of planet sprites
    public Sprite[] sprites;
}
