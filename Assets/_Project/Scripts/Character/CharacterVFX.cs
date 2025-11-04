using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem _moveEffect;

    public void MoveEffect() => _moveEffect.Play();
}
