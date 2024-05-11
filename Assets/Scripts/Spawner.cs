using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Pool))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;
    
    private Pool _pool;
    private float _delay = 2f;

    private void Start()
    {
        _pool = GetComponent<Pool>();
        _pool.Initialize(_enemyPrefab);
        StartCoroutine(SpawnWithDelay());
    }

    private void Spawn()
    {
        Enemy enemy = _pool.TakeObject(GetSpawnPosition(_spawnPoints), _target);
        enemy.OnTargetReached += ReturnObjectToPool;
    }

    private IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_delay);
        }
    }

    private Vector3 GetSpawnPosition(Transform[] positions)
    {
        Transform spawnPosition = positions[Random.Range(0, positions.Length)];
        return spawnPosition.position;
    }

    private void ReturnObjectToPool(Enemy enemy)
    {
        enemy.OnTargetReached -= ReturnObjectToPool;
        _pool.ReleaseObject(enemy);
    }
}
