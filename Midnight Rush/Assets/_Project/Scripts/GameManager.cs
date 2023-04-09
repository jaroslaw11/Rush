using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opsive.UltimateCharacterController.Traits;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    GameStateManager stateManager;
    public GameObject player;

    protected override void Awake()
    {
        base.Awake();
        stateManager = GetComponent<GameStateManager>();
        player.GetComponent<CharacterHealth>().OnDeathEvent.AddListener(FailGame);
    }

    private void Start()
    {
        stateManager.InitStates();
        TViewManager.Singleton.ResetStates();
        stateManager.ApplyState<StartUIGameState>();
    }

    public void StartGame()
    {
        stateManager.ApplyState<PlayGameState>();
    }

    public void FailGame(Vector3 _arg1, Vector3 _arg2, GameObject _arg3)
    {
        stateManager.ApplyState<FailUIGameState>();
    }

    public void ReloadGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
