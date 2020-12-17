using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Transform))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private Transform _transform;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }
    private void Update()
    {
        (bool IsMovingRight, bool IsMovingLeft) values = (false, false);
        Vector3 MovingVector = Vector2.right * _speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            _transform.Translate(MovingVector);
            values = (true, false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _transform.Translate(-MovingVector);
            values = (false, true);
        }
        else if (!Input.anyKey)
        {
            values = (false, false);
        }

        _animator.SetBool("IsMovingRight", values.IsMovingRight);
        _animator.SetBool("IsMovingLeft", values.IsMovingLeft);
    }
}
