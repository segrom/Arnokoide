#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
[ExecuteInEditMode]
public class SimpleGridSnap : MonoBehaviour
{
    [SerializeField] private bool isZeroZ = true;
    public void Update(){
        var pos = transform.position;
        var rounded = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), isZeroZ ? 0 : Mathf.Round(pos.z));
        transform.position = rounded;
    
    }
}
#endif