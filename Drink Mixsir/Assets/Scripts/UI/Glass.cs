using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : Container {

    public Recipe mix;

    public bool isComplete = false;

    protected override void Start() {
        base.Start();
        GetComponent<UIMouseEvent>().InTargetExecute += InTargetExecute;
    }

    private void InTargetExecute(GameObject target) {
        
        if (target.tag == "Customer") {
            target.GetComponent<Customer>().ServeWith(mix);
            isComplete = false;
        }

        if (target.name == "TrashCan") {
            EmptyContainer();
            Array.Clear(mix.ingredients, 0, mix.ingredients.Length);
            Array.Clear(mix.liquids, 0, mix.liquids.Length);
        }

    }

    public void CombineWith(Collectable[] ingredients) {
        mix.liquids = new Collectable[innerCollects.Length];
        mix.ingredients = new Collectable[ingredients.Length];
        for (int i = 0; i < innerCollects.Length; i++) {
            mix.liquids[i] = innerCollects[i];
        }
        for (int i = 0; i < ingredients.Length; i++) {
            mix.ingredients[i] = ingredients[i];
        }
        isComplete = true;
    }


}
