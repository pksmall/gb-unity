using UnityEngine;


public class Rotator : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    #region UnityMethods
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 Velocity = _rigidbody2D.velocity;

        float angel = Mathf.Atan2(Velocity.y, Velocity.x) * Mathf.Rad2Deg;
        Debug.Log(angel);

        transform.rotation = Quaternion.Euler(0, 0, angel);

        Debug.Log(transform.rotation.x);
    }
    #endregion
}
