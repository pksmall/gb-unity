using UnityEngine;


public class MyEnemy : MonoBehaviour
{
    private MyPlayer _player;
    private Rigidbody2D _rigibody2d;
    private BoxCollider2D _boxCollider2D;
    private RaycastHit2D _hit;
    private Animator _animator;
    private bool _direction;
    private bool _allowMoveToPlayer;
    private float _visualDirection;
    private int _numberOfSteps = 200;
    private int _currentStep;

    #region Fields
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance;
    #endregion

    #region UnityMethods
    private void Start()
    {
        _currentStep = 0;
        _visualDirection = 1.0f;
        _allowMoveToPlayer = false;
        _player = FindObjectOfType<MyPlayer>();
        _sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        _rigibody2d = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponentInChildren<BoxCollider2D>();
        _animator = GetComponentInChildren<Animator>();
        _direction = transform.position.x < _player.transform.position.x;
    }

    private void FixedUpdate()
    {
        if (_direction) {
            _hit = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.right, _distance, _mask);
            Debug.DrawRay(_boxCollider2D.bounds.center, Vector2.right * _distance, Color.yellow);
        } else
        {
            _hit = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.left, _distance, _mask);
            Debug.DrawRay(_boxCollider2D.bounds.center, Vector2.left * _distance, Color.red);
        }

        if (_hit)
        {
            if (_hit.collider.gameObject.name == "Character") 
                _allowMoveToPlayer = true;
            Debug.Log(_hit.collider.gameObject.name);
        }
    }
    private void Update()
    {
        float vel = _rigibody2d.velocity.x;

        if (vel < -0.001f)
            _visualDirection = -1.0f;
        else if (vel > 0.001f)
            _visualDirection = 1.0f;

        Vector3 scale = transform.localScale;
        scale.x = _visualDirection;
        transform.localScale = scale;

        if (_allowMoveToPlayer) {
            _direction = transform.position.x < _player.transform.position.x;

            if (_direction)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        } else {
            if (_currentStep > _numberOfSteps)
            {
                if (_direction)
                    _direction = false;
                else
                    _direction = true;
                _currentStep = 0;
            }
            if (_direction)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
            _currentStep++;
        }
    }
    #endregion

    #region Methods
    private void MoveLeft()
    {
        _rigibody2d.velocity = new Vector2(-_speed, 0);
    }

    private void MoveRight()
    {
        _rigibody2d.velocity = new Vector2(_speed, 0);
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        _sprite.color = Color.red;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetBool("Death", true);
        Destroy(gameObject);
    }
    #endregion
}
