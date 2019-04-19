using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BoxColliderAdaption))]
public class BoxColliderAdaptionEditor : Editor {

    public bool autoAdapt;

    public float mutiply;

    public BoxCollider2D[] targetColliders2D;
    public BoxCollider[] targetColliders;
    
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        BoxColliderAdaption ca = (BoxColliderAdaption)target;
        autoAdapt = ca.autoAdapt;
        mutiply = ca.mutiply;
        targetColliders2D = ca.targetColliders2D;
        targetColliders = ca.targetColliders;

        if (autoAdapt) {
            foreach (BoxCollider2D c2d in targetColliders2D) {
                if (c2d != null) {
                    c2d.size = new Vector2(ca.GetComponent<RectTransform>().rect.width * mutiply,
                                            ca.GetComponent<RectTransform>().rect.height * mutiply);
                } else {
                    //Debug.LogError("BoxColliderAdaption - " + "Cannot Find BoxCollider2D");
                }
            }

            foreach (BoxCollider c in targetColliders) {
                if (c != null) {
                    c.size = new Vector3(ca.GetComponent<RectTransform>().rect.width * mutiply,
                                            ca.GetComponent<RectTransform>().rect.height * mutiply, 1);
                } else {
                    //Debug.LogError("BoxColliderAdaption - " + "Cannot Find BoxCollider2D");
                }
            }
        }

    }

}
