using System;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private List<StatModifier> _modifiers;
    private bool _isNeedToCalcualte = true;
    private float _baseValue;
    private float _finalValue;

    public Stat(float baseValue)
    {
        _baseValue = baseValue;

        _modifiers = new List<StatModifier>();
    }

    public void AddModifier(StatModifier modifier)
    {
        _modifiers.Add(modifier);
        _isNeedToCalcualte = true;
    }

    public void RemoveModifier(string key)
    {
        _modifiers.RemoveAll(modifier => modifier.Key == key);
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