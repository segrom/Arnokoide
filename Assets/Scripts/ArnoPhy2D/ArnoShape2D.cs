using UnityEngine;

namespace ArnoPhy2D
{
    public abstract class ArnoShape2D: MonoBehaviour
    {
        public abstract Vector2 GetWorldCenter();
        public abstract Vector2 GetCenter();
        public abstract float GetRadius();
        
        protected virtual void Start(){
            ArnoPhy2DManager.Instance.AddShape(this);
        }

        protected virtual void OnDestroy(){
            ArnoPhy2DManager.Instance.DeleteShape(this);
        }

        public abstract void GetCollision(out Vector2 point, out Vector2 normal,ArnoShape2D otherShape2D, Vector2 lastPos);
    }
}