using System;
using UnityEngine;

namespace ArnoPhy2D
{
    public class ArnoRect2D : ArnoShape2D
    {
        [SerializeField]private Vector2 leftDownPoint;
        [SerializeField]private Vector2 rightUpPoint;
        private Vector2 _center;
        private float _radius;

        private void OnDrawGizmosSelected (){
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(leftDownPoint,0.1f);
            Gizmos.DrawSphere(rightUpPoint,0.1f);
            Gizmos.DrawSphere(new Vector3( leftDownPoint.x, rightUpPoint.y),0.1f);
            Gizmos.DrawSphere(new Vector3( rightUpPoint.x, leftDownPoint.y),0.1f);
            Gizmos.DrawLine(leftDownPoint,new Vector3(leftDownPoint.x,rightUpPoint.y));
            Gizmos.DrawLine(leftDownPoint,new Vector3(rightUpPoint.x,leftDownPoint.y));
            Gizmos.DrawLine(rightUpPoint,new Vector3(leftDownPoint.x,rightUpPoint.y));
            Gizmos.DrawLine(rightUpPoint,new Vector3(rightUpPoint.x,leftDownPoint.y));
        }

         protected override void Start(){
            ArnoPhy2DManager.Instance.AddShape(this);
            _center = (rightUpPoint - leftDownPoint) / 2;
            _radius = (leftDownPoint - _center).magnitude;
        }

        public override void GetCollision(out Vector2 point, out Vector2 normal, ArnoShape2D otherShape2D, Vector2 lastPos){
            if (otherShape2D.GetType() == typeof(ArnoRect2D)){
                throw new NotImplementedException();
            }
            if (otherShape2D.GetType() == typeof(ArnoCircle2D)){
                
            }
            point = Vector2.zero;
            normal=  Vector2.zero;
            return;
        }

        public Vector2 GetLeftDown(){
            return leftDownPoint;
        }
        
        public Vector2 GetRightUp(){
            return rightUpPoint;
        }

        public override Vector2 GetWorldCenter(){
            return  gameObject.transform.TransformPoint(_center);
        }

        public override Vector2 GetCenter(){
            return _center;
        }

        public override float GetRadius(){
            return _radius;
        }
    }
}