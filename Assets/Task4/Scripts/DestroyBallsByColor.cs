using System.Collections.Generic;

public class DestroyBallsByColor : IWinCondition
{
    Ball.Colors _targetColor;

    public DestroyBallsByColor(Ball.Colors targetColor)
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
