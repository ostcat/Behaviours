using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 150;
    [SerializeField] private float _enemyRotationSpeed = 500;
   
    [SerializeField] private EnemyBig _enemyBigPrefab;
    [SerializeField] private EnemyMedium _enemyMediumPrefab;
    [SerializeField] private EnemySmall _enemySmallPrefab;
    [SerializeField] private Transform _smallEnemySpawnPoint;
    [SerializeField] private Transform _mediumEnemySpawnPoint;
    [SerializeField] private Transform _bigEnemySpawnPoint;
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private Hero _hero;
    [SerializeField] private DistanceDetector _distanceDetector;
    private EnemyBig _bigEnemy;
    private EnemyMedium _mediumEnemy;
    private EnemySmall _smallEnemy;
    private AgroBehaviour _agroBehaviour;
    private PatrolPointBehaviour _patrolPointBehaviour;

    private void Awake()
    {
        _bigEnemy = Instantiate(_enemyBigPrefab, _bigEnemySpawnPoint.position, Quaternion.identity);
        _agroBehaviour = new AgroBehaviour(_hero, _bigEnemy, _bigEnemy.Mover, _bigEnemy.Rotator, _enemySpeed, _enemyRotationSpeed);
        _patrolPointBehaviour = new PatrolPointBehaviour(_bigEnemy.Mover, _bigEnemy, _patrolPoints, _bigEnemy.Rotator, _enemySpeed, _enemyRotationSpeed);
        _bigEnemy.Initialize(_agroBehaviour, _patrolPointBehaviour, _hero, _distanceDetector);
        _patrolPointBehaviour.Enter();

    }


}
