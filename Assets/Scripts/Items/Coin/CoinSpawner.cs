using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private SpawnpointCoin[] _spawnpoints;
    [SerializeField] private float _spawnRate = 2f;
    [SerializeField] private int _capacity = 5;

    private List<SpawnpointCoin> _avalaibleSpawnpoints;
    private ObjectPool<Coin> _pool;

    private IEnumerator Start()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnRate);
        _avalaibleSpawnpoints = new List<SpawnpointCoin>(_spawnpoints);

        _pool = new ObjectPool<Coin>(
            createFunc: () => InstantiateCoin(),
            actionOnGet: (coin) => GetCoin(coin),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            actionOnDestroy: (coin) => DestroyCoin(coin),
            defaultCapacity: _capacity
            );

        while (enabled)
        {
            if(_avalaibleSpawnpoints.Count != 0)
            {
                _pool.Get();
            }

            yield return delay;
        }
    }

    private Coin InstantiateCoin()
    {
        Coin newCoin = Instantiate(_prefab);
        newCoin.Taked += ReleaseCoin;
        return newCoin;
    }

    private void GetCoin(Coin coin)
    {
        SpawnpointCoin takableSpawnpoint = GetAvalaibleSpawnpoint();

        coin.transform.position = takableSpawnpoint.transform.position;
        coin.AddSpawnpoint(takableSpawnpoint);
        coin.gameObject.SetActive(true);
    }

    private SpawnpointCoin GetAvalaibleSpawnpoint()
    {
        if (_avalaibleSpawnpoints.Count == 0)
            return null;

        SpawnpointCoin takableSpawnpoint = _avalaibleSpawnpoints[Random.Range(0, _avalaibleSpawnpoints.Count)];
        _avalaibleSpawnpoints.Remove(takableSpawnpoint);
        return takableSpawnpoint;
    }

    private void ReleaseCoin(Coin coin)
    {
        _avalaibleSpawnpoints.Add(coin.GetSpawnpoint());
        _pool.Release(coin);
    }

    private void DestroyCoin(Coin coin)
    {
        coin.Taked -= ReleaseCoin;
        Destroy(coin.gameObject);
    }
}
