
    using System.Linq;
    using UnityEngine;

    public class AddBallBonus : Bonus
    {
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private Vector3 ballPosition;
        public override void Apply(){
            var ball = Instantiate(ballPrefab, ballPosition, Quaternion.identity);
            ball.transform.parent = GameManager.CurrentLevel.transform;
            var newLevelAllObjects = GameManager.CurrentLevel.allObjects.ToList();
            newLevelAllObjects.Add(ball);
            GameManager.CurrentLevel.allObjects = newLevelAllObjects.ToArray();
        }
    }
