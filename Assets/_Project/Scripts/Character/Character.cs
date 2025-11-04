using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Character : MonoBehaviour
{
    [SerializeField] private bool _showDebugGui;
    private CharacterController _controller;
    private CharacterInventory _inventory;
    private CharacterStats _stats;
    private RotateObject _rotate;
    private CharacterVFX _vfx;
    private Vector3 _inputMove;

    private const float DeadZone = 0.1f;
    private const string HorizontalNameInput = "Horizontal";
    private const string VerticalNameInput = "Vertical";

    private void Awake()
    {
        _inventory = GetComponentInChildren<CharacterInventory>();
        _controller = GetComponent<CharacterController>();
        _vfx = GetComponentInChildren<CharacterVFX>();
        _stats = GetComponent<CharacterStats>();

        _rotate = new RotateObject(transform);
    }

    private void Update()
    {
        _inputMove = new Vector3(Input.GetAxisRaw(HorizontalNameInput), 0, Input.GetAxisRaw(VerticalNameInput));

        if (Input.GetKeyDown(KeyCode.F) && _inventory.Item != null)
            _inventory.Item.Use(_stats);
    }

    private void FixedUpdate()
    {
        if (_inputMove.magnitude <= DeadZone)
            return;

        _controller.Move(_inputMove.normalized * _stats.MoveSpeed.GetValue() * Time.deltaTime);
        _rotate.To(_inputMove.normalized);
        _vfx.MoveEffect();
    }

    public void Kill() => gameObject.Off();

    public void OnGUI()
    {
        if (_showDebugGui)
        {
            GUI.Label(new Rect(20, 20, 200, 20), "Скорость движения: " + _stats.MoveSpeed.GetValue());
            GUI.Label(new Rect(20, 40, 200, 20), "Здоровье: " + _stats.Health.GetValue());
            GUI.Label(new Rect(20, 60, 200, 20), "Использовать предмет: " + "F");
            GUI.Label(new Rect(20, 80, 200, 20), "Сброс: " + "R");
        }
    }
}
