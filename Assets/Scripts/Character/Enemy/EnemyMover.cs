using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Patrol _patrol;
    [SerializeField] private float _threshold = 0.1f;
    [SerializeField] private float _restTime = 2f;

    private Rigidbody2D _rigidbody;
    private Target _currentTarget;
    private float _baseSpeed;
    private WaitForSeconds _restDelay;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _restDelay = new WaitForSeconds(_restTime);
        _baseSpeed = _speed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float direction = Mathf.Sign(transform.position.x - _currentTarget.transform.position.x);

        if (direction == -1)
        {
            _rigidbody.linearVelocity = new Vector2(_speed, 0);
        }
        else
        {
            _rigidbody.linearVelocity = new Vector2(-_speed, 0);
        }
    }

    public IEnumerator Rest()
    {
        _speed = 0;
        yield return _restDelay;
        _speed = _baseSpeed;
    }


    public void SetNewTarget(Target target)
    {
        _currentTarget = target;
    }

    public bool IsReachedTarget()
    {
        if ((transform.position - _currentTarget.transform.position).sqrMagnitude < _threshold)
        {
            return true;
        }

        return false;
    }
}
