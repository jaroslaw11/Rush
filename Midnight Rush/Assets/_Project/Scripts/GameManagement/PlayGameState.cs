using UnityEngine;
using Opsive.UltimateCharacterController.Character;

public class PlayGameState : TGameStateBase
{
    [SerializeField] protected GameObject[] accountedObjects;
    [SerializeField] UltimateCharacterLocomotion locomotion;

    public override void Enter()
    {
        base.Enter();
        locomotion.enabled = true;
        if (accountedObjects.Length > 0)
        {
            foreach (GameObject _object in accountedObjects)
            {
                _object.SetActive(true);
            }
        }
    }

    public override void Exit()
    {
        if (accountedObjects.Length > 0)
        {
            foreach (GameObject _object in accountedObjects)
            {
                _object.SetActive(false);
            }
        }
        locomotion.enabled = false;
        base.Exit();
    }

    public override void Initialize()
    {
        
    }
}
