using UnityEngine;
using UnityEngine.Events;


public class MyPlayer : MonoBehaviour
{
    #region Fields
    [SerializeField] private float _jumpForce = 400f;
    [Range(0, 1)] [SerializeField] private float _crouchSpeed = .36f;
    [Range(0, .3f)] [SerializeField] private float _movementSmoothing = .05f;
    [SerializeField] private bool _airControl = false;
    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private Transform CeilingCheck;
    [SerializeField] private Collider2D CrouchDisableCollider;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Mine;
    [SerializeField] private Transform StartBullet;
    [SerializeField] private Transform StartMine;

    public bool FacingRight = true;

    private CircleCollider2D _circleCollider2d;
    private Rigidbody2D _rigidbody2D;
    private const float _groundedRadius = .148f;
    private bool _grounded;
    private const float _ceilingRadius = .2f;
    private Vector3 _velocity = Vector3.zero;

    [Header("Events")]
    [Space]
    public UnityEvent OnLandEvent;
    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    public BoolEvent OnCrouchEvent;
    private bool _wasCrouching = false;
    #endregion

    #region UnityMethods
    private void Awake()
    {
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _circleCollider2d = GetComponentInChildren<CircleCollider2D>();

#if UNITY_ANDROID
        Handheld.Vibrate();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
#endif
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2")) DropMine();

        if (Input.GetButtonDown("Fire1")) Fire();
    }
    private void FixedUpdate()
    {
        bool wasGrounded = IsGrounded();
        _grounded = false;

        if (wasGrounded) {
            _grounded = true;
            OnLandEvent.Invoke();
        }
        /*        bool wasGrounded = _grounded;
                _grounded = false;

                Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, _groundedRadius, WhatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        Debug.Log(colliders[i].gameObject);
                        _grounded = true;
                        if (!wasGrounded)
                            OnLandEvent.Invoke();
                    }
                }
        */
    }
    #endregion

    #region Methods
    private bool IsGrounded()
    {
        //return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;

        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(_circleCollider2d.bounds.center, Vector2.down, extraHeightText, WhatIsGround);

        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(_circleCollider2d.bounds.center + new Vector3(_circleCollider2d.bounds.extents.x, 0), Vector2.down * (_circleCollider2d.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_circleCollider2d.bounds.center - new Vector3(_circleCollider2d.bounds.extents.x, 0), Vector2.down * (_circleCollider2d.bounds.extents.y + extraHeightText), rayColor);
        Debug.DrawRay(_circleCollider2d.bounds.center - new Vector3(_circleCollider2d.bounds.extents.x, _circleCollider2d.bounds.extents.y + extraHeightText), Vector2.right * (_circleCollider2d.bounds.extents.x * 2f), rayColor);
        // Debug.Log(raycastHit.collider);

        if (raycastHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(CeilingCheck.position, _ceilingRadius, WhatIsGround))
            {
                crouch = true;
            }
        }

        if (_grounded || _airControl)
        {
            if (crouch)
            {
                if (!_wasCrouching)
                {
                    _wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }
                move *= _crouchSpeed;
                if (CrouchDisableCollider != null)
                    CrouchDisableCollider.enabled = false;
            }
            else
            {
                if (CrouchDisableCollider != null)
                    CrouchDisableCollider.enabled = true;

                if (_wasCrouching)
                {
                    _wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody2D.velocity.y);
            _rigidbody2D.velocity = Vector3.SmoothDamp(_rigidbody2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);

            if (move > 0 && !FacingRight)
            {
                Flip();
            }
            else if (move < 0 && FacingRight)
            {
                Flip();
            }
        }
        if (_grounded && jump)
        {
            _grounded = false;
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Force);
        }
    }


    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        transform.localScale = flipped;

        transform.Rotate(0f, 180f, 0f);
    }

    public void Fire()
    {
        MyHitSound hitSound = GetComponentInChildren<MyHitSound>();
        Instantiate(Bullet, StartBullet.position, StartBullet.rotation);
        hitSound.Play(1);
    }
    public void DropMine()
    {
        MyHitSound hitSound = GetComponentInChildren<MyHitSound>();
        Instantiate(Mine, StartMine.position, StartMine.rotation);
        hitSound.Play(0);
    }
    #endregion
}
