using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    
    public List<ObjectItem> items = new List<ObjectItem>();

    public Dictionary<string, List<GameObject>> prefabs = new Dictionary<string, List<GameObject>>();

    void Awake () {
        CreateObjects();

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		 
	}

    /// <summary>
    /// 依照editor中编辑内容，向字典中添加prefab
    /// </summary>
    public void CreateObjects() {
        if (items != null) {
            foreach (ObjectItem item in items) {
                for (int i = 0; i < item.preStoreNumber; i++) {
                    AddObject(item.name, item.prefab);
                    //Debug.Log(go.name);
                }
                if (item.preStoreNumber <= 0) {
                    AddObject(item.name, null);
                }
            }
        }
        
    }

    /// <summary>
    /// 向字典中添加prefab，并初始化
    /// </summary>
    /// <param name="keyName">键</param>
    /// <param name="valuePrefab">值</param>
    /// <returns>新增的对象</returns>
    private GameObject AddObject(string keyName, GameObject valuePrefab) {
        if (!prefabs.ContainsKey(keyName)) {
            prefabs.Add(keyName, new List<GameObject>());
            AddItem(keyName, valuePrefab);
        }

        if (valuePrefab == null) {
            return null;
        }

        GameObject go = Instantiate(valuePrefab, Vector3.zero, Quaternion.identity);

        //go.name = prefabs[keyName][0].name;
        go.transform.parent = gameObject.transform;
        go.SetActive(false);
        prefabs[keyName].Add(go);
        return go;
    }

    private void AddItem(string name, GameObject prefab) {
        items.Add(new ObjectItem(name, prefab));
    }

    public GameObject Spawn(GameObject valuePrefab) {
        //Debug.Log(keyName);

        string keyName = valuePrefab.name;

        if (!prefabs.ContainsKey(keyName)) {
            prefabs.Add(keyName, new List<GameObject>());
            AddItem(keyName, valuePrefab);
            AddObject(keyName, valuePrefab);
        }

        GameObject go = prefabs[keyName].Find(DeactiveItem);
        if (go == null) {
            //Debug.Log("no more prefab");
            AddObject(keyName, valuePrefab);
            go = prefabs[keyName].Find(DeactiveItem);
        }
        go.SetActive(true);
        return go;
    }



    private static bool DeactiveItem(GameObject go) {
        return !go.activeSelf;
    }

    /// <summary>
    /// 重置GameObject
    /// </summary>
    /// <param name="go">重置对象</param>
    private void ResetObject(GameObject go) {
        go.transform.position = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.SetActive(false);
    }

    public void EmptyPool() {
        foreach (KeyValuePair<string, List<GameObject>> prefab in prefabs) {
            //prefab.Value.Find(DeactiveItem).SetActive(false);
            foreach (GameObject go in prefab.Value) {
                go.SetActive(false);
            }
        }
    }

}
