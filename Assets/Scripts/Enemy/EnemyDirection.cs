using UnityEngine;

[RequireComponent (typeof(EnemyMovement))]

public class EnemyDirection : MonoBehaviour
{
    [SerializeField] private Transform _storagePoints;

    private Transform[] _spawnPoints;
    private Transform _target;
    private EnemyMovement _movement;

    private int _currentPoint;

    private void Start()
    {
        _movement = GetComponent<EnemyMovement>();

        SetPoints();
    }

    private void Update()
    {
        _movement.SetTarget(_target);

        if (transform.position != _target.position)
            return;

        SetNextPoint();
    }

    private void SetNextPoint()
    {
        _currentPoint++;

        _target = _spawnPoints[_currentPoint % _spawnPoints.Length];
    }

    private void SetPoints()
    {
        _spawnPoints = new Transform[_storagePoints.childCount];

        for (int i = 0; i < _storagePoints.childCount; i++)
        {
            _spawnPoints[i] = _storagePoints.GetChild(i);
        }

        _target = _spawnPoints[_currentPoint];
    }
}
