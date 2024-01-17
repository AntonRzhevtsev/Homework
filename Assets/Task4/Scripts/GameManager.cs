using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] MouseClickHandler mouseClickHandler;
    IWinCondition _winCondition;
    List<Ball> balls;

    void Start()
    {
        balls = FindObjectsByType<Ball>(FindObjectsSortMode.None).ToList();
        mouseClickHandler.ballDestroyed += CheckGameStatus;
    }
    
    public void SetWinCondition(IWinCondition winCondition) => _winCondition = winCondition;

    void CheckGameStatus(Ball ball)
    {
        balls.Remove(ball);
        if(_winCondition.CheckEndGame(balls))
        {
            PrintGameOver();
            mouseClickHandler.enabled = false;
        }
    }

    void PrintGameOver() => Debug.Log("GAME OVER\nYou win!");

}
