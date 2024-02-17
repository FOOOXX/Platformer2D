using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    [SerializeField] private Transform _pointStorage;
    [SerializeField] private Transform _firstAidKit;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[_pointStorage.childCount];

        for (int i = 0; i < _pointStorage.childCount; i++)
        {
            _spawnPoints[i] = _pointStorage.GetChild(i);
        }

        Create();
    }

    private void Create()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_firstAidKit, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
