using UnityEngine;


public class MyEffect : MonoBehaviour
{
    #region Fields
    public ParticleSystem Effect;
    #endregion

    #region Methdos
    public void PlayEffect()
    {
        Effect.Play();
    }
    #endregion
}
