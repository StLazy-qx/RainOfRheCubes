using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObiectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<Cube> _pool = new List<Cube>();

    public void Initialize(Cube prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Cube newCube = Instantiate(prefab, _container);
            newCube.SetActive(false);
            _pool.Add(newCube);
        }
    }

    public Cube GetCube(Cube prefab)
    {
        Cube cube = _pool.FirstOrDefault(number => number.IsActive == false);

        if (cube == null)
        {
            cube = Instantiate(prefab, _container);
            cube.SetActive(false);
            _pool.Add(cube);
        }

        return cube;
    }
}
