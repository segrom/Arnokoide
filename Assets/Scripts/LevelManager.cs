using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] allObjects;
    public Action OnLevelComplete, OnLevelFailed;

    private void FixedUpdate(){
        if (allObjects.Count(o =>o!=null &&  o.CompareTag("Brick")) <=0){
            OnLevelComplete?.Invoke();
            print("level complete");
            AudioManager.PlaySound("complete");
        }
        if(allObjects.Count(o => o!=null && o.CompareTag("Ball") )<=0)
        {
            print("level failed");
            AudioManager.PlaySound("failed");
            OnLevelFailed?.Invoke();
        }
    }
}
