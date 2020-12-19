using System;
using UnityEngine;

public class BonusRaysRotation : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private void FixedUpdate(){
        transform.Rotate(new Vector3(0,1,0),speed);
    }
}