using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CompoundManager : MonoBehaviour
{

    [SerializeField] GameObject compoundTemplate;
    public GameManager gm;

    //number of compounds (will definitely change over time)
    public int compoundNum;

    //array of all compounds
    public Compound[] compoundList;

    void Start()
    {
        //read compounds.csv
        List<Dictionary<string, object>> compoundData = CSVReader.Read("compounds");
        compoundNum = compoundData.Count;

        compoundList = new Compound[compoundNum];

        //populate the compounds list
        for (int i = 0; i < compoundNum; i++)
        {
            //create a new compound object
            GameObject compound = Instantiate(compoundTemplate);

            //add the new compound to the compoundList
            compoundList[i] = compound.GetComponent<Compound>();

            //ui handling
            compound.SetActive(true);
            compound.transform.SetParent(compoundTemplate.transform.parent, false);

            //set values of the new compound
            compoundList[i].SetText((string)compoundData[i]["Name"]);
            compoundList[i].SetDesc((string)compoundData[i]["Description"]);
            compoundList[i].SetActiveDesc(compoundList[i].description);
            compoundList[i].SetObtain((string)compoundData[i]["Obtain"]);
            compoundList[i].SetAmount(0); //set to 0 by default
            compoundList[i].SetMax(Convert.ToInt32(compoundData[i]["Max"]));
            compoundList[i].SetUnlocked(false); //makes all locked by default
            compoundList[i].SetID(i);
            compoundList[i].SetActive(0);
        }

        //manually unlock water at start
        compoundList[0].SetUnlocked(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
