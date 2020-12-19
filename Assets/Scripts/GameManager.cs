using System;
using System.Collections;
using System.Collections.Generic;
using ArnoPhy2D;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ArnoPhy2DManager _phy2DManager;
    
    public static LevelManager CurrentLevel{ get; private set; }
    private LevelManager _currentLevel;
    [SerializeField] private LevelManager[] levels;
    [SerializeField] private int currentLevelNumber = 0;

    public static PlayerManager PlayerManager {get; private set; }
    [SerializeField] public PlayerManager playerManger;
    
    private void Awake(){
        DontDestroyOnLoad(this.gameObject);
        _phy2DManager = new ArnoPhy2DManager();
        PlayerManager = playerManger;
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
        playerManger.CurrentPlayer.ResetPosition();
        playerManger.Default();
        CurrentLevel = _currentLevel;
    }
}
