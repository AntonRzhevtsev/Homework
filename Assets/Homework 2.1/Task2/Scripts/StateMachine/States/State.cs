using System;
using UnityEngine;

public abstract class State
{
    protected Worker _worker;
    protected IStateSwitcher _stateMachine;
    protected bool IsGoToWorkTriggered;
    protected bool IsGoToSleepTriggered;

    protected State(Worker worker, IStateSwitcher stateMachine)
    {
        _worker = worker;
        _stateMachine = stateMachine;

        IsGoToWorkTriggered = false;
        IsGoToSleepTriggered = false;
    }

    public virtual void Enter()
    {
        Debug.Log($"Entered state {GetType()}");
    }

    public virtual void Exit()
    {
        Debug.Log($"Exited state {GetType()}");
    }

    public virtual void Update() 
    {
        CallSwitchStateOnCondition();
    }

    public virtual void HandleInput() {}

    protected abstract void CallSwitchStateOnCondition();
}
