using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrolBehaviour : IIdleBehaviour
{
    private Mover _mover;
    private Rotator _rotator;
    private Enemy _enemy;
    private float _speed;
    private float _rotationSpeed;
    private Vector3 _currentTarget;
    private Vector3 _normalizedDirectionToTarget;
    private int _maxRangeToTarget = 5;
    private float _tick = 1f;
    private float _time;

    public RandomPatrolBehaviour(Mover mover, Enemy enemy, Rotator rotator,
        float speed, float rotationSpeed)
    {
        _mover = mover;
        _enemy = enemy;
        _rotator = rotator;
        _speed = speed;
        _rotationSpeed = rotationSpeed;

        SwitchTarget();
    }

    public void Process()
    {
        Vector3 direction = GetDirectionToTargetPoint();
        _time += Time.deltaTime;

        if (_time >= _tick)
        {
            SwitchTarget();
            _time = 0f;
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
        _currentTarget = new Vector3(Random.Range(1, _maxRangeToTarget), _enemy.transform.position.y, Random.Range(1, _maxRangeToTarget));
    }
}
