using UnityEngine;

public class RunawayBehaviour : IReactionBehaviour
{
    private float _speed;
    private float _rotationSpeed;
    private Hero _hero;
    private Enemy _enemy;
    private Mover _mover;
    private Rotator _rotator;
    private Vector3 _directionToMove;

    public RunawayBehaviour(Hero hero, Enemy enemy, Mover mover, Rotator rotator,
        float speed, float rotationSpeed)
    {
        _hero = hero;
        _enemy = enemy;
        _mover = mover;
        _rotator = rotator;
        _speed = speed;
        _rotationSpeed = rotationSpeed;
    }

    public void Process()
    {
        _directionToMove = GetDirectionFromHeroTarget();
    }

    public void FixedProcess()
    {
        _mover.ProcessMoveTo(_directionToMove.normalized, _speed);
        _rotator.ProcessRotateTo(_directionToMove.normalized, _rotationSpeed);  
    }

    private Vector3 GetDirectionFromHeroTarget()
    {
        return _enemy.transform.position -_hero.transform.position;
    }
}
