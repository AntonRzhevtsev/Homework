using UnityEngine;

public class WorkState : State
{
    public WorkState(Worker worker, IStateSwitcher stateMachine) : base(worker, stateMachine) {}

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        _worker.Work();
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
    }
}
