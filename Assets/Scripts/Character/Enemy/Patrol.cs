using System.Runtime.CompilerServices;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Target[] _targets;
    [SerializeField] private EnemyMover _enemyMover;

    private int _currentTargetIndex;

    private void Start()
    {
        _currentTargetIndex = 0;
        _enemyMover.SetNewTarget(GetTarget());
    }

    private void Update()
    {
        if (_enemyMover.IsReachedTarget())
        {
            StartCoroutine(_enemyMover.Rest());
            _currentTargetIndex = ++_currentTargetIndex % _targets.Length;
            _enemyMover.SetNewTarget(GetTarget());
        }
    }

    private Target GetTarget()
    {
        return _targets[_currentTargetIndex];
    }
}
