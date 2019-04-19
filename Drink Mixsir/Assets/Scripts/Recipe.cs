using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Recipe {
    public Collectable[] ingredients;
    public Collectable[] liquids;
}