using System;
using ArnoPhy2D;
using UnityEngine;

[RequireComponent(typeof(ArnoCircle2D))]
[RequireComponent(typeof(ArnoRigidbody2D))]
public abstract class Bonus: MonoBehaviour
{
    private ArnoCircle2D _circle;
    private ArnoRigidbody2D _rb;
    public abstract void Apply();

    private void Awake(){
        _circle = GetComponent<ArnoCircle2D>();
        _rb = GetComponent<ArnoRigidbody2D>();
        _rb.OnCollision = OnCollision;
    }

    private void OnCollision(Vector2 point,Vector2 normal,ArnoShape2D other){
        if (other.CompareTag("Player")){
            Apply();
            AudioManager.PlaySound("bonus");
            Destroy(gameObject);
        }

        if (other.CompareTag("Finish")){
            Destroy(gameObject);
        }
    }
}