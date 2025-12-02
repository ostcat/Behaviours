using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroBehaviour : IReactionBehaviour
{
    private float _speed;
    private float _rotationSpeed;
    private Hero _hero;
    private Enemy _enemy;
    private Mover _mover;
    private Rotator _rotator;
    private Vector3 _directionToTarget;

    public AgroBehaviour(Hero hero, Enemy enemy, Mover mover, Rotator rotator, 
        float speed, float rotationSpeed)
    {
        _hero = hero;
        _enemy = enemy;
        _mover = mover;
        _rotator = rotator;
        _speed = speed;
        _rotationSpeed = rotationSpeed;
    }
    public void Enter()
    {

    }

    public void Process()
    {
        Vector3 _directionToTarget = GetDirectionToHeroTarget();
    }

    public void FixedProcess()
    {
        _mover.ProcessMoveTo(_directionToTarget.normalized, _speed);
        _rotator.ProcessRotateTo(_directionToTarget.normalized, _rotationSpeed);
    }

    private Vector3 GetDirectionToHeroTarget() => _hero.transform.position - _enemy.transform.position;
}
