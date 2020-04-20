using UnityEngine;


public class MyMovingPlatform : MonoBehaviour
{
    #region Fields
    public Transform start;
    public Transform end;
    public float speed;

    private float current;
    private float dir;
    private bool _isEnable = false;
    #endregion

    #region UnityMethods
    private void Start()
    {
        current = 0.0f;
        dir = 1.0f;
    }

    private void Update()
    {
        if (_isEnable)
        {
            Move();
        }
    }
    #endregion

    #region Methods
    private void Move()
    {
        current += dir * speed * Time.deltaTime;
        if (current > 1.0f)
        {
            current = 1.0f;
            dir = -1.0f;
        }
        else if (current < 0.0f)
        {
            current = 0.0f;
            dir = 1.0f;
        }

        transform.position = Vector3.Lerp(start.position, end.position, current);
    }

    public void IsEnable()
    {
        _isEnable = !_isEnable;
    }
    #endregion
}
