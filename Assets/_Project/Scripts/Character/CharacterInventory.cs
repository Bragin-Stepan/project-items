using System.Collections;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    [SerializeField] private Transform _itemNode;

    public Item Item { get; private set; }
    public Vector3 ItemPosition => _itemNode.position;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.gameObject.GetComponent<Item>();

        if (item != null)
            EquipItem(item);
    }

    private void EquipItem(Item item)
    {
        if (Item == null)
        {
            item.PickUp(this);
            Item = item;
        }
    }

    public void UnequipItem() => Item = null;
}
