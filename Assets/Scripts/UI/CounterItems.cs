using TMPro;
using UnityEngine;

public class CounterItems : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TextMeshProUGUI _textCubesCount;
    [SerializeField] private TextMeshProUGUI _textBombsCount;
    [SerializeField] private TextMeshProUGUI _textTotalCubesCount;
    [SerializeField] private TextMeshProUGUI _textTotalBombsCount;

    private void Update()
    {
        ShowCurrentCountItem(_textCubesCount, _spawner.CurrentCubesCount, _spawner.CubeCapacity);
        ShowCurrentCountItem(_textBombsCount, _spawner.CurrentBombsCount, _spawner.BombCapacity);
        ShowTotalCount(_textTotalCubesCount, _spawner.TotalCubesCreated);
        ShowTotalCount(_textTotalBombsCount, _spawner.TotalBombsCreated);
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
