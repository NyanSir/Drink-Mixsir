using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHintWindow : MonoBehaviour {

    public GameObject hintWindow;

    public float delayTime;
    [SerializeField]
    private float stayTime;

    [SerializeField]
    private bool isMouseStay;
    [SerializeField]
    private bool isDisplay;

    private Vector3[] corners = new Vector3[4];
    private float offsetX;
    private float offsetY;
    
	void Awake () {
        hintWindow.SetActive(false);

        hintWindow.GetComponent<RectTransform>().GetWorldCorners(corners);

        offsetX = (corners[3].x - corners[0].x) / 16;
        offsetY = (corners[1].y - corners[0].y) / 2;
	}

    private void Update() {
        if (isDisplay) {
            OnDisplay();
        } else if (isMouseStay) {
            if (stayTime >= delayTime) {
                isDisplay = true;
            }
            stayTime += Time.deltaTime;
        }
    }

    public void Active() {
        isMouseStay = true; 
    }

    public void OnDisplay() {
        hintWindow.SetActive(true);
        hintWindow.GetComponent<RectTransform>().position = Input.mousePosition + new Vector3(-offsetX, offsetY, 0);
    }

    public void OnDisappear() {
        isMouseStay = false;
        isDisplay = false;
        hintWindow.SetActive(false);
        stayTime = 0;
    }

}
