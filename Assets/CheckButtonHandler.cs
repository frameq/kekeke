using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class CheckButtonHandler : MonoBehaviour {

    Manager manager;
    Button btn;
    Text img;

	// Use this for initialization
	void Start () {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        btn = GameObject.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(OnBtnClick);
        manager.ValueChangedEvent += ButtonState;
	}

    private void ButtonState()
    {
        List<int> answers = manager.GetSelectedNumbers();
        if (answers.IndexOf(10) == -1) btn.enabled = true;
        else btn.enabled = false;
    }

    private void OnBtnClick()
    {

        List<int> a = manager.GetSelectedNumbers();
        string s = "";
        foreach (int k in a)
        {
            s += k.ToString();
        }
        //print(s);

        a = manager.GetTaskNumbers();
        s = "";
        foreach (int k in a)
        {
            s += k.ToString();
        }
        //print(s);

        
        List<int> ab = manager.CheckAnswer();
        //print("in="+ab[0]+"  on="+ ab[1]);
        
        GameObject.Find("Scroll View").GetComponent<ScrollViewHandler>().CreateResultTable();
        
    }



    // Update is called once per frame
    void Update () {
	
	}
}
