using UnityEngine;

public class MoveUp : ICommand
{
    private Rigidbody _rigidbody;
    private float _speed;
    private Mover _mover;

    public MoveUp(Rigidbody rigidbody, float speed)
    {
        _rigidbody = rigidbody;
        _speed = speed;
    }
    public void Execute()
    {
        _mover = Mover.Instance();
        _mover.Move(_rigidbody, new Vector3(0,0,1), _speed);
    }
}
