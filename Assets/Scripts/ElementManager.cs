using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ElementManager : MonoBehaviour
{

    [SerializeField] GameObject elementTemplate;
    public GameManager gm;
    public ShopManager sm;

    //number of elements (should remain 118 but could potentially change)
    public int elementNum;

    //array of all elements
    public Element[] elementList;

    //arrays read from csv
    public string[] elementStrings;
    public float[,] rarities;

    // Start is called before the first frame update
    void Awake()
    {
        //read elements.csv
        List<Dictionary<string, object>> elementData = CSVReader.Read("elements");
        elementNum = elementData.Count;

        elementList = new Element[elementNum];
        elementStrings = new string[elementNum];
        rarities = new float[elementNum, gm.numPlanets];

        //populate the element objects
        for (int i = 0; i < elementNum; i++)
        {
            //create a new element object
            GameObject element = Instantiate(elementTemplate);

            //add the new element to the public array
            elementList[i] = element.GetComponent<Element>();

            //fill in the element strings array
            elementStrings[i] = (string)elementData[i]["Name"];

            //read in element rarities
            ReadRarities(i, elementData);

            //ui handling
            element.SetActive(true);
            element.transform.SetParent(elementTemplate.transform.parent, false);

            //set values of the new element
            elementList[i].SetText((string)elementData[i]["Name"]);
            elementList[i].SetColor((string)elementData[i]["Color"]);
            elementList[i].SetAmount(0); //set all to 0 by default (loading save data comes after this)
            elementList[i].SetUnlocked(false); //lock all elements by default (true for testing)
            elementList[i].SetID(i);

        }

        //manually unlock nitrogen and oxygen by default
        elementList[nitrogen].SetUnlocked(true);
        elementList[oxygen].SetUnlocked(true);
    }

    //reads in the rarities for each planet for an element
    public void ReadRarities(int i, List<Dictionary<string, object>> elementData)
    {
        //earth
        rarities[i, gm.earth] = Convert.ToSingle(elementData[i]["EarthRarity"]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // -- ELEMENT CONSTANTS --
    public int hydrogen = 0;
    public int helium = 1;
    public int lithium = 2;
    public int beryllium = 3;
    public int boron = 4;
    public int carbon = 5;
    public int nitrogen = 6;
    public int oxygen = 7;
    public int fluorine = 8;
    public int neon = 9;
    public int sodium = 10;
    public int magnesium = 11;
    public int aluminum = 12;
    public int silicon = 13;
    public int phosphorus = 14;
    public int sulfur = 15;
    public int chlorine = 16;
    public int argon = 17;
    public int potassium = 18;
    public int calcium = 19;
    public int scandium = 20;
    public int titanium = 21;
    public int vanadium = 22;
    public int chromium = 23;
    public int manganese = 24;
    public int iron = 25;
    public int cobalt = 26;
    public int nickel = 27;
    public int copper = 28;
    public int zinc = 29;
    public int gallium = 30;
    public int germanium = 31;
    public int arsenic = 32;
    public int selenium = 33;
    public int bromine = 34;
    public int krypton = 35;
    public int rubidium = 36;
    public int strontium = 37;
    public int yttrium = 38;
    public int zirconium = 39;
    public int niobium = 40;
    public int molybdenum = 41;
    public int technetium = 42;
    public int ruthenium = 43;
    public int rhodium = 44;
    public int palladium = 45;
    public int silver = 46;
    public int cadmium = 47;
    public int indium = 48;
    public int tin = 49;
    public int antimony = 50;
    public int tellurium = 51;
    public int iodine = 52;
    public int xenon = 53;
    public int cesium = 54;
    public int barium = 55;
    public int lanthanum = 56;
    public int cerium = 57;
    public int praseodymium = 58;
    public int neodymium = 59;
    public int promethium = 60;
    public int samarium = 61;
    public int europium = 62;
    public int gadolinium = 63;
    public int terbium = 64;
    public int dysprosium = 65;
    public int holmium = 66;
    public int erbium = 67;
    public int thulium = 68;
    public int ytterbium = 69;
    public int lutetium = 70;
    public int hafnium = 71;
    public int tantalum = 72;
    public int tungsten = 73;
    public int rhenium = 74;
    public int osmium = 75;
    public int iridium = 76;
    public int platinum = 77;
    public int gold = 78;
    public int mercury = 79;
    public int thallium = 80;
    public int lead = 81;
    public int bismuth = 82;
    public int polonium = 83;
    public int astatine = 84;
    public int radon = 85;
    public int francium = 86;
    public int radium = 87;
    public int actinium = 88;
    public int thorium = 89;
    public int protactinium = 90;
    public int uranium = 91;
    public int neptunium = 92;
    public int plutonium = 93;
    public int americium = 94;
    public int curium = 95;
    public int berkelium = 96;
    public int californium = 97;
    public int einsteinium = 98;
    public int fermium = 99;
    public int mendelevium = 100;
    public int nobelium = 101;
    public int lawrencium = 102;
    public int rutherfordium = 103;
    public int dubnium = 104;
    public int seaborgium =105;
    public int bohrium = 106;
    public int hassium = 107;
    public int meitnerium = 108;
    public int darmstadtium = 109;
    public int roentgenium = 110;
    public int copernicium = 111;
    public int nihonium = 112;
    public int flerovium = 113;
    public int moscovium = 114;
    public int livermorium = 115;
    public int tennessine = 116;
    public int oganesson = 117;
    // -- END CONSTANTS --
    
    //maintained due to issue with initialization that I can't figure out.
    public readonly string[] eStrings = { "Hydrogen", "Helium", "Lithium", "Beryllium", "Boron", "Carbon", "Nitrogen", "Oxygen", "Fluorine", "Neon",
        "Sodium", "Magnesium", "Aluminum", "Silicon", "Phosphorus", "Sulfur", "Chlorine", "Argon", "Potassium", "Calcium",
        "Scandium", "Titanium", "Vanadium", "Chromium", "Manganese", "Iron", "Cobalt", "Nickel", "Copper", "Zinc",
        "Gallium", "Germanium", "Arsenic", "Selenium", "Bromine", "Krypton", "Rubidium", "Strontium", "Yttrium", "Zirconium",
        "Niobium", "Molybdenum", "Technetium", "Ruthenium", "Rhodium", "Palladium", "Silver", "Cadmium", "Indium", "Tin",
        "Antimony", "Tellurium", "Iodine", "Xenon", "Cesium", "Barium", "Lanthanum", "Cerium", "Praseodymium", "Neodymium",
        "Promethium", "Samarium", "Europium", "Gadolinium", "Terbium", "Dysprosium", "Holmium", "Erbium", "Thulium", "Ytterbium",
        "Lutetium", "Hafnium", "Tantalum", "Tungsten", "Rhenium", "Osmium", "Iridium", "Platinum", "Gold", "Mercury",
        "Thallium", "Lead", "Bismuth", "Polonium", "Astatine", "Radon", "Francium", "Radium", "Actinium", "Thorium",
        "Protactinium", "Uranium", "Neptunium", "Plutonium", "Americium", "Curium", "Berkelium", "Californium", "Einsteinium", "Fermium",
        "Mendelevium", "Nobelium", "Lawrencium", "Rutherfordium", "Dubnium", "Seaborgium", "Bohrium", "Hassium", "Meitnerium", "Darmstadtium",
        "Roentgenium", "Copernicium", "Nihonium", "Flerovium", "Moscovium", "Livermorium", "Tennessine", "Oganesson"};

}
