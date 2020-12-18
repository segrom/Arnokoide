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
            Gizmos.DrawLine(leftDownPoint,new Vector3(leftDownPoint.x,rightUpPoint.y));
            Gizmos.DrawLine(leftDownPoint,new Vector3(rightUpPoint.x,leftDownPoint.y));
            Gizmos.DrawLine(rightUpPoint,new Vector3(leftDownPoint.x,rightUpPoint.y));
            Gizmos.DrawLine(rightUpPoint,new Vector3(rightUpPoint.x,leftDownPoint.y));
        }

         protected override void Start(){
            ArnoPhy2DManager.Instance.AddShape(this);
            _center = (rightUpPoint - leftDownPoint) / 2;
            _radius = _center.magnitude;
        }

        public override void GetCollision(out Vector2 point, out Vector2 normal, ArnoShape2D otherShape2D){
            if (otherShape2D.GetType() == typeof(ArnoRect2D)){
                throw new NotImplementedException();
            }
            if (otherShape2D.GetType() == typeof(ArnoCircle2D)){
                var localOtherPos = (Vector2)transform.InverseTransformPoint(otherShape2D.GetWorldCenter()) - leftDownPoint;
                var corner = rightUpPoint - leftDownPoint;
                if (localOtherPos.x < corner.x / 2){
                    if (localOtherPos.y < corner.y / 2){
                        if (localOtherPos.x < 0 && localOtherPos.y < 0){
                            point = transform.TransformPoint(Vector2.zero);
                            normal = transform.TransformDirection(localOtherPos.normalized);
                            return;
                        }
                        else{
                            if (localOtherPos.x > localOtherPos.y){
                                point = transform.TransformPoint(new Vector2(0, localOtherPos.y));
                                normal = transform.TransformDirection(Vector2.left);
                                return;
                            }
                            else{
                                point = transform.TransformPoint(new Vector2( localOtherPos.x,0));
                                normal = transform.TransformDirection(Vector2.down);
                                return;
                            }
                        }
                    }
                    else{
                        if (localOtherPos.x < 0 && localOtherPos.y> corner.y){
                            point = transform.TransformPoint(new Vector2(0,corner.y));
                            normal = transform.TransformDirection((localOtherPos - new Vector2(0, corner.y)).normalized);
                            return;
                        }
                        else{
                            if (localOtherPos.y > corner.y){
                                point = transform.TransformPoint(new Vector2(localOtherPos.x, corner.y));
                                normal = transform.TransformDirection(Vector2.up);
                                return;
                            }
                            else{
                                point = transform.TransformPoint(new Vector2( 0, localOtherPos.y));
                                normal = transform.TransformDirection(Vector2.left);
                                return;
                            }
                        }
                    }
                }
                else{
                    if (localOtherPos.y < corner.y / 2){
                        if (localOtherPos.x < corner.x && localOtherPos.y<0){
                            point = transform.TransformPoint(new Vector2(corner.x,0));
                            normal = transform.TransformDirection((localOtherPos - new Vector2(corner.x,0)).normalized);
                            return;
                        }
                        else{
                            if (localOtherPos.x > corner.x){
                                point = transform.TransformPoint(new Vector2(corner.x, localOtherPos.y));
                                normal = transform.TransformDirection(Vector2.right);
                                return;
                            }
                            else{
                                point = transform.TransformPoint(new Vector2( localOtherPos.x,0));
                                normal = transform.TransformDirection(Vector2.down);
                                return;
                            }
                        }
                    }
                    else{
                        if (localOtherPos.x > corner.x && localOtherPos.y > corner.y){
                            point = transform.TransformPoint(corner);
                            normal = transform.TransformDirection((localOtherPos - corner).normalized);
                            return;
                        }
                        else{
                            if (localOtherPos.x > corner.x){
                                point = transform.TransformPoint(new Vector2(corner.x, localOtherPos.y));
                                normal = transform.TransformDirection(Vector2.right);
                                return;
                            }
                            else{
                                point = transform.TransformPoint(new Vector2( localOtherPos.x,corner.y));
                                normal = transform.TransformDirection(Vector2.up);
                                return;
                            }
                        }
                    }
                }
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