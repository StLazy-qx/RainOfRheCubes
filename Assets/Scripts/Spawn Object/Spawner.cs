using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Item
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected Transform Container;
    [SerializeField] protected int Capacity;

    protected ObjectPool<T> Pool;
    protected int TotalSpawned;
    protected int CurrentScore;

    public int CurrentCount => CurrentScore;
    public int TotalSpawnedObjects => TotalSpawned;
    public int TotalCreatedObjects => Pool.TotalCreated;


    private void Awake()
    {
        Pool = new ObjectPool<T>();

        Pool.Initialize(Prefab, Capacity, Container);
    }

    protected virtual void Spawn() {}

    protected virtual void Spawn(Vector3 position) {}

    protected void ActivateObject(Item obj, Vector3 position)
    {
        obj.transform.position = position;

        obj.SetActive(true);
        obj.Initialize();
    }
}
