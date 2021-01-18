using UnityEngine;

public class MoveLeft : ICommand
{
    private Rigidbody _rigidbody;
    private float _speed;
    private Mover _mover;

    public MoveLeft(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }
    public void Execute()
    {
        _mover = Mover.Instance();
        _mover.Move(_rigidbody, new Vector3(-1, 0, 0), _speed);
    }
}
