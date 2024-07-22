using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObiectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<Cube> _pool = new List<Cube>();

    protected void Initialize(Cube prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Cube newCube = Instantiate(prefab, _container);
            newCube.SetActive(false);
            _pool.Add(newCube);
        }
    }

    protected bool TryGetCube(out Cube cube)
    {
        cube = _pool.FirstOrDefault(number => number.IsActive == false);

        return cube != null;
    }
}
