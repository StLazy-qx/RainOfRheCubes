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
        SetText(_textCubesCount, _spawner.CurrentCubesCount, _spawner.CubeCapacity);
        SetText(_textBombsCount, _spawner.CurrentBombsCount, _spawner.BombCapacity);
        SetTotalText(_textTotalCubesCount, _spawner.TotalCubesCreated);
        SetTotalText(_textTotalBombsCount, _spawner.TotalBombsCreated);
    }

    private void SetText(TextMeshProUGUI textComponent, int currentValue, int capacity)
    {
        textComponent.text = $"{currentValue} / {capacity}";
    }

    private void SetTotalText(TextMeshProUGUI textComponent, int totalValue)
    {
        textComponent.text = $"{totalValue}";
    }
}
