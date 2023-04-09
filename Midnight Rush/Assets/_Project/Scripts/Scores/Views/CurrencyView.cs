using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView 
{
    private Currency currency;
    private Text textView;

    public CurrencyView(Currency _currency, Text _textView)
    {
        currency = _currency;
        textView = _textView;

        if(textView != null)
            currency.m_StatChanged.AddListener(UpdateView);
    }

    public void UpdateView()
    {
        textView.text = currency.Value.ToString();
    }
}
