using System.Collections.Generic;
public class StateMachine : IStateSwitcher
{
    private Worker _worker;
    private State _currentState;
    private List<State> _states;

    public StateMachine(Worker worker)
    {
        _worker = worker;

        _states = new()
        {
            new SleepState(_worker, this),
            new GoToWorkState(_worker, this),
            new WorkState(_worker, this),
            new GoToSleepState(_worker, this)
        };

        _currentState = _states.Find(state => state is SleepState);
    }

    public void SwitchState<T>() where T : State
    {
        State newState = _states.Find(state => state is T);

        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void HandleInput()
    {
        _currentState.HandleInput();
    }
}
