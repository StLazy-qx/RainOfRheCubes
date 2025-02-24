using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private bool _isActive;

    public bool IsActive => _isActive;

    public void SetActive(bool isActive)
    {
        _isActive = isActive;

        gameObject.SetActive(isActive);
    }

    public abstract void Initialize();
}
