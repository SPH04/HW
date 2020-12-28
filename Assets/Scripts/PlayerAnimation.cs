using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        (bool IsMovingRight, bool IsMovingLeft) values = (false, false);

        if (Input.GetKey(KeyCode.D))
            values = (true, false);
        if (Input.GetKey(KeyCode.A))
            values = (false, true);

        _animator.SetBool("IsMovingRight", values.IsMovingRight);
        _animator.SetBool("IsMovingLeft", values.IsMovingLeft);
    }
}
