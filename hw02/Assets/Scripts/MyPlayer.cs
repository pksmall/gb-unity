using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _heightJump;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform StartBullet;

    void Start()
    {
        
    }

    void Update()
    {
        var inputSpeed = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        var heightJump = Input.GetAxis("Jump") * _heightJump * Time.deltaTime;
        var velocity = transform.right * inputSpeed;

        transform.position += velocity;

        if (heightJump > 0)
        {
            velocity = transform.up * heightJump;
        }
        transform.position += velocity;

        if (Input.GetButtonDown("Fire1")) Fire();
    }

    private void Fire()
    {
        Instantiate(Bullet, StartBullet.position, StartBullet.rotation);
    }
}
