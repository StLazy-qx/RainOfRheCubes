using UnityEngine;
using TMPro;

public abstract class UICounterItems<T, N> : MonoBehaviour where T : Spawner<N> where N : Item
{
    [SerializeField] private T _spawner;
    [SerializeField] private TextMeshProUGUI _textCurrentCount;
    [SerializeField] private TextMeshProUGUI _textTotalCount;

    protected void ShowInfo()
    {
        ShowCurrentCountItem(_textCurrentCount, _spawner.CurrentCount, _spawner.TotalCreatedObjects);
        ShowTotalCount(_textTotalCount, _spawner.TotalSpawnedObjects);
    }

    private void ShowCurrentCountItem(TextMeshProUGUI textComponent, int currentValue, int capacity)
    {
        textComponent.text = $"{currentValue} / {capacity}";
    }

    private void ShowTotalCount(TextMeshProUGUI textComponent, int totalValue)
    {
        textComponent.text = $"{totalValue}";
    }
}
