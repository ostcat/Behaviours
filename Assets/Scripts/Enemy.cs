using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private IReactionBehaviour _reactionBehaviour;
    private IIdleBehaviour _idleBehaviour;
    private IBehaviour _currentBehaviour;
    private DistanceDetector _distanceDetector;
    private Hero _hero;
    [SerializeField] private float _agroDistance = 3;

    public void Initialize (IReactionBehaviour reactionBehaviour, IIdleBehaviour idleBehaviour, Hero hero, DistanceDetector distanceDetector)
    {
        _reactionBehaviour = reactionBehaviour;
        _idleBehaviour = idleBehaviour;
        _hero = hero;
        _distanceDetector = distanceDetector;
        _currentBehaviour = _idleBehaviour;
        _currentBehaviour.Enter();
    }


    private void Update()
    {
        if (_distanceDetector!= null && _distanceDetector.CalculateDistance(_hero.transform, transform) <= _agroDistance)
        {
            _currentBehaviour = _reactionBehaviour;
        }
        else
        {
            _currentBehaviour = _idleBehaviour;
        }

        if(_currentBehaviour != null )
        _currentBehaviour.Process();
    }

    private void FixedUpdate()
    {
        if (_currentBehaviour != null)
            _currentBehaviour.FixedProcess();
    }

    public void SetBehaviour(IBehaviour behaviour)
    {
        _currentBehaviour = behaviour;
        _currentBehaviour.Enter();
    }
}
