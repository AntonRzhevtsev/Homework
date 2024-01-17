using System.Collections.Generic;
using UnityEngine;

public class DestroyAllBalls : IWinCondition
{
    public bool CheckEndGame(List<Ball> balls) => balls.Count > 0 ? false : true;
}
