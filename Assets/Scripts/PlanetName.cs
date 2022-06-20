using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetName : MonoBehaviour
{

    public Text planetName;
 
    // Update is called once per frame
    void Update()
    {
        
    }

    // called to change the display name
    public void ChangeName(string planet)
    {
        planetName.text = planet;
    }
}
