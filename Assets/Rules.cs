using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class Rules : MonoBehaviour, IPointerClickHandler {

    GameObject rules;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("drpSettings").GetComponent<SettingsContoler>().isOpen = false;
        rules.SetActive(false);
        GameObject.Find("drpSettings").GetComponent<SettingsContoler>().isOpen = false;
    }

    // Use this for initialization
    void Start () {
        rules = GameObject.Find("imgRules");
        rules.SetActive(false);
        //rules.SetActive(true);


    }

    
	
	// Update is called once per frame
	void Update () {
	
	}
}
