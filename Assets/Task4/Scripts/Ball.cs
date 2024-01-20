using UnityEngine;
using static MiniGameEnums;

public class Ball : MonoBehaviour
{
    [SerializeField] private Colors _color;

    public Colors Color 
    {
        get => _color; 
        private set => _color = value;
    } 
}
