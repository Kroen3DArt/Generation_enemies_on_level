using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnTargetReached;

    private float _speed = 200;
    private Transform _target;

    public void Init(SpawnPoint spawnPoint, Transform target)
    {
        transform.position = spawnPoint.transform.position;
        _target = target;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        transform.LookAt(_target);

        if (transform.position == _target.position)
            OnTargetReached?.Invoke(this);
    }
}
