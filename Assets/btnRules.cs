using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class btnRules : MonoBehaviour {

    GameObject rules;
    Button btn;
	// Use this for initialization
	void Start () {
        rules = GameObject.Find("imgRules");
        btn = GameObject.Find("Rules").GetComponent<Button>();
        btn.onClick.AddListener(ShowRules);
	}

    private void ShowRules()
    {
        rules.SetActive(true);
        //GameObject.Find("imgRules").SetActive(true);
    }

    // Update is called once per frame
    void Update () {
	    
	}
}
