using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Tooltip("Speed of this bullet.")]
    private float _speed = 4f;


    [SerializeField, Tooltip("Normalized direciton of this bullet.")]
    private Vector3 _direction = Vector3.zero;

    float timer = 5;

    void FixedUpdate()
    {
        // move the bullet
        Vector3 newPos = transform.position;
        newPos += _direction * (_speed * Time.deltaTime);
        transform.position = newPos;

        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;


        // rotate to face the direction of movement
        transform.LookAt(transform.position + _direction);
    }
}