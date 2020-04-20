using UnityEngine;


public class MyTrap : MonoBehaviour
{
    #region Fields
    [SerializeField] private int _damage = 1;
    #endregion

    #region UnityMethods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MyEffect myEffect = GetComponent<MyEffect>();
            myEffect.PlayEffect();

            var player = collision.gameObject.GetComponent<MyPlayerHealth>();
            player.TakeDamage(_damage);
            //Destroy(gameObject);
        }
    }
    #endregion
}
