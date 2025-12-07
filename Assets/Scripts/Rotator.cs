using UnityEngine;

public class Rotator : MonoBehaviour
{
    public void ProcessRotateTo(Vector3 direction, float speed)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    public void ProcessRotateAroundY(float speed)
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
