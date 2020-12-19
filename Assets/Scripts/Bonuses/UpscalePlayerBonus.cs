public class UpscalePlayerBonus : Bonus
{
    public override void Apply(){
        GameManager.PlayerManager.Upscale();
    }
}
