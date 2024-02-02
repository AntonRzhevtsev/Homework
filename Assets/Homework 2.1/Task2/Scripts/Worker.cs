using UnityEngine;

public class Worker : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private Transform _workPoint;
    [SerializeField] private Transform _sleepPoint;
    [SerializeField, Range(0, 10)] private float _moveSpeed;
    private float _sleepTime;
    private float _workTime;

    public Vector3 WorkPosition => _workPoint.position;
    public Vector3 SleepPosition => _sleepPoint.position;
    public Vector3 CurrentPosition => transform.position;
    public StateMachine StateMachine => _stateMachine;
    
    public void Initialize()
    {
        _sleepTime = 0f;
        _workTime = 0f;

        _stateMachine = new(this);
    }

    public void MoveToTarget(Vector3 movePosition)
    {
        Vector3 movementPerFrame = Vector3.Normalize(movePosition - CurrentPosition) * _moveSpeed * Time.deltaTime;

        if(movementPerFrame.magnitude < (movePosition - CurrentPosition).magnitude)
            transform.Translate(movementPerFrame);
        else
            transform.Translate(movePosition - CurrentPosition);
    }

    public void Work()
    {
        _workTime += Time.deltaTime;
    }

    public void Sleep()
    {
        _sleepTime += Time.deltaTime;
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();

        PrintWorkerStatistics();
    }

    private void PrintWorkerStatistics()
    {
        if(Input.GetKeyDown(KeyCode.I))
            Debug.Log($"Worked for {_workTime}s. and slept for {_sleepTime}s.");
    }
}
