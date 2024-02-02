using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Worker _worker;    

    private void Start()
    {
        _worker.Initialize();
    }
}
