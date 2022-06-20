using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerButton : MonoBehaviour
{

    public GameManager gm;
    public ElementManager em;
    public ShopManager sm;
    public ClickManager cm;
    public Button clickerButton;

    public int clickMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        //multiplier is 1 by default
        clickMultiplier = 1;
        Button btn = clickerButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        //generate which element is to be added
        cm.GenerateLoot(gm.activePlanet, clickMultiplier);
        
    }
}
