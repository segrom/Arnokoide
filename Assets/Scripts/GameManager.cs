using System;
using System.Collections;
using System.Collections.Generic;
using ArnoPhy2D;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ArnoPhy2DManager _phy2DManager;  
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
        _phy2DManager = new ArnoPhy2DManager();
    }

    private void Start(){
        print($"ArnoPhy has {_phy2DManager.GetAllShapes().Length} shapes and {_phy2DManager.GetAllRigidbodies().Length} rb");
    }
}
