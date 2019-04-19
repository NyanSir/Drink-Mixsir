using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisher : Customer_Producer {

    public GameObject pool;

    public void DeactivePool() {
        pool.GetComponent<BoxCollider2D>().enabled = false;
    }
    
}
