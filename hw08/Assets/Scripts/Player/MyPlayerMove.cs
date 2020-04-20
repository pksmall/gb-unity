using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class MyPlayerMove : MonoBehaviour
{
    #region Fields
    public MyPlayer _controller;
	public Animator _animator;
	public float _runSpeed = 15f;
	private float _horizontalMove = 0f;
	private bool _jump = false;
	private bool _crouch = false;
    #endregion

    #region UnityMethods
    void Update()
	{
#if UNITY_ANDROID && !UNITY_EDITOR
		_horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal") * _runSpeed;
#else
		_horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
#endif
 
		_animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			_jump = true;
			_animator.SetBool("IsJumping", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			_crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			_crouch = false;
		}

	}

	void FixedUpdate()
	{
		_controller.Move(_horizontalMove * Time.fixedDeltaTime, _crouch, _jump);		
	}
#endregion

#region Methods
	public void Jump()
	{
		_jump = true;
		_animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		_jump = false;
		_animator.SetBool("IsJumping", false);
	}

	public void OnCrouching(bool isCrouching)
	{
		_animator.SetBool("IsCrouching", isCrouching);
	}
#endregion
}
