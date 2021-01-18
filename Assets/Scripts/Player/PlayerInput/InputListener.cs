using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class InputListener : MonoBehaviour
{
    private ICommandExecutor _movementCommandExecutor;
    private Rigidbody _rigidbody;
    private Player _player;

    private void Start()
    {
        _movementCommandExecutor = MovementCommandExecutor.Instance();
        _rigidbody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            _movementCommandExecutor.AddCommand(new MoveLeft(_rigidbody, _player.MoveSpeed));
        if (Input.GetKey(KeyCode.D))
            _movementCommandExecutor.AddCommand(new MoveRight(_rigidbody, _player.MoveSpeed));
        if (Input.GetKey(KeyCode.W))
            _movementCommandExecutor.AddCommand(new MoveUp(_rigidbody, _player.MoveSpeed));
        if (Input.GetKey(KeyCode.S))
            _movementCommandExecutor.AddCommand(new MoveDown(_rigidbody, _player.MoveSpeed));
    }

    private void FixedUpdate()
    {
        _movementCommandExecutor.ExecuteCommands();
    }
}
