using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CheckButtonHandler : MonoBehaviour {

    Manager manager;
    Button btn;
    Text img;

    bool endOfGame = false;

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
        if (answers.IndexOf(10) == -1)
        {
            btn.enabled = true;
            btn.GetComponent<Image>().color = new Color32(229, 219, 209, 255);
        }
        else
        {
            btn.enabled = false;
            btn.GetComponent<Image>().color = new Color32(207, 209, 215, 255);
        }
    }

    public void OnBtnClick()
    {
        manager.CheckAnswer();

        //TODO перевести на события
        if (endOfGame)
        {
            NewGame();
        }
        else
            GameObject.Find("Scroll View").GetComponent<ScrollViewHandler>().CreateResultTable();
        
    }

    private void NewGame()
    {
        SceneManager.LoadScene("scene");
    }

    public void EndOfGame()
    {
        btn.GetComponentInChildren<Text>().text = "New";
        endOfGame = true;
    }



    // Update is called once per frame
    void Update () {
	
	}
}
