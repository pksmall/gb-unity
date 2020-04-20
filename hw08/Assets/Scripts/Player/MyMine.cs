using UnityEngine;


public class MyMine : MonoBehaviour
{
    #region Fields
    [SerializeField] private int _damage = 1;
    #endregion

    #region UnityMethods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
        }       
    }
    #endregion
}
