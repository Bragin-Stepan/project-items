using System;
using UnityEngine;

public class ItemVFX : MonoBehaviour
{
    [SerializeField] private ParticleSystem _pickUpEffect;
    [SerializeField] private ParticleSystem _useEffectPrefab;
    [SerializeField] private ParticleSystem _destroyEffectPrefab;

    public void UseEffect()
    {
        if (_useEffectPrefab == null)
            return;

        ParticleSystem useEffect = Instantiate(_useEffectPrefab, transform.position, Quaternion.identity);
        useEffect.Play();
    }

    public void DestroyEffect()
    {
        if (_destroyEffectPrefab == null)
            return;

        ParticleSystem destroyEffect = Instantiate(_destroyEffectPrefab, transform.position, Quaternion.identity);
        destroyEffect.Play();
    }

    public void PickUpEffect() => _pickUpEffect.Play();
}
