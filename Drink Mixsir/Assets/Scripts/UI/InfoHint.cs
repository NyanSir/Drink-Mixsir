using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoHint : MonoBehaviour {
    
    //public Sprite[] hintIngredients = new Sprite[5];
    //public Sprite[] hintLiquids = new Sprite[5];

    [SerializeField]
    private Image[] imgIngredients;
    [SerializeField]
    private Image[] imgLiquids;

    private void Awake() {
        //imgIngredients = transform.GetChild(0).GetComponentsInChildren<Image>();
        //imgLiquids = transform.GetChild(1).GetComponentsInChildren<Image>();
        
        /*
        for (int i = 0; i < imgIngredients.Length; i++) {
            imgIngredients[i].gameObject.SetActive(false);
            imgLiquids[i].gameObject.SetActive(false);
        }
        */
    }

    /*
    public void UpdateSprites(Sprite[] ingredients, Sprite[] liquids) {
        Array.Copy(ingredients, hintIngredients, 0);
        Array.Copy(liquids, hintLiquids, 0);

        int index = 0;
        foreach (Image img in imgIngredients) {
            img.sprite = hintIngredients[index];
            index++;
        }

        index = 0;
        foreach (Image img in imgLiquids) {
            img.sprite = hintLiquids[index];
            index++;
        }
    }
    */

    public void UpdateSprite(CollectType type, int index, Sprite sprite) {
        
        switch (type) {
            case CollectType.Ingredient:
                //hintIngredients[index] = sprite;
                imgIngredients[index].sprite = sprite;
                imgIngredients[index].gameObject.SetActive(true);
                break;

            case CollectType.Liquid:
                //hintLiquids[index] = sprite;
                imgLiquids[index].sprite = sprite;
                imgLiquids[index].gameObject.SetActive(true);
                break;
        }

    }

    public void EmptySprites() {
        for (int i = 0; i < imgIngredients.Length; i++) {
            imgIngredients[i].gameObject.SetActive(false);
            imgLiquids[i].gameObject.SetActive(false);
        }
    }

}
