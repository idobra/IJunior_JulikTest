using UnityEngine;

public class Mover {
    private static Mover _instance = null;

    private Mover()
    {

    }

    public static Mover Instance()
    {
        if (_instance == null)
            _instance = new Mover();
        return _instance;
    }

    public void Move(Rigidbody rigidbody, Vector3 targetDirection, float speed)
    {
        Quaternion rotation = Quaternion.LookRotation(targetDirection);
        rigidbody.rotation = Quaternion.Lerp(rigidbody.rotation, rotation, speed * Time.deltaTime);
        rigidbody.velocity = targetDirection.normalized * speed;
    }
}
