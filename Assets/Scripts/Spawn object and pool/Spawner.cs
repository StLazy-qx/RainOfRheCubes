using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private Transform _spawnPlatform;
    [SerializeField] private Transform _container;
    [SerializeField] private int _cubePoolCapacity = 10;
    [SerializeField] private int _bombPoolCapacity = 10;
    [SerializeField] private int _secondsBetweenSpawn = 3;

    private ObjectPool<Cube> _cubePool;
    private ObjectPool<Bomb> _bombPool;
    private float _minCoordinateSpawnX;
    private float _maxCoordinateSpawnX;
    private float _minCoordinateSpawnZ;
    private float _maxCoordinateSpawnZ;
    private float _elapsedTime = 0;

    public int BombCapacity => _bombPoolCapacity;
    public int CubeCapacity => _cubePoolCapacity;
    public int CurrentCubesCount { get; private set; }
    public int CurrentBombsCount { get; private set; }
    public int TotalCubesCreated { get; private set; }
    public int TotalBombsCreated { get; private set; }

    private void Start()
    {
        _cubePool = new ObjectPool<Cube>();
        _bombPool = new ObjectPool<Bomb>();

        _cubePool.Initialize(_cubePrefab, _cubePoolCapacity, _container);
        _bombPool.Initialize(_bombPrefab, _bombPoolCapacity, _container);
        SetSpawnCoordinate();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            _elapsedTime = 0;

            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        Cube cube = _cubePool.GetObject();

        cube.CubeDestroyed -= OnCubeDestroyed;
        cube.CubeDestroyed += OnCubeDestroyed;

        float randomPositionX = Random.Range(_minCoordinateSpawnX, _maxCoordinateSpawnX);
        float randomPositionZ = Random.Range(_minCoordinateSpawnZ, _maxCoordinateSpawnZ);
        Vector3 randomPosition = new Vector3(randomPositionX, _spawnPlatform.position.y, randomPositionZ);

        ActivateObject(cube, randomPosition);
        CurrentCubesCount = _cubePool.GetActiveObjectsCount();

        TotalCubesCreated++;
    }

    private void OnCubeDestroyed(Vector3 position)
    {
        Bomb bomb = _bombPool.GetObject();

        ActivateObject(bomb, position);
        CurrentBombsCount = _bombPool.GetActiveObjectsCount();

        TotalBombsCreated++;
    }

    private void ActivateObject(SpawnableObject obj, Vector3 position)
    {
        obj.transform.position = position;

        obj.SetActive(true);
        obj.Initialize();
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
