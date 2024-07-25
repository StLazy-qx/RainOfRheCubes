using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObiectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<Cube> _pool = new List<Cube>();

    public void Initialize(Cube template)
    {
        for (int i = 0; i < _capacity; i++)
        {
            AddCubeToPool(template);
        }
    }

    public Cube GetCube(Cube template)
    {
        Cube cube = _pool.FirstOrDefault(number => number.IsActive == false);

        if (cube == null)
        {
            cube = AddCubeToPool(template);
        }

        return cube;
    }

    private Cube AddCubeToPool(Cube template)
    {
        Cube newCube = Instantiate(template, _container);
        newCube.SetActive(false);
        _pool.Add(newCube);
        return newCube;
    }
}
