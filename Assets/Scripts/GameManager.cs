using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


//main class and driver of the save system
public class GameManager : MonoBehaviour

{
    // -- CONSTANTS --

    //planet constants
    public int numPlanets = 2;
    public int earth = 0;
    public int moon = 1;

    //element constants
    public int elementNum;

    //compound constants
    public int compoundNum;

    //saving constants
    public float autosaveInterval = 5.0f;

    // -- END CONSTANTS --

    //UI features
    public PlanetName planetName;
    public PlanetImage planetImage;

    //currently active features
    public int activePlanet;
    public GameObject activeUI;

    //managers
    public ElementManager em;
    public ShopManager sm;
    public CompoundManager cm;

    // Start is called before the first frame update
    void Start()
    {
        //load the save game
        LoadGame();

        //start autosave system
        InvokeRepeating(nameof(SaveGame), 0, autosaveInterval);

        activePlanet = earth;
        elementNum = em.elementNum;
        compoundNum = cm.compoundNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Main function for swapping planets
    public void PlanetSwap(int id, string name, Sprite sprite)
    {
        planetName.ChangeName(name);
        planetImage.ChangeImage(sprite);
        activePlanet = id;
    }


    // -- SAVING AND LOADING DATA --

    //contains all data that will be saved in the SaveGame function
    [Serializable]
    public class SaveData
    {
        //stores the values of each element
        public int[] savedElementAmounts;
        public bool[] savedElementUnlocked;
    }

    //saves player data
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameSaveData.dat");
        SaveData data = new SaveData
        {
            //this is where variables that will be saved go
            savedElementAmounts = new int[elementNum],
            savedElementUnlocked = new bool[elementNum]
        };

        //saves the element values
        for (int i = 0; i < elementNum; i++)
        {
            data.savedElementAmounts[i] = em.elementList[i].amountNum;
            data.savedElementUnlocked[i] = em.elementList[i].unlocked;
        }



            bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved.");
    }

    //loads player data
    public void LoadGame()
    {
        //checks if a save file even exists
        if (!File.Exists(Application.persistentDataPath + "/GameSaveData.dat"))
        {
            Debug.LogError("No Save Data Found!");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/GameSaveData.dat", FileMode.Open);
        SaveData data = (SaveData) bf.Deserialize(file);
        file.Close();

        //verify that all save variables exist
        VerifySaveData(data);

        //this is where the loaded variables will go

        //loads the element values
        for (int i = 0; i < elementNum; i++)
        {
            em.elementList[i].SetAmount(data.savedElementAmounts[i]);
            em.elementList[i].SetUnlocked(data.savedElementUnlocked[i]);
        }

        Debug.Log("Game Data Loaded Successfully.");
    }

    //deletes player data
    public void DeleteGame()
    {
        //checks if a save file even exists
        if (!File.Exists(Application.persistentDataPath + "/GameSaveData.dat"))
        {
            Debug.LogError("No Save Data Found!");
            return;
        }

        File.Delete(Application.persistentDataPath + "/GameSaveData.dat");
        //set all saved variables back to their base state if necessary
        

        Debug.Log("Game Data Deleted...");
    }

    //verifies that all components of save data exist.
    //prevents corruption if new save variables are added
    public void VerifySaveData(SaveData data)
    {

        string debugString = "Save Incompatibility! Resolving...";

        if (data.savedElementAmounts.Length != elementNum)
        {
            Debug.Log(debugString);
            data.savedElementAmounts = new int[elementNum];
        }

        if (data.savedElementUnlocked.Length != elementNum)
        {
            Debug.Log(debugString);
            data.savedElementUnlocked = new bool[elementNum];
        }
    }
}
