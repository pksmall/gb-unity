using System.Collections;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    private Animator _animator;

    #region UnityMethods
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    #endregion

    #region Methods
    public IEnumerator OpenThisDoor()
    {
        _animator.SetBool("SwitchFlipped", true);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
    #endregion
}
