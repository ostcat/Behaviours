using UnityEngine;

public class DistanceDetector : MonoBehaviour
{
    public float CalculateDistance(Transform point1, Transform point2)
    {
        Vector3 direction = point2.position - point1.position;
        return direction.magnitude;
    }
}
