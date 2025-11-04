using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private float _baseMoveSpeed;
    [SerializeField] private float _baseHealth;

    public Stat MoveSpeed { get; private set; }
    public Stat Health { get; private set; }

    private void Awake()
    {
        MoveSpeed = new Stat(_baseMoveSpeed);
        Health = new Stat(_baseHealth);
    }
}
