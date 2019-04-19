using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour {

    public Recipe mix;

    public bool isComplete = false;

    public GameObject info;
    public InfoHint hint;

    public Sprite emptyImage;
    public Sprite fullImage;
    
	// Use this for initialization
	private void Start () {
        GameObject.Find("Switch").GetComponent<MixerSwitch>().FinishProduct += Mix;

        hint = info.GetComponent<InfoHint>();

        GetComponent<Image>().sprite = emptyImage;

        GetComponent<UIMouseEvent>().InTargetExecute += InTargetExecute;
    }

    private void InTargetExecute(GameObject target) {
        
        EmptyProduct();

    }

    private bool Mix(Collectable[] ingredients, Collectable[] liquids) {
        
        if (ingredients[0] == null) {
            Debug.Log("Need ingredient!");
            return false;
        }
        if (liquids[0] == null) {
            Debug.Log("Need liquid!");
            return false;
        }

        hint.EmptySprites();

        mix.liquids = new Collectable[liquids.Length];
        mix.ingredients = new Collectable[ingredients.Length];
        for (int i = 0; i < liquids.Length; i++)
        {
            mix.liquids[i] = liquids[i];
            //Debug.Log("i = " + i);
            if (liquids[i] != null)
                hint.UpdateSprite(liquids[i].collectType, i, liquids[i].GetSprite());
        }
        for (int i = 0; i < ingredients.Length; i++)
        {
            mix.ingredients[i] = ingredients[i];
            //Debug.Log("i = " + i);
            if (ingredients[i] != null)
                hint.UpdateSprite(ingredients[i].collectType, i, ingredients[i].GetSprite());
        }

        isComplete = true;

        GetComponent<Image>().sprite = fullImage;

        return true;
    }

    private void AddToHint(CollectType type, int index, Sprite sprite) {

        //replaced
        
    }

    public void EmptyProduct() {
        Array.Clear(mix.ingredients, 0, mix.ingredients.Length);
        Array.Clear(mix.liquids, 0, mix.liquids.Length);
        isComplete = false;

        GetComponent<Image>().sprite = emptyImage;
    }

    public void Serve() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, 100)) {
            if (hit.collider.tag == "Customer" && isComplete 
                    && !hit.collider.gameObject.GetComponent<Customer>().isSatisfied) {
                hit.collider.gameObject.GetComponent<Customer>().ServeWith(mix);

                hint.EmptySprites();
                EmptyProduct();
            }
            //Debug.Log("Hit!");
        }
        //Debug.Log(hit.point);
    }




    public void OnDrawGizmos () {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(new Ray(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward));
    }

}
