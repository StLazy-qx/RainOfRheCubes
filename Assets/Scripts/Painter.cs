using UnityEngine;

public class Painter : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    private Renderer _renderer;
    private int _numberBeginColot = 0;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetBeginColor()
    {
        if (_materials.Length > 0)
        {
            _renderer.material = _materials[_numberBeginColot];
        }
    }

    public void ChangeColor()
    {
        if (_materials.Length > 0)
        {
            Material randomMaterial = _materials[Random.Range(0, _materials.Length)];
            _renderer.material = randomMaterial;
        }
    }
}
