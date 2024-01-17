using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Colors color;

    public Colors Color 
    {
        get => color; 
        private set => color = value;
    } 

    public enum Colors
    {
        White,
        Green,
        Red
    }
}
