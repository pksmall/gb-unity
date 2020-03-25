using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _health = 2;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        sprite.color = Color.red;

        if (_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
