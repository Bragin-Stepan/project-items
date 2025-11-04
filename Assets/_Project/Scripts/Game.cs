using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    private Character _player;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Init();
    }

    private void Init()
    {
        if (_player != null)
            _player.Kill();

        _player = Instantiate(_characterPrefab, _playerSpawnPoint.position, Quaternion.identity);
    }
}
