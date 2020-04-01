using UnityEngine;


public class MyEnemy : MonoBehaviour
{
    #region Fields
    [SerializeField] private int _health = 2;
    [SerializeField] private SpriteRenderer _sprite;
    #endregion

    #region UnityMethods
    void Start()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    #endregion

    #region Methods
    public void Hurt(int damage)
    {
        _health -= damage;
        _sprite.color = Color.red;

        if (_health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    #endregion
}
