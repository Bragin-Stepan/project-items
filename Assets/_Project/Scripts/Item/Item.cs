using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public abstract class Item : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 2f;
    [SerializeField] private float _followSpeed = 20f;

    public bool IsPickedUp { get; private set; }

    protected ItemVFX VFX { get; private set; }
    protected CharacterInventory Inventory { get; private set; }

    protected virtual void Awake()
    {
        VFX = GetComponentInChildren<ItemVFX>();
    }

    private void FixedUpdate()
    {
        if (IsPickedUp == false)
            HorizontalRotate();
    }

    protected virtual void Update()
    {
        if (Inventory != null)
        {
            transform.position = Vector3.Lerp(transform.position, Inventory.ItemPosition, _followSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Inventory.transform.rotation, _followSpeed * Time.deltaTime);
        }
    }

    public virtual void PickUp(CharacterInventory inventory)
    {
        IsPickedUp = true;
        Inventory = inventory;
        VFX.PickUpEffect();
    }

    public virtual void Use(CharacterStats stats)
    {
        Inventory.UnequipItem();
        VFX.UseEffect();
        Inventory = null;
    }

    public virtual void Execute()
    {

        VFX.DestroyEffect();
        Destroy(gameObject);
    }

    private void HorizontalRotate() => transform.Rotate(0, _rotateSpeed, 0);
}
