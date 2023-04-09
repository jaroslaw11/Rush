using UnityEngine;
using Opsive.Shared.Events;
using Opsive.Shared.Input;

public abstract class UIGameState : TGameStateBase
{
    UnityInput input;

    public override void Enter()
    {
        base.Enter();
        EventHandler.ExecuteEvent(GameManager._instance.player, "OnEnableGameplayInput", false);
        input.DisableCursor = false;
        UIView.Initialize();
    }

    public override void Exit()
    {
        EventHandler.ExecuteEvent(GameManager._instance.player, "OnEnableGameplayInput", true);
        input.DisableCursor = true;
        base.Exit();
    }

    public override void Initialize()
    {
        input = GameManager._instance.player.GetComponent<UnityInput>();
        
    }
}
