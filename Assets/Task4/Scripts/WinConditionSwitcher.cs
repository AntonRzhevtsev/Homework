using UnityEngine;

public class WinConditionSwitcher : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] WinConditions winCondition;
    // Это поле должно быть с атрибутом HideInInspector, а в методе OnValide() становиться доступным, 
    // если winCondition == WinConditions.DestroyBallsByColor
    // Но я не разобрался как это сделать
    [SerializeField] Ball.Colors ballColor;
    
    enum WinConditions
    {
        DestroyAllBalls,
        DestroyBallsByColor
    }

    void Start()
    {
        switch(winCondition)
        {
            case WinConditions.DestroyAllBalls:
                gameManager.SetWinCondition(new DestroyAllBalls());
                break;
            case WinConditions.DestroyBallsByColor:
                gameManager.SetWinCondition(new DestroyBallsByColor(ballColor));
                break;
        }
    }
}
