using System;
using UnityEngine;

public class BonusBrick : MonoBehaviour
{
    [SerializeField]private Bonus myBonus;

    private void Awake(){
        GetComponent<Brick>().OnDie = SpawnBonus;
    }

    private void SpawnBonus(){
        if(myBonus==null || GameManager.CurrentLevel==null)return;
        var bonus = Instantiate(myBonus, transform); 
        bonus.transform.parent = GameManager.CurrentLevel?.transform??null;
    }
}
