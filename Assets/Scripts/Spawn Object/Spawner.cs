using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Item
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected Transform Container;
    [SerializeField] protected int Capacity = 10;

    protected ObjectPool<T> Pool;
    protected int TotalCreated;
    protected int CurrentScore;

    public int Size => Capacity;
    public int CurrentCount => CurrentScore;
    public int TotalCreatedObjects => TotalCreated;

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
