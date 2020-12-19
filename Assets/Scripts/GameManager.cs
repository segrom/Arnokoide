using System;
using System.Collections;
using System.Collections.Generic;
using ArnoPhy2D;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ArnoPhy2DManager _phy2DManager;
    
    public static LevelManager CurrentLevel{ get; private set; }
    public static PlayerController CurrentPlayer {get; private set; }
    
    [SerializeField] private LevelManager[] levels;
    [SerializeField] private int currentLevelNumber = 0;
    [SerializeField] public PlayerController player;
    
    private LevelManager _currentLevel;
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
        _phy2DManager = new ArnoPhy2DManager();
        CurrentPlayer = player;
    }

    private void Start(){
        print($"ArnoPhy has {_phy2DManager.GetAllShapes().Length} shapes and {_phy2DManager.GetAllRigidbodies().Length} rb");
        LoadLevel();
    }

    private void OnLevelComplete(){
        if (currentLevelNumber+1 < levels.Length){
            currentLevelNumber++;
        }
        else{
            currentLevelNumber = 0;
        }
        LoadLevel();
    }

    private void OnLevelFailed(){
        LoadLevel();
    }

    private void LoadLevel(){
        CurrentLevel = null;
        if(_currentLevel!=null)Destroy(_currentLevel.gameObject);
        _currentLevel = Instantiate(levels[currentLevelNumber], Vector3.zero, Quaternion.identity);
        _currentLevel.OnLevelComplete = OnLevelComplete;
        _currentLevel.OnLevelFailed = OnLevelFailed;
        player.ResetPosition();
        CurrentLevel = _currentLevel;
    }
}
