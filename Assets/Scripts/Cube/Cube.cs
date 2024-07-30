using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Painter))]

public class Cube : SpawnableObject
{
    private Painter _painter;
    private bool _isDestroyTimerStarted = false;

    public event UnityAction<Vector3> CubeDestroyed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_isDestroyTimerStarted == false)
            {
                _isDestroyTimerStarted = true;

                _painter.ChangeColor();
                StartCoroutine(DestroyAfterRandomTime());
            }
        }
    }

    public override void Initialize()
    {
        _painter = GetComponent<Painter>();

        _painter.SetBeginColor();
    }

    private IEnumerator DestroyAfterRandomTime()
    {
        float randomLifeTime = Random.Range(2f, 5f);

        yield return new WaitForSeconds(randomLifeTime);
        SetActive(false);
        _painter.SetBeginColor();
        CubeDestroyed?.Invoke(transform.position);

        _isDestroyTimerStarted = false;
    }
}
