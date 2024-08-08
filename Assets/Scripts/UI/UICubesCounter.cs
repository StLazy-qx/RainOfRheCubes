using UnityEngine;

public class UICubesCounter : UICounterItems<CubesSpawner, Cube>
{
    private void Update()
    {
        ShowInfo();
    }
}
