using UnityEngine;

public class DestructionBehaviour : IReactionBehaviour
{
    private Enemy _enemy;
    private ParticleSystem _explosion;
    private float _countdown = 2f;
    private float _timer;

    public DestructionBehaviour(Enemy enemy, ParticleSystem explosion)
    {
        _enemy = enemy;
        _explosion = explosion;
    }

    public void FixedProcess()
    {
       
    }

    public void Process()
    {
        _timer += Time.deltaTime;

        if (_timer >= _countdown)
        {
            _explosion.transform.position = _enemy.transform.position;
            _explosion.Play();
            Object.Destroy(_enemy.gameObject);
        }
    }
}
