using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class DoorTrigger : MonoBehaviour
{
    private Door _door;
    private Collider _curentCollider;
    private bool _julikInHaus;
    [SerializeField] private UnityEvent _onJulicInHaus;
    [SerializeField] private UnityEvent _onJulicOutHaus;

    private void Start()
    {
        _door = GetComponentInChildren<Door>();
        _curentCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _door.Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            CheckJulik(other);

            if (!_julikInHaus)
            {
                _onJulicOutHaus.Invoke();
                _door.Close();
            }
            else
            {
                _onJulicInHaus.Invoke();
            }
        }
    }

    private void CheckJulik(Collider other)
    {
        _julikInHaus = _curentCollider.bounds.center.z < other.bounds.center.z;
    }
}
