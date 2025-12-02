using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ProcessMoveTo(Vector3 direction, float speed)
    {
        _direction = direction;
        _rigidbody.MovePosition(_rigidbody.position + direction * speed * Time.deltaTime);
    }
}
