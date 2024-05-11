using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    private SpawnPoint _currentPoint;
    private float _delay = 2f;

    private void Start()
    {
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            _currentPoint = GetSpawnPosition();
            _currentPoint.Spawn();
            yield return new WaitForSeconds(_delay);
        }
    }

    private SpawnPoint GetSpawnPosition()
    {
        Transform spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        return spawnPosition.GetComponent<SpawnPoint>();
    }
}
