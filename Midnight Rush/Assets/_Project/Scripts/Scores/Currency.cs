using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Currency : Stat <int>
{
    public Currency(string _saveName):base(_saveName)
    {
        GetCurrencyFromSave();
    }

    public void AddCurrency(int _value)
    {
        Value += _value;
        m_StatChanged.Invoke();
        Debug.Log(saveName + " : " + Value);
    }

    public void DecreaseCurrency(int _value)
    {
        Value -= _value;
        m_StatChanged.Invoke();
    }

    public void SaveCurrency()
    {
        PlayerPrefs.SetInt(saveName, Value);
        PlayerPrefs.Save();
    }

    private void GetCurrencyFromSave()
    {
        Value = PlayerPrefs.GetInt(saveName);
    }
        
}
