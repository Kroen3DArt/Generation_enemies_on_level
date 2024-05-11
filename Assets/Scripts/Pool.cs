using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    private int _startSize = 5;
    private int _maxSize = 15;

    private ObjectPool<Enemy> _poolEnemies;

    public void Initialize(Enemy enemyPrefab)
    {
        _poolEnemies = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(enemyPrefab),
            actionOnGet: enemy => enemy.gameObject.SetActive(true),
            actionOnRelease: enemy => enemy.gameObject.SetActive(false),
            actionOnDestroy: Destroy,
            collectionCheck: true,
            defaultCapacity: _startSize,
            maxSize: _maxSize
            );
    }

    public Enemy TakeObject(SpawnPoint spawnPoint, Transform target)
    {
        Enemy enemy = _poolEnemies.Get();
        enemy.Init(spawnPoint, target);
        return enemy;
    }

    public void ReleaseObject(Enemy enemy) => _poolEnemies.Release(enemy);
}
