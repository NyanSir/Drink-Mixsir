using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectItem {

    public string name;
    public GameObject prefab;

    public int preStoreNumber;

    public ObjectItem(string _name, GameObject _prefab) {
        this.name = _name;
        this.prefab = _prefab;
    }

    public ObjectItem(GameObject _prefab) {
        this.name = _prefab.name;
        this.prefab = _prefab;
    }

}
