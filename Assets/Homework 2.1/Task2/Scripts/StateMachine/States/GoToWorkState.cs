using UnityEngine;
using System;
using Unity.VisualScripting;

public class GoToWorkState : State
{

    public GoToWorkState(Worker worker, IStateSwitcher stateMachine) : base(worker, stateMachine) {}

    public override void Enter() => base.Enter();

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        _worker.MoveToTarget(_worker.WorkPosition);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if(Input.GetKeyDown(KeyCode.S))
            IsGoToSleepTriggered = true;
    }

    protected override void CallSwitchStateOnCondition()
    {
        if(IsGoToSleepTriggered)
        {
            _stateMachine.SwitchState<GoToSleepState>();
            IsGoToSleepTriggered = false;
        }
        else if(_worker.CurrentPosition == _worker.WorkPosition)
            _stateMachine.SwitchState<WorkState>();
    }
}
