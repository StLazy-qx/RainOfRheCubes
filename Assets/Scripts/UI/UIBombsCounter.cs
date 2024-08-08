using UnityEngine;

public class UIBombsCounter : UICounterItems<BombsSpawner, Bomb>
{
    private void Update()
    {
        ShowInfo();
    }
}
