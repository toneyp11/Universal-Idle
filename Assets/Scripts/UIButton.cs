using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{

    public GameManager gm;
    public Button uiButton;
    public GameObject newUI;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = uiButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TaskOnClick()
    {
        gm.activeUI.SetActive(false);
        newUI.SetActive(true);
        gm.activeUI = newUI;
    }


}