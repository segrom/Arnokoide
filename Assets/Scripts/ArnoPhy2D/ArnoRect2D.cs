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

        private void OnDrawGizmos(){
            Gizmos.color = Color.yellow;
            Vector2 ru =  (Vector2)transform.position +rightUpPoint, ld = (Vector2)transform.position+leftDownPoint;
            Vector2 lu = (Vector2)transform.position+new Vector2( leftDownPoint.x, rightUpPoint.y), rd =(Vector2)transform.position+ new Vector2( rightUpPoint.x, leftDownPoint.y);
            Gizmos.DrawSphere(ru,0.1f);
            Gizmos.DrawSphere(rd,0.1f);
            Gizmos.DrawSphere(lu,0.1f);
            Gizmos.DrawSphere(ld,0.1f);
            Gizmos.DrawLine(ld,rd);
            Gizmos.DrawLine(ld,lu);
            Gizmos.DrawLine(ru,lu);
            Gizmos.DrawLine(rd,ld);
        }

         protected override void Start(){
            ArnoPhy2DManager.Instance.AddShape(this);
            _center =(rightUpPoint - leftDownPoint) / 2;
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
        
        public Vector2 GetWorldLeftDown(){
            return (Vector2)transform.position + leftDownPoint;
        }
        
        public Vector2 GetWorldRightUp(){
            return (Vector2)transform.position +rightUpPoint;
        }
        
        public Vector2 GetWorldLeftUp(){
            return (Vector2)transform.position + new Vector2(leftDownPoint.x,rightUpPoint.y);
        }
        
        public Vector2 GetWorldRightDown(){
            return  (Vector2)transform.position + new Vector2(rightUpPoint.x,leftDownPoint.y);
        }

        public override Vector2 GetWorldCenter(){
            return  (Vector2)transform.position +  _center;
        }

        public override Vector2 GetCenter(){
            return _center;
        }

        public override float GetRadius(){
            return _radius;
        }
    }
}