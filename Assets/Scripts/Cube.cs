using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Painter))]

public class Cube : MonoBehaviour
{
    private Painter _painter;
    private HashSet<Platform> _touchedPlatforms;
    private bool _isDestroyTimerStarted = false;
    private bool _isActive;

    public bool IsActive => _isActive;

    private void Start()
    {
        _painter = GetComponent<Painter>();
        _touchedPlatforms = new HashSet<Platform>();

        _painter.SetBeginColor();
    }

    public void SetActive(bool isActive)
    {
        _isActive = isActive;

        gameObject.SetActive(isActive);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_touchedPlatforms.Contains(platform) == false)
            {
                _touchedPlatforms.Add(platform);
                _painter.ChangeColor();

                if (_isDestroyTimerStarted == false)
                {
                    _isDestroyTimerStarted = true;

                    StartCoroutine(DestroyAfterRandomTime());
                }
            }
        }
    }

    private IEnumerator DestroyAfterRandomTime()
    {
        float randomLifeTime = Random.Range(2f, 5f);

        yield return new WaitForSeconds(randomLifeTime);

        SetActive(false);
        _touchedPlatforms.Clear();
        _painter.SetBeginColor();

        _isDestroyTimerStarted = false;
    }
}
