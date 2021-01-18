using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpen = false;
    private DoorAnimator _doorAnimator;

    private void Start()
    {
        _doorAnimator = GetComponentInParent<DoorAnimator>();
    }

    public void Open()
    {
        if (!_isOpen)
            _doorAnimator.OpenDoorAnimation(this);
        _isOpen = true;
    }

    public void Close()
    {
        if (_isOpen)
            _doorAnimator.CloseDoorAnimation(this);
        _isOpen = false;
    }
}
