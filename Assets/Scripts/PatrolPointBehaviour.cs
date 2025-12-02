using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPointBehaviour : IIdleBehaviour
{
    private const float MinDistanceToTarget = 0.1f;
    [SerializeField] private List<Transform> _targets;
    private Mover _mover;
    private Rotator _rotator;
    private Enemy _enemy;
    private float _speed;
    private float _rotationSpeed;
    private Queue<Vector3> _targetsPositions;
    private Vector3 _currentTarget;
    private Vector3 _normalizedDirectionToTarget;
    public PatrolPointBehaviour(Mover mover, Enemy enemy, List<Transform> targets, Rotator rotator,
        float speed, float rotationSpeed)
    {
        _mover = mover;
        _enemy = enemy;
        _targets = targets;
        _rotator = rotator;
        _speed = speed;
        _rotationSpeed = rotationSpeed;
    }

    public void Enter()
    {
        _targetsPositions = new Queue<Vector3>();

        foreach (Transform target in _targets)
            _targetsPositions.Enqueue(target.position);

        SwitchTarget();
    }

    public void Process()
    {
        Vector3 direction = GetDirectionToTargetPoint();
        Debug.Log(direction.magnitude);

        if (direction.magnitude < MinDistanceToTarget)
        {
            Debug.Log("Switch target");
            SwitchTarget();
            return;
        }

        _normalizedDirectionToTarget = direction.normalized;
    }

    public void FixedProcess()
    {
        _mover.ProcessMoveTo(_normalizedDirectionToTarget, _speed);
        _rotator.ProcessRotateTo(_normalizedDirectionToTarget, _rotationSpeed);
    }

    private Vector3 GetDirectionToTargetPoint() => _currentTarget - _enemy.transform.position;

    private void SwitchTarget()
    {
        Debug.Log("Μενÿεμ φελό");
        _currentTarget = _targetsPositions.Dequeue();
        _targetsPositions.Enqueue(_currentTarget);
    }
}
