using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Surrender : MonoBehaviour {

    Manager manager;
    Button btn;
    CheckButtonHandler chkBtn;
	// Use this for initialization
	void Start () {
        chkBtn = GameObject.Find("Button").GetComponent<CheckButtonHandler>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        btn = GameObject.Find("Surender").GetComponent<Button>();
        btn.onClick.AddListener(Surender);
	}

    private void Surender()
    {
        manager.Surender();
        chkBtn.OnBtnClick();
        GameObject.Find("drpSettings").GetComponent<SettingsContoler>().isOpen = false;

    }

    // Update is called once per frame
    void Update () {
	
	}
}
