using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private void FixedUpdate(){
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal")/speed,0,0);
        transform.position += velocity;
    }
}
