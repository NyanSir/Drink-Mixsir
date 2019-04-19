using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour {

    private Bowl bowl;
    private Glass glass;

    private Trashcan_Mice mice;

    private void Awake() {
        bowl = GameObject.Find("Bowl").GetComponent<Bowl>();
        glass = GameObject.Find("Glass").GetComponent<Glass>();
        mice = transform.GetChild(0).GetComponent<Trashcan_Mice>();

        mice.gameObject.SetActive(false);
    }

    public void EmptyBowl() {
        bowl.EmptyContainer();
        glass.EmptyContainer();
    }

    public void ReleaseMice() {
        mice.Release();
    }
    
}
