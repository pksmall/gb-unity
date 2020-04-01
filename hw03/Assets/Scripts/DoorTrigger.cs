using UnityEngine;


public class DoorTrigger : MonoBehaviour
{
    private bool _doorIsClosed;
    #region Fileds
    [SerializeField] private DoorOpen _closedDoor;
    #endregion

    #region UnityMethods
    private void Start()
    {
        _doorIsClosed = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _doorIsClosed)
        {
            StartCoroutine(_closedDoor.OpenThisDoor());
            _doorIsClosed = false;
        }
    }
    #endregion
}
