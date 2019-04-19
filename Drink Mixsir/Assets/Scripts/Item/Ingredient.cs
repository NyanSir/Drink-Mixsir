using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IngredientType {
    Grass,
    Larva,
    Lemon,
    CatFur,
    MiceHeart,
    Tomato,
    Cheese,
    Grape,
    Celery
}

public class Ingredient : Collectable {

    public IngredientType ingredienType;

}
