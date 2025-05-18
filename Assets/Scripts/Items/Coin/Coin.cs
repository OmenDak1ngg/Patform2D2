using System;
using UnityEngine;

public class Coin : Item
{
    public event Action<Coin> Taked;

    private SpawnpointCoin _spawnpoint;

    public void TriggerActionTaked()
    {
        Taked?.Invoke(this);
    }

    public void AddSpawnpoint(SpawnpointCoin spawnpoint)
    {
        _spawnpoint = spawnpoint;
    }

    public SpawnpointCoin GetSpawnpoint()
    {
        return _spawnpoint;
    }
}
