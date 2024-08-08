using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bomb : Item
{
    [SerializeField] private Material _material;
    [SerializeField] private int _explosionRadius;
    [SerializeField] private int _explosionForce;

    private float _fadeDuration;

    private void Start()
    {
        SetBeginColor();
    }

    public override void Initialize()
    {
        int minLifeTime = 2;
        int maxLifeTime = 5;
        _fadeDuration = Random.Range(minLifeTime, maxLifeTime);

        StartCoroutine(FadeAlphaChannel());
    }

    private IEnumerator FadeAlphaChannel()
    {
        float elapsedTime = 0;
        Color color = _material.color;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, elapsedTime / _fadeDuration);
            _material.color = color;

            yield return null;
        }

        Explode();
        SetActive(false);
        SetBeginColor();
    }

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out Cube cube))
            {
                if (cube.TryGetComponent(out Rigidbody rigidbody))
                {
                    rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
                }
            }
        }
    }

    private void SetBeginColor()
    {
        Color initialColorolor = _material.color;
        initialColorolor.a = 1f;
        _material.color = initialColorolor;
    }
}
