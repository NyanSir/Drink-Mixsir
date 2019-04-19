using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Producer : Customer {

    public GameObject output;

    protected override void Awake() {
        base.Awake();
        if (output != null)
            output.SetActive(false);
    }

    protected override void Start() {
        base.Start();
        //this.Satisfy += Produce;
    }

    public void Produce() {
        if (output != null)
            output.SetActive(true);
    }
    
}
