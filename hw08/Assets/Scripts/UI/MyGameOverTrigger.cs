using UnityEngine;
using UnityEngine.Events;


public class MyGameOverTrigger : MonoBehaviour
{
    #region Fields
    public UnityEvent OnGamveOverTriger;
    #endregion

    #region UnityMethods
    private void Start()
    {
        if (OnGamveOverTriger == null)
        {
            OnGamveOverTriger = new UnityEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnGamveOverTriger.Invoke();
        }
    }
    #endregion
}
