using Mics;

public class GameModel : Model
{
    public override string Name
    {
        get
        {
            return Consts.GameModel;
        }
    }

    private bool isMegnet;
    public bool IsMegnet
    {
        get
        {
            return isMegnet;
        }
        set
        {
            isMegnet = value;
        }
    }
}