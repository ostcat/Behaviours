using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    private Transform _point1;
    private Transform _point2;

    public float CalculateDistance(Transform point1, Transform point2)
    {
        Vector3 direction = point2.position - point1.position;
        return direction.magnitude;
    }
}
