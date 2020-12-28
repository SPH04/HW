using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 movingVector = Vector2.right * _speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            transform.Translate(movingVector);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-movingVector);
    }
}
