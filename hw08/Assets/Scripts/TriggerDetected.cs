using UnityEngine;


public class TriggerDetected : MonoBehaviour
{
    #region Fields
    public bool InTrigger;
    #endregion

    #region UnityMethods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        InTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InTrigger = false;
    }
    #endregion
}
