using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float minX = -10;
    [SerializeField] private float maxX = 10;

    private void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        var pos = transform.position;
        Gizmos.DrawCube( new Vector3(minX,pos.y,pos.z), Vector3.one/5 );
        Gizmos.color = Color.red;
        Gizmos.DrawCube( new Vector3(maxX,pos.y,pos.z), Vector3.one/5 );
    }

    private void FixedUpdate(){
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal")/speed,0,0);
        var newX = Mathf.Clamp(transform.position.x + velocity.x, minX, maxX);
        transform.position = new Vector3(newX,transform.position.y,transform.position .z);
    }

    public void ResetPosition(){
        transform.position = new Vector3(0,transform.position.y,transform.position.z);
    }
}
