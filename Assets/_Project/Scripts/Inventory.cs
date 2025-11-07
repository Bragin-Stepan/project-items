using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _itemNode;
    [SerializeField] private float _followItemSpeed = 20f;

    public Item Item { get; private set; }

    private void Update()
    {
        if (Item != null)
        {
            Item.transform.position = Vector3.Lerp
            (
                Item.transform.position,
                _itemNode.transform.position,
                _followItemSpeed * Time.deltaTime
            );

            Item.transform.rotation = Quaternion.Lerp
            (
                Item.transform.rotation,
                _itemNode.transform.rotation,
                _followItemSpeed * Time.deltaTime
            );
        }
    }

    public bool TryAddItem(Item item)
    {
        if (Item != null)
            return false;

        Item = item;
        return true;
    }

    public void Clear() => Item = null;
}
