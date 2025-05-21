using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int _health;

    protected virtual void Death()
    {
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _health = 0;
            Death();
        }
    }
}
