using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenDoorAnimation(Door door)
    {
        _animator.SetBool("IsOpen", true);
    }

    public void CloseDoorAnimation(Door door)
    {
        _animator.SetBool("IsOpen", false);
    }

}
