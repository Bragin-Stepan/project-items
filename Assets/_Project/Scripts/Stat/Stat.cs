using System;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public Stat(float baseValue)
    {
        _baseValue = baseValue;
    }

    private List<StatModifier> _modifiers = new List<StatModifier>();
    private bool _isNeedToCalcualte = true;
    private float _baseValue;
    private float _finalValue;

    public void AddModifier(float value, string source)
    {
        StatModifier toAdd = new StatModifier(value, source);
        _modifiers.Add(toAdd);
        _isNeedToCalcualte = true;
    }

    public void RemoveModifier(string source)
    {
        _modifiers.RemoveAll(modifier => modifier.Source == source);
        _isNeedToCalcualte = true;
    }

    private float GetFinalValue()
    {
        float finalValue = _baseValue;

        foreach (var modifier in _modifiers)
            finalValue = finalValue + modifier.Value;

        return finalValue;
    }

    public float GetValue()
    {
        if (_isNeedToCalcualte)
        {
            _finalValue = GetFinalValue();
            _isNeedToCalcualte = false;
        }

        return _finalValue;
    }

    public void Reset() => _modifiers.Clear();
}