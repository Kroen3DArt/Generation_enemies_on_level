using UnityEngine;

public class TargetMower : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _speed = 45;

    private Transform _target;

    private void Start()
    {
        _target = _endPoint;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            if (_target == _endPoint)
                _target = _startPoint;
            else
                _target = _endPoint;
        }
    }
}
