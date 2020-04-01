﻿using UnityEngine;


public class MyBullet : MonoBehaviour
{
    private Rigidbody2D _myRigidBody;

    #region Fields
    [SerializeField] private float _speed = 3;
    [SerializeField] private float _lifeTime = 4;
    [SerializeField] private int _damage = 1;
    #endregion

    #region UnityMethods
    private void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myRigidBody.AddForce(transform.right * _speed, ForceMode2D.Impulse);
        Destroy(gameObject, _lifeTime);
    }

    private void FixedUpdate()
    {
        _myRigidBody.velocity = transform.right * _speed;
        gameObject.transform.position += transform.right * _speed * Time.deltaTime;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
        }

        if (!collision.gameObject.CompareTag("Player")) Destroy(gameObject);
    }
    #endregion
}
