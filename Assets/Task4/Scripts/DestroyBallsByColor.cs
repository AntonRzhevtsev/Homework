using System.Collections.Generic;
using static MiniGameEnums;

public class DestroyBallsByColor : IWinCondition
{
    private Colors _targetColor;

    public DestroyBallsByColor(Colors targetColor)
    {
        _targetColor = targetColor;
    }

    public bool CheckEndGame(List<Ball> balls)
    {
        foreach(Ball ball in balls)
            if(ball.Color == _targetColor)
                return false;
        
        return true;
    }
}
