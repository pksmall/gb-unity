using UnityEngine;


public class MyTriger : MonoBehaviour
{
    #region UnityMethods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MyEffect myEffect = GetComponent<MyEffect>();
            myEffect.PlayEffect();

            var player = collision.gameObject.GetComponent<MyPlayerHealth>();
            //Destroy(gameObject);
        }
    }
    #endregion
}
