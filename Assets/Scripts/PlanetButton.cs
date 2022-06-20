using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetButton : MonoBehaviour
{
    public GameManager gm;
    public Button planetButton;

    //planet traits
    [SerializeField] private Text myText;
    public string planetName;
    public int planetID;
    public Sprite planetSprite;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = planetButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        gm.PlanetSwap(planetID, planetName, planetSprite);
    }

    public void SetText(string planet)
    {
        myText.text = planet;
        planetName = planet;
    }

    public void SetID(int id)
    {
        planetID = id;
    }

    public void SetSprite(Sprite sprite)
    {
        planetSprite = sprite;
    }
}
