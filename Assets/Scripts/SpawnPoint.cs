using UnityEngine;

[RequireComponent(typeof(Pool))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Pool _pool;

    private void Start()
    {
        _pool.Initialize(_enemyPrefab);
    }

    public void Spawn()
    {
        Enemy enemy = _pool.TakeObject(this, _targetPoint);
        enemy.OnTargetReached += ReturnObjectToPool;
    }

    private void ReturnObjectToPool(Enemy enemy)
    {
        enemy.OnTargetReached -= ReturnObjectToPool;
        _pool.ReleaseObject(enemy);
    }
}
