using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Painter))]

public class Cube : MonoBehaviour
{
    private Painter _painter;
    private bool _isDestroyTimerStarted = false;
    private bool _isActive;

    public bool IsActive => _isActive;

    private void Start()
    {
        _painter = GetComponent<Painter>();

        _painter.SetBeginColor();
    }

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

    public void SetActive(bool isActive)
    {
        _isActive = isActive;

        gameObject.SetActive(isActive);
    }

    private IEnumerator DestroyAfterRandomTime()
    {
        float randomLifeTime = Random.Range(2f, 5f);

        yield return new WaitForSeconds(randomLifeTime);

        SetActive(false);
        _painter.SetBeginColor();

        _isDestroyTimerStarted = false;
    }
}
