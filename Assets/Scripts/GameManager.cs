using System;
using System.Collections;
using System.Collections.Generic;
using ArnoPhy2D;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ArnoPhy2DManager _phy2DManager;
    [SerializeField] private LevelManager[] levels;
    [SerializeField] private int currentLevelNumber = 0;
    [SerializeField] private PlayerController player;
    
    private LevelManager _currentLevel;
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
        _phy2DManager = new ArnoPhy2DManager();
    }

    private void Start(){
        print($"ArnoPhy has {_phy2DManager.GetAllShapes().Length} shapes and {_phy2DManager.GetAllRigidbodies().Length} rb");
        LoadLevel();
    }

    private void OnLevelComplete(){
        if (currentLevelNumber < levels.Length){
            currentLevelNumber++;
        }
        else{
            currentLevelNumber = 0;
        }
        LoadLevel();
    }

    private void LoadLevel(){
        if(_currentLevel!=null)Destroy(_currentLevel.gameObject);
        _currentLevel = Instantiate(levels[currentLevelNumber], Vector3.zero, Quaternion.identity);
        _currentLevel.OnLevelComplete = OnLevelComplete;
        player.ResetPosition();
    }
}
