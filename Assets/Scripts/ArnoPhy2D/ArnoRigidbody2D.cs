using System;
using System.Collections.Generic;
using UnityEngine;

namespace ArnoPhy2D
{
    [RequireComponent(typeof(ArnoShape2D))]
    public class ArnoRigidbody2D : MonoBehaviour
    {
        public ArnoShape2D MyShape2D{ get; private set; }
        /// <summary>
        /// Call on collision
        /// (point, normal, otherShape)
        /// </summary>
        public Action<Vector2,Vector2 ,ArnoShape2D> OnCollision;

        public Vector2 velocity;
        public Vector2 lastPos;

        private void FixedUpdate(){
            var allRects = ArnoPhy2DManager.Instance.GetAllShapes();
            foreach (ArnoShape2D otherShape2D in allRects){
                if(otherShape2D==MyShape2D) continue;
                if ((MyShape2D.GetWorldCenter() - otherShape2D.GetWorldCenter()).magnitude <=
                    MyShape2D.GetRadius() + otherShape2D.GetRadius()){
                    Vector2 point;
                    Vector2 normal;
                    MyShape2D.GetCollision(out point, out normal, otherShape2D,lastPos);
                    if(point== Vector2.zero && normal == Vector2.zero) continue;
                    OnCollision?.Invoke(point, normal, otherShape2D);
                    velocity = (velocity.normalized + 1.5f*normal).normalized*velocity.magnitude;
                }
            }
            lastPos = transform.position;
            transform.position += (Vector3)velocity;
            
        }

        private void Start(){
            ArnoPhy2DManager.Instance.AddRigidbody(this);
            MyShape2D = GetComponent<ArnoShape2D>();

        }
        
        private void OnDestroy(){
            ArnoPhy2DManager.Instance.DeleteRigidbody(this);
        }
    }
}