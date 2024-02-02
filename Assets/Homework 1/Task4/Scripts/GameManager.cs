using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MouseClickHandler _mouseClickHandler;
    private IWinCondition _winCondition;
    private List<Ball> _balls;

    private void Start()
    {
        _balls = FindObjectsByType<Ball>(FindObjectsSortMode.None).ToList();
        _mouseClickHandler.BallDestroyed += CheckGameStatus;
    }
    
    public void SetWinCondition(IWinCondition winCondition) => _winCondition = winCondition;

    private void CheckGameStatus(Ball ball)
    {
        _balls.Remove(ball);
        if(_winCondition.CheckEndGame(_balls))
        {
            PrintGameOver();
            _mouseClickHandler.BallDestroyed -= CheckGameStatus;
            _mouseClickHandler.enabled = false;
        }
    }

    private void PrintGameOver() => Debug.Log("GAME OVER\nYou win!");

}
