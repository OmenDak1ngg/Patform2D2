using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _maxHealth;

    protected virtual void Start()
    {
        _maxHealth = _health;
    }

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

    public void Heal(int healCount)
    {
        _health += healCount;

        if (_health >= _maxHealth)
            _health = _maxHealth;
    }
}
