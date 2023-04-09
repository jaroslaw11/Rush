using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FailView : TView
{
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;
    [SerializeField] TMP_Text kiilsText;
    
    public override void Initialize()
    {
        kiilsText.text = "Kills: " + ScoreManager._instance.kills.Value;
        restartButton.onClick.AddListener(GameManager._instance.ReloadGame);
        exitButton.onClick.AddListener(()=> 
        {
            Application.Quit();
        });
    }
}
