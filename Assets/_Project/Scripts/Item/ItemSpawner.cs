using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnPoint> _spawnPoints;
    [SerializeField] private float _cooldown;
    [SerializeField] private List<Item> _itemPrefabs;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            List<ItemSpawnPoint> emptyPoints = GetEmptyPoints();

            if (emptyPoints.Count == 0)
            {
                _time = 0;
                return;
            }

            ItemSpawnPoint spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

            Item item = Instantiate
            (
                _itemPrefabs[Random.Range(0, _itemPrefabs.Count)],
                spawnPoint.transform.position,
                Quaternion.identity
            );

            spawnPoint.Occupy(item);

            _time = 0;
        }
    }

    private List<ItemSpawnPoint> GetEmptyPoints()
    {
        List<ItemSpawnPoint> emptyPoints = new List<ItemSpawnPoint>();

        foreach (ItemSpawnPoint point in _spawnPoints)
        {
            if (point.IsEmpty)
                emptyPoints.Add(point);
        }

        return emptyPoints;
    }
}
