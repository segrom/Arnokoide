using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerController[] players;
    public PlayerController CurrentPlayer{ get; private set; }
    private int _currentPlayerNumber = 1;
    private const int DefaultPlayerNumber = 1;

    private void Awake(){
        CurrentPlayer = players[_currentPlayerNumber];
    }

    public void Upscale(){
        if(_currentPlayerNumber>=players.Length ||  !players[_currentPlayerNumber+1] ) return;
        _currentPlayerNumber++;
        UpdatePlayer();
    }

    public void Downscale(){
        if(_currentPlayerNumber<=0 ||  !players[_currentPlayerNumber-1] ) return;
        _currentPlayerNumber--;
        UpdatePlayer();
    }
    
    public void Default(){
        _currentPlayerNumber=DefaultPlayerNumber;
        UpdatePlayer();
    }

    private void UpdatePlayer(){
        var currentX = CurrentPlayer.transform.position.x;
        CurrentPlayer.ResetPosition();
        CurrentPlayer.gameObject.SetActive(false);
        CurrentPlayer = players[_currentPlayerNumber];
        CurrentPlayer.SetX(currentX);
        CurrentPlayer.gameObject.SetActive(true);
    }
}
