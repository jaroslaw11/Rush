using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartView : TView
{
    [SerializeField] Button startButton;

    public override void Initialize()
    {
        if (!startButton) Debug.LogError("no startButton provided in " + this.name);
        startButton.onClick.AddListener(OnPlayButton);
    }

    public void OnPlayButton()
    {
        GameManager._instance.StartGame();
    }

    public override void Enter()
    {
        base.Enter();
        Cursor.lockState = CursorLockMode.None;
    }

    public override void Exit()
    {
        base.Exit();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
