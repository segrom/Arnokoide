using System;
using ArnoPhy2D;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SimpleBall : MonoBehaviour
    {
        private ArnoRigidbody2D rb;

        private void Start(){
            rb = GetComponent<ArnoRigidbody2D>();
            rb.OnCollision = OnCollision;
        }

        private void OnCollision(Vector2 point,Vector2 normal,ArnoShape2D other){
            print(other.name);
            if (other.CompareTag("Brick")){
                var brick = other.GetComponent<Brick>();
                brick.BallCollision();
            }
            else if (other.CompareTag("Finish")){
                Destroy(gameObject);
            }
            else{
                AudioManager.PlaySound("collision");
            }
        }
    }
}