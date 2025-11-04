using System;
using UnityEngine;

public class StatModifier
{
    public float Value;
    public string Source;

    public StatModifier(float value, string source)
    {
        Value = value;
        Source = source;
    }
}