using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] allObjects;
    public Action OnLevelComplete;

    private void FixedUpdate(){
        if (allObjects.Count(o => o == null) == allObjects.Length){
            OnLevelComplete?.Invoke();
            print("level complete");
            AudioManager.PlaySound("complete");
        }
    }
}
