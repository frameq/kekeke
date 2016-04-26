using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SettingsContoler : MonoBehaviour, IPointerClickHandler {


    public RectTransform container;
    public bool isOpen;

    public void OnPointerClick(PointerEventData eventData)
    {
        isOpen = !isOpen;
    }



    // Use this for initialization
    void Start () {
        Vector3 scale = container.localScale;
        scale.y = 0;
        container.localScale = scale;
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
            Vector3 scale = container.localScale;
            scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
            container.localScale = scale;
	}
}
