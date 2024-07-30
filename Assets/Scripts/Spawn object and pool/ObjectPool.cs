using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool<T> where T : SpawnableObject
{
    private T _template;
    private List<T> _pool;
    private Transform _container;

    public int Capacity { get; private set; }

    public void Initialize(T template, int capacity, Transform container)
    {
        _template = template;
        _container = container;
        _pool = new List<T>(capacity);
        Capacity = capacity;

        for (int i = 0; i < capacity; i++)
        {
            T newObject = Object.Instantiate(_template, _container);

            newObject.SetActive(false);
            _pool.Add(newObject);
        }
    }

    public T GetObject()
    {
        T objectT = _pool.FirstOrDefault(îbj => îbj.IsActive == false);

        if (objectT == null)
        {
            objectT = Object.Instantiate(_template, _container);

            objectT.SetActive(false);
            _pool.Add(objectT);
        }

        return objectT;
    }

    public int GetActiveObjectsCount()
    {
        int count = 0;

        foreach (T obj in _pool)
        {
            if (obj.gameObject.activeInHierarchy)
            {
                count++;
            }
        }

        return count;
    }
}
