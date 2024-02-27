using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _coin;
    [SerializeField] private Transform _pointStorage;

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
            Instantiate(_coin, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
