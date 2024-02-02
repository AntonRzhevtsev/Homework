using UnityEngine;
using static MiniGameEnums;

public class WinConditionSwitcher : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private WinConditions _winCondition;
    [SerializeField] private Colors _ballColor;

    private void Start()
    {
        switch(_winCondition)
        {
            case WinConditions.DestroyAllBalls:
                _gameManager.SetWinCondition(new DestroyAllBalls());
                break;
            case WinConditions.DestroyBallsByColor:
                _gameManager.SetWinCondition(new DestroyBallsByColor(_ballColor));
                break;
        }
    }
}
