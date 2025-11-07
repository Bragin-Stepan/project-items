using System;
using UnityEngine;

public class StatModifier
{
    public float Value;
    public string Key;

    public StatModifier(string key, float value)
    {
        Value = value;
        Key = key;
    }
}