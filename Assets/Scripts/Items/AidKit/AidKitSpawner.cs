using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;
using System.Collections;

public class AidKitSpawner : MonoBehaviour
{
    [SerializeField] private AidKit _prefab;
    [SerializeField] private AidKitSpawnpoint[] _spawnpoints;
    [SerializeField] private float _spawnRate;

    private List<AidKitSpawnpoint> _avalaibleSpawnpoints;
    private ObjectPool<AidKit> _pool;
    private WaitForSeconds _spawnDelay;

    private float _spawnpointCheckRadius = 0.5f;

    private void Start()
    {
        _spawnDelay = new WaitForSeconds(_spawnRate);
        _avalaibleSpawnpoints = new List<AidKitSpawnpoint>(_spawnpoints);
        _pool = InitializePool();

        StartCoroutine(SpawnAidKits());
    }

    private IEnumerator SpawnAidKits()
    {
        while (enabled)
        {
            yield return _spawnDelay;
        
            if (_avalaibleSpawnpoints.Count != 0)
            {
                _pool.Get();
            } 
        }
    }

    private ObjectPool<AidKit> InitializePool()
    {
        return new ObjectPool<AidKit>(
            createFunc:() => InstantiateAidKit(),
            actionOnGet:(aidKit) => GetAidKit(aidKit),
            actionOnDestroy: (aidKit) => DestoyAidKit(aidKit),
            actionOnRelease:(aidKit) => aidKit.gameObject.SetActive(false)
            );
    }

    private AidKit InstantiateAidKit()
    {
        AidKit newAidKit = Instantiate(_prefab);
        newAidKit.Taked += ReleaseAidKit;

        return newAidKit;
    }

    private void GetAidKit(AidKit aidKit)
    {
        if (_avalaibleSpawnpoints.Count == 0)
            return;

        AidKitSpawnpoint takableSpawpoint = GetAvalaibleSpawnpoint();

        aidKit.transform.position = takableSpawpoint.transform.position;
        aidKit.gameObject.SetActive(true);
    }

    private void DestoyAidKit(AidKit aidKit)
    {
        aidKit.Taked -= ReleaseAidKit;  
        Destroy(aidKit.gameObject);
    }

    private void ReleaseAidKit(AidKit aidKit)
    {
        Collider2D collider = Physics2D.OverlapCircle(aidKit.transform.position, _spawnpointCheckRadius);

        if(collider.TryGetComponent(out AidKitSpawnpoint closestSpawnpoint))
        {
            _avalaibleSpawnpoints.Add(closestSpawnpoint);
        }

        _pool.Release(aidKit);
    }

    private AidKitSpawnpoint GetAvalaibleSpawnpoint()
    {
        if (_avalaibleSpawnpoints.Count == 0)
            return null;

        AidKitSpawnpoint takableSpawnpoint = _avalaibleSpawnpoints[Random.Range(0, _avalaibleSpawnpoints.Count)];
        _avalaibleSpawnpoints.Remove(takableSpawnpoint);
        return takableSpawnpoint;
    }
}
