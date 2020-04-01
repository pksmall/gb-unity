using UnityEngine;


public class MyPlayer : MonoBehaviour
{
    private Rigidbody2D _rigibody2d;
    private float _visualDirection;

    #region Fields
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _heightJump;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform StartBullet;
    #endregion

    #region UnityMethods
    private void Start()
    {       
        _visualDirection = 1.0f;
        _rigibody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 scale = transform.localScale;
        scale.x = _visualDirection;
        transform.localScale = scale;

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1")) Fire();
    }
    #endregion

    #region Methods
    public void AddHealth()
    {
        _health += 1;
    }

    private void MoveLeft()
    {
        //_rigibody2d.AddForce(new Vector2(-_speed, 0), ForceMode2D.Force);
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        _visualDirection = -1.0f;

    }

    private void MoveRight()
    {
        //_rigibody2d.AddForce(new Vector2(_speed, 0), ForceMode2D.Force);
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        _visualDirection = 1.0f;
    }

    private void Jump()
    {
        transform.Translate(Vector3.up * _heightJump * Time.deltaTime);
    }

    private void Fire()
    {
        Instantiate(Bullet, StartBullet.position, StartBullet.rotation);
    }
    #endregion
}
