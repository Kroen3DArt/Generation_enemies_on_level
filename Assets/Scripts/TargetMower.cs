using UnityEngine;

public class TargetMower : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _speed = 45;

    private Transform _target;
    private int _firstPoint = 0;
    private int _secondPoint = 1;

    private void Start()
    {
        _target = _movePoints[_firstPoint];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            if (_target == _movePoints[_firstPoint])
                _target = _movePoints[_secondPoint];
            else
                _target = _movePoints[_firstPoint];
        }
    }
}
