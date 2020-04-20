using UnityEngine;


public class MyHitSound : MonoBehaviour
{
    #region Fields
    public AudioClip[] HitClip;
    #endregion

    #region Methods
    public void Play(int index)
    {
        SFXManager.Instance.Play(HitClip[index], transform.position);
    }
    #endregion
}
