
    using System.Linq;
    using ArnoPhy2D;
    using DefaultNamespace;
    using UnityEngine;

    public class BallSpeedChangeBonus: Bonus
    {
        [SerializeField] private float coefficient = 0.5f;
        public override void Apply(){
            if (GameManager.CurrentLevel == null) return;
            var curBalls = GameManager.CurrentLevel.allObjects.Where(c =>c!=null &&  c.tag=="Ball").ToArray();
            foreach (GameObject ball in curBalls){
                ball.GetComponent<ArnoRigidbody2D>().velocity *= coefficient;
            }
        }
    }
