using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.Events;

public class DropdownHandler : MonoBehaviour
{

    Dropdown dropdown;
    Manager manager;
    public string object_name;
    public int index;
    //public Sprite imgDisabledState;

    // Use this for initialization
    void Start()
    {
        dropdown = GameObject.Find(object_name).GetComponent<Dropdown>();
        //dropdown.AddOptions(new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " " });
        dropdown.onValueChanged.AddListener(ChangeValue);
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        //DisableSelectedNumbers();
        manager.ValueChangedEvent += ResetSelectedNumbers;
    }

    private void ResetSelectedNumbers()
    {
        //print("index=" + index + " value=" + dropdown.value);
        dropdown.value = manager.GetSelectedNumbers()[index];
        dropdown.RefreshShownValue();
        //manager.SetCounter(index, dropdown.value);

    }

    private void ChangeValue(int arg0)
    {
        manager.SetCounter(index, dropdown.value);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
