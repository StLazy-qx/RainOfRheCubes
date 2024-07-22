using UnityEngine;

public class Spawner : ObiectPool
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private Transform _spawnPlatform;
    [SerializeField] private int _spawnCount = 10;
    [SerializeField] private int _secondBetweenSpawn = 2;

    private float _minCoordinateSpawnX;
    private float _maxCoordinateSpawnX;
    private float _minCoordinateSpawnZ;
    private float _maxCoordinateSpawnZ;
    private float _elapsedTime = 0;

    private void Start()
    {
        _minCoordinateSpawnX = _spawnPlatform.position.x - _spawnPlatform.localScale.x / 2;
        _maxCoordinateSpawnX = _spawnPlatform.position.x + _spawnPlatform.localScale.x / 2;
        _minCoordinateSpawnZ = _spawnPlatform.position.x - _spawnPlatform.localScale.x / 2;
        _maxCoordinateSpawnZ = _spawnPlatform.position.x + _spawnPlatform.localScale.x / 2;

        Initialize(_prefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondBetweenSpawn)
        {
            if (TryGetCube(out Cube cube))
            {
                _elapsedTime = 0;
                float randomPositionX = Random.Range(_minCoordinateSpawnX, _maxCoordinateSpawnX);
                float randomPositionZ = Random.Range(_minCoordinateSpawnZ, _maxCoordinateSpawnZ);
                Vector3 randomPosition = new Vector3(randomPositionX, _spawnPlatform.position.y, randomPositionZ);

                SetCube(cube, randomPosition);
            }
        }
    }

    private void SetCube(Cube cube, Vector3 spawnPoint)
    {
        cube.SetActive(true);
        cube.transform.position = spawnPoint;
    }
}
