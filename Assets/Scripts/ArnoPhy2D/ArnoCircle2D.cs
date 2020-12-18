using UnityEngine;

namespace ArnoPhy2D
{
    public class ArnoCircle2D :ArnoShape2D
    {
        [SerializeField]private float radius;
        [SerializeField]private Vector2 center;
        
        
        public override Vector2 GetWorldCenter(){
            return gameObject.transform.TransformPoint(center);
        }

        public override Vector2 GetCenter(){
            return center;
        }

        public override float GetRadius(){
            return radius;
        }

        public override void GetCollision(out Vector2 point, out Vector2 normal, ArnoShape2D otherShape2D){
            if (otherShape2D.GetType() == typeof(ArnoCircle2D)){
                normal = (otherShape2D.GetWorldCenter() - GetWorldCenter()).normalized;
                point = (otherShape2D.GetWorldCenter() - GetWorldCenter()) / (otherShape2D.GetRadius() / GetRadius());
                return;
            }
            else{
                otherShape2D.GetCollision(out point, out normal, this);
            }
        }
        
        private void OnDrawGizmosSelected (){
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