using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private Transform _spawnPlatform;
    [SerializeField] private ObiectPool _pool;
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

        _pool.Initialize(_prefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondBetweenSpawn)
        {
            _elapsedTime = 0;
            float randomPositionX = Random.Range(_minCoordinateSpawnX, _maxCoordinateSpawnX);
            float randomPositionZ = Random.Range(_minCoordinateSpawnZ, _maxCoordinateSpawnZ);
            Vector3 randomPosition = new Vector3(randomPositionX, _spawnPlatform.position.y, randomPositionZ);
            Cube cube = _pool.GetCube(_prefab);

            ActivateCube(cube, randomPosition);
        }
    }

    private void ActivateCube(Cube cube, Vector3 spawnPoint)
    {
        cube.SetActive(true);
        cube.transform.position = spawnPoint;
    }
}
