using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 10;
    [SerializeField] private float _enemyRotationSpeed = 500;
    [SerializeField] private float _enemyRotationAroundSpeed = 50;

    [SerializeField] private Enemy _enemyBigPrefab;
    [SerializeField] private Enemy _enemyMediumPrefab;
    [SerializeField] private Enemy _enemySmallPrefab;
    [SerializeField] private Transform _smallEnemySpawnPoint;
    [SerializeField] private Transform _mediumEnemySpawnPoint;
    [SerializeField] private Transform _bigEnemySpawnPoint;
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private Hero _hero;
    [SerializeField] private DistanceDetector _distanceDetector;
    [SerializeField] private ParticleSystem _eplosion;

    private Enemy _bigEnemy;
    private Enemy _mediumEnemy;
    private Enemy _smallEnemy;
    private AgroBehaviour _agroBehaviour;
    private PatrolPointBehaviour _patrolPointBehaviour;
    private StandingBehaviour _standingBehaviour;
    private RunawayBehaviour _runawayBehaviour;
    private RandomPatrolBehaviour _randomPatrolBehaviour;
    private DestructionBehaviour _destructionBehaviour;

    private void Awake()
    {
        _bigEnemy = Instantiate(_enemyBigPrefab, _bigEnemySpawnPoint.position, Quaternion.identity);
        Rotator bigEnemyRotator = GetRotatorComponent(_bigEnemy);
        Mover bigEnemyMover = GetMoverComponent(_bigEnemy);

        _agroBehaviour = new AgroBehaviour(_hero, _bigEnemy, bigEnemyMover, bigEnemyRotator, _enemySpeed, _enemyRotationSpeed);
        _patrolPointBehaviour = new PatrolPointBehaviour(bigEnemyMover, _bigEnemy, _patrolPoints, bigEnemyRotator, _enemySpeed, _enemyRotationSpeed);
        _bigEnemy.Initialize(_agroBehaviour, _patrolPointBehaviour, _hero, _distanceDetector);

        _smallEnemy = Instantiate(_enemySmallPrefab, _smallEnemySpawnPoint.position, Quaternion.identity);
        Rotator smallEnemyRotator = GetRotatorComponent(_smallEnemy);
        Mover smallEnemyMover = GetMoverComponent(_smallEnemy);

        _standingBehaviour = new StandingBehaviour(smallEnemyRotator, _enemyRotationAroundSpeed);
        _runawayBehaviour = new RunawayBehaviour(_hero, _smallEnemy, smallEnemyMover, smallEnemyRotator, _enemySpeed, _enemyRotationSpeed);
        _smallEnemy.Initialize(_runawayBehaviour, _standingBehaviour, _hero, _distanceDetector);

        _mediumEnemy = Instantiate(_enemyMediumPrefab, _mediumEnemySpawnPoint.position, Quaternion.identity);
        Rotator mediumEnemyRotator = GetRotatorComponent(_mediumEnemy);
        Mover mediumEnemyMover = GetMoverComponent(_mediumEnemy);

        _randomPatrolBehaviour = new RandomPatrolBehaviour(mediumEnemyMover, _mediumEnemy, mediumEnemyRotator, _enemySpeed, _enemyRotationSpeed);
        _destructionBehaviour = new DestructionBehaviour(_mediumEnemy, _eplosion);
        _mediumEnemy.Initialize(_destructionBehaviour, _randomPatrolBehaviour, _hero, _distanceDetector);
    }

    private Mover GetMoverComponent(Enemy enemy)
    {
       return enemy.GetComponent<Mover>();
    }

    private Rotator GetRotatorComponent(Enemy enemy)
    {
        return enemy.GetComponent<Rotator>();
    }
}
