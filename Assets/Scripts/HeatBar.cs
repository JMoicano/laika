public class HeatBar : AnimatedBar
{
    public GameController GameController;

    public override float Progress => GameController.CurrentHeat / GameController.MaxHeat;
}
