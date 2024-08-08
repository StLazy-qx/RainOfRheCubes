using UnityEngine;

public class CubesSpawner : Spawner<Cube>
{
    [SerializeField] private Transform _spawnPlatform;
    [SerializeField] private BombsSpawner _bombsSpawner;
    [SerializeField] private int _secondsBetweenSpawn = 3;

    private float _minCoordinateSpawnX;
    private float _maxCoordinateSpawnX;
    private float _minCoordinateSpawnZ;
    private float _maxCoordinateSpawnZ;
    private float _elapsedTime = 0;

    private void Start()
    {
        SetSpawnCoordinate();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            _elapsedTime = 0;

            Spawn();
        }
    }

    protected override void Spawn()
    {
        Cube cube = Pool.GetObject();

        cube.CubeDestroyed -= _bombsSpawner.OnCubeDestroyed;
        cube.CubeDestroyed += _bombsSpawner.OnCubeDestroyed;

        float randomPositionX = Random.Range(_minCoordinateSpawnX, _maxCoordinateSpawnX);
        float randomPositionZ = Random.Range(_minCoordinateSpawnZ, _maxCoordinateSpawnZ);
        Vector3 randomPosition = new Vector3(randomPositionX, _spawnPlatform.position.y, randomPositionZ);

        ActivateObject(cube, randomPosition);
        CurrentScore = Pool.GetActiveObjectsCount();

        TotalCreated++;
    }

    private void SetSpawnCoordinate()
    {
        int halfPlatform = 2;

        _minCoordinateSpawnX = _spawnPlatform.position.x - _spawnPlatform.localScale.x / halfPlatform;
        _maxCoordinateSpawnX = _spawnPlatform.position.x + _spawnPlatform.localScale.x / halfPlatform;
        _minCoordinateSpawnZ = _spawnPlatform.position.x - _spawnPlatform.localScale.x / halfPlatform;
        _maxCoordinateSpawnZ = _spawnPlatform.position.x + _spawnPlatform.localScale.x / halfPlatform;
    }
}
