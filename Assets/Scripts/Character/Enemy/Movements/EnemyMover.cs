using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Patrol _patrol;
    [SerializeField] private float _threshold = 0.1f;
    [SerializeField] private float _restTime = 2f;

    private Rigidbody2D _rigidbody;
    private Waypoints _currentWaypoint;
    private float _baseSpeed;
    private WaitForSeconds _restDelay;
    private bool _isResting;

    public event Action ReachedWaypoint;

    private void Start()
    {
        _isResting = false;
        _rigidbody = GetComponent<Rigidbody2D>();
        _restDelay = new WaitForSeconds(_restTime);
        _baseSpeed = _speed;
    }

    private void FixedUpdate()
    {
        if (_isResting)
        {
            _rigidbody.linearVelocity = Vector2.zero;
            return;
        }

        Move();
    }

    private void Move()
    {
        if((transform.position - _currentWaypoint.transform.position).sqrMagnitude < _threshold)
        {
            StartCoroutine(Rest());
            ReachedWaypoint?.Invoke();
            return;
        }

        float direction = Mathf.Sign(transform.position.x - _currentWaypoint.transform.position.x);

        if (direction < 0)
        {
            _rigidbody.linearVelocity = new Vector2(_speed, 0);
        }
        else if(direction > 0)
        {
            _rigidbody.linearVelocity = new Vector2(-_speed, 0);
        }
    }

    private IEnumerator Rest()
    {
        _isResting =  true;
        yield return _restDelay;
        _isResting = false;    
    }


    public void SetNewWaypoint(Waypoints waypoint)
    {
        _currentWaypoint = waypoint;
    }
}
