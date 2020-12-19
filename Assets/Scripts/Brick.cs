using System;
using UnityEngine;


public class Brick : MonoBehaviour
{
    [SerializeField] private int lives = 1;
    [SerializeField] private TextMesh livesText;
    [SerializeField] private ParticleSystem dieFx, smashFx;

    private void Start(){
        livesText.text = lives.ToString();
    }

    public void BallCollision(){
        lives--;
        livesText.text = lives.ToString();
        if(lives<=0){
            var fx =Instantiate(dieFx, transform);
            fx.transform.parent = null;
            Destroy(gameObject);
            AudioManager.PlaySound("brickdie");
        }
        else{
            var fx =Instantiate(smashFx, transform);
            fx.transform.parent = null;
            AudioManager.PlaySound("smash");
        }
    }
}