using UnityEngine;

public class GoToSleepState : State
{
    public GoToSleepState(Worker worker, IStateSwitcher stateMachine) : base(worker, stateMachine) {}

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

        _worker.MoveToTarget(_worker.SleepPosition);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if(Input.GetKeyDown(KeyCode.W))
            IsGoToWorkTriggered = true;
    }

    protected override void CallSwitchStateOnCondition()
    {
        if(IsGoToWorkTriggered)
        {
            _stateMachine.SwitchState<GoToWorkState>();
            IsGoToWorkTriggered = false;
        }
        else if(_worker.CurrentPosition == _worker.SleepPosition)
            _stateMachine.SwitchState<SleepState>();
    }
}
