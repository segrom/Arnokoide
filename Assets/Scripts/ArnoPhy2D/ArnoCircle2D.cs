using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ArnoPhy2D
{
    public class ArnoCircle2D :ArnoShape2D
    {
        [SerializeField]private float radius;
        [SerializeField]private Vector2 center;
        
        
        public override Vector2 GetWorldCenter(){
            return (Vector2)transform.position + center;
        }

        public override Vector2 GetCenter(){
            return center;
        }

        public override float GetRadius(){
            return radius;
        }

        public Vector2 _normal,_point;
        

        public override void GetCollision(out Vector2 point, out Vector2 normal, ArnoShape2D otherShape2D,Vector2 lastPos){
            if (otherShape2D.GetType() == typeof(ArnoCircle2D)){
                normal =_normal= ( GetWorldCenter()-otherShape2D.GetWorldCenter()).normalized;
                point =_point=  otherShape2D.GetWorldCenter() + ( GetWorldCenter()-otherShape2D.GetWorldCenter()).normalized * otherShape2D.GetRadius();
                return;
            }
            else{
                ArnoRect2D rect = (ArnoRect2D) otherShape2D;
                var ld =rect.GetWorldLeftDown();
                var ru =rect.GetWorldRightUp();
                var _center = (Vector2)transform.position+center;
                var lu =rect.GetWorldLeftUp();
                var rd =rect.GetWorldRightDown();
                var pointUp = GetClosestNormalPoint(lu, ru, _center);
                var pointDown = GetClosestNormalPoint(ld, rd, _center);
                var pointLeft = GetClosestNormalPoint(ld, lu, _center);
                var pointRight = GetClosestNormalPoint(rd, ru, _center);
                Vector2 min = pointDown;
                foreach (var p in new []{pointUp, pointDown, pointLeft, pointRight}){
                    if ((_center - p).magnitude < (_center - min).magnitude) min = p;
                }
                if ((_center-min).magnitude <= radius){
                    if (_center.x > ld.x && _center.x < ru.x && _center.y > ld.y && _center.y < ru.y){
                        normal =_normal= -(_center - min).normalized;
                    }
                    else{normal =_normal= (_center - min).normalized;}
                    point =_point= min;
                    //print($"Normal {normal} || point {point}");
                    return;
                }
                normal = Vector2.zero;
                point = Vector2.zero;
            }
        }


        private Vector2 GetClosestNormalPoint(Vector2 c1, Vector2 c2, Vector2 c){
            var minCx = Mathf.Min(c1.x, c2.x);
            var minCy = Mathf.Min(c1.y, c2.y);
            var maxCx = Mathf.Max(c1.x, c2.x);
            var maxCy = Mathf.Max(c1.y, c2.y);
            if( c.y >= minCy&& c.y <= maxCy) return new Vector2(c1.x,c.y);
            if( c.x >= minCx&& c.x <= maxCx) return new Vector2(c.x,c1.y);
            if(c.x > maxCx && c.y < minCy) return new Vector2(maxCx, minCy);
            if(c.x > maxCx && c.y > maxCy) return  new Vector2(maxCx, maxCy);
            if(c.x < minCx && c.y > maxCy) return  new Vector2(minCx, maxCy);
            if(c.x < minCx && c.y < minCy) return  new Vector2(minCx, minCy);
            return new Vector2(float.MaxValue,float.MaxValue);
        }    

        private void OnDrawGizmos(){
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_point,0.1f);
            Gizmos.DrawLine(_point,_point+_normal);
            Gizmos.color = Color.yellow;
            var globalCenter = transform.position + (Vector3)center;
            const float step = 0.1f;
            for (float i = 0; i < 2*Mathf.PI; i+=step){
                var firstPoint = globalCenter + new Vector3(Mathf.Cos(i),Mathf.Sin(i)) * radius;
                var lastPoint = globalCenter + new Vector3(Mathf.Cos(i+step),Mathf.Sin(i+step)) * radius;
                Gizmos.DrawLine(firstPoint,lastPoint);
            }
        }
    }
}