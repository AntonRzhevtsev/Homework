using UnityEngine;

public class SleepState : State
{

    public SleepState(Worker worker, IStateSwitcher stateMachine) : base(worker, stateMachine) {}

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

        _worker.Sleep();
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
    }
}
