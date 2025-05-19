using System;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Waypoints[] _waypoints;
    [SerializeField] private EnemyMover _enemyMover;

    private int _currentWaypointIndex;

    private void OnEnable()
    {
        _enemyMover.ReachedWaypoint += SetNextWaypoint;
    }

    private void OnDisable()
    {
        _enemyMover.ReachedWaypoint -= SetNextWaypoint;
    }

    private void Awake()
    {
        _currentWaypointIndex = 0;
        _enemyMover.SetNewWaypoint(GetWaypoint());
    }

    private void SetNextWaypoint()
    {
        _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        _enemyMover.SetNewWaypoint(GetWaypoint());
    }

    private Waypoints GetWaypoint()
    {
        return _waypoints[_currentWaypointIndex];
    }
}
