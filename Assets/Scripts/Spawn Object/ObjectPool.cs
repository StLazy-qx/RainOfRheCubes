using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : Item
{
    private T _template;
    private List<T> _pool;
    private Transform _container;

    public int TotalCreated { get; private set; }

    public void Initialize(T template, int initialCapacity, Transform container)
    {
        _template = template;
        _container = container;
        _pool = new List<T>(initialCapacity);
    }

    public T GetObject()
    {
        T objectType = _pool.FirstOrDefault(îbj => îbj.IsActive == false);

        if (objectType == null)
        {
            objectType = Object.Instantiate(_template, _container);

            objectType.SetActive(false);
            _pool.Add(objectType);
        }

        TotalCreated = _pool.Count;

        return objectType;
    }

    public int GetActiveObjectsCount()
    {
        return _pool.Count(obj => obj.gameObject.activeInHierarchy);
    }
}
