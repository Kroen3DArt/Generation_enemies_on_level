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
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (true)
        {
            _currentPoint = GetSpawnPosition();
            _currentPoint.Spawn();
            yield return wait;
        }
    }

    private SpawnPoint GetSpawnPosition()
    {
        Transform spawnPosition = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        return spawnPosition.GetComponent<SpawnPoint>();
    }
}
