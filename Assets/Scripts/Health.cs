using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Max(0f, _currentHealth - damage);

        if (_currentHealth == 0f)
            Kill();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
