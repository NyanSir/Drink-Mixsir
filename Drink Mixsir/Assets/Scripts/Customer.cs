using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {

    public delegate void SatisfyCustomer();
    public event SatisfyCustomer Satisfy;
    
    public Recipe preference;

    public Ingredient[] dislikeIngredients = new Ingredient[5];
    public Liquid[] dislikeLiquids = new Liquid[5];

    protected Product product;

    protected AnimationManager anim;

    public bool isSatisfied;
    protected Collider col;

    public GameObject hint;

    public Sprite drinkImage;
    public Sprite drinkName;
    public bool isOfficial;

    private Drink drink;

    protected virtual void Awake() {
        anim = GetComponent<AnimationManager>();
        col = GetComponent<Collider>();

        drink = GameObject.Find("Drink").GetComponent<Drink>();

        anim.SetAnimationState(AnimationState.Idle);
    }

    // Use this for initialization
    protected virtual void Start () {
        product = GameObject.Find("Product").GetComponent<Product>();

        GetComponent<Touchable>().TouchEvent += OnTouch;

            //Optimize?
            //GameObject.Find("GameManager").GetComponent<GameManager>().AddCustomer();
    }

    // Update is called once per frame
    protected virtual void Update () {
		
	}

    protected virtual void OnTouch() {
        //anim.SetAnimationState(AnimationState.Touched);

        if (!isSatisfied) {
            hint.GetComponent<AnimationManager>().SetAnimationState(AnimationState.Touched);
        }
    }

    public bool ServeWith(Recipe mix) {

        if (isSatisfied) {
            return true;
        }
        
        Debug.Log(gameObject.name + " is served");
        //判断是否有dislike
        if (CompareDislike(dislikeIngredients, mix.ingredients) 
                || CompareDislike(dislikeLiquids, mix.liquids)) {
            Debug.Log(gameObject.name + " DON'T LIKE it!");

            anim.SetAnimationState(AnimationState.Dislike);

            return false;
        }

        //判断是否齐全
        if (ComparePrefer(preference.ingredients, mix.ingredients) 
                && ComparePrefer(preference.liquids, mix.liquids)) {
            Debug.Log(gameObject.name + " LOVE it!!!");

                //Optimize?
            //GameObject.Find("GameManager").GetComponent<GameManager>().SatisfyCustomer();

            Satisfy();
            isSatisfied = true;
            anim.SetAnimationState(AnimationState.Satisfied);
            col.enabled = false;
            hint.SetActive(false);
            //DisplayDrink();
            return true;
        }

        anim.SetAnimationState(AnimationState.Dislike);
        Debug.Log(gameObject.name + " NEED MORE!");
        return false;
        
    }

    private bool CompareDislike(Collectable[] ori, Collectable[] tar) {
        for (int i = 0; i < ori.Length; i++) {
            for (int j = 0; j < tar.Length; j++) {
                if (ori[i] != null && ori[i].Equals(tar[j])) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool ComparePrefer(Collectable[] ori, Collectable[] tar) {
        if (ori.Length != tar.Length) {
            return false;
        }

        bool flag = false;

        for (int i = 0; i < ori.Length; i++) {
            
            if (ori[i] != null) {

                for (int j = 0; j < tar.Length; j++) {
                    if (tar[j] != null) {
                        if (ori[i].Equals(tar[j])) {
                            flag = true;
                            Debug.Log("Customer likes: " + ori[i].name);
                            break;
                        }
                    }
                }

                if (flag) {
                    flag = false;
                } else {
                    return false;
                }

            }
            
        }

        return true;
    }

    public void DisplayHint() {
        hint.SetActive(true);
    }

    public void HideHint() {
        hint.SetActive(false);
    }

    public void DisplayDrink() {
        drink.DisplayDrink(drinkImage, drinkName, isOfficial);
    }

//     private void OnMouseDown() {
//         if (product.isComplete) {
//             ServeWith(product.mix);
//             product.EmptyProduct();
//         }
//     }

}
