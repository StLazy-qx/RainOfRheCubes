using UnityEngine;

public class BombsSpawner : Spawner<Bomb>
{
    public void OnCubeDestroyed(Vector3 position)
    {
        Spawn(position);
    }

    protected override void Spawn(Vector3 position)
    {
        Bomb bomb = Pool.GetObject();

        ActivateObject(bomb, position);

        CurrentScore = Pool.GetActiveObjectsCount();
        TotalCreated++;
    }
}
