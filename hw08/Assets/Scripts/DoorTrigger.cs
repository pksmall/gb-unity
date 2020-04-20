using UnityEngine;
using UnityEngine.Events;


public class DoorTrigger : MonoBehaviour
{
    public UnityEvent OnDoorTriger;

    #region UnityMethods
    private void Start()
    {
        if (OnDoorTriger == null)
        {
            OnDoorTriger = new UnityEvent();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnDoorTriger.Invoke();
        }
    }
    #endregion
}
