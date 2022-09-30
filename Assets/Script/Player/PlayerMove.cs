using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D _rb;
    Transform _transform;

    [Header("走行速度"),SerializeField] float _speed;
    [Header("ジャンプ力"),SerializeField] float _jumpPower;
    [Header("ジャンプした時にかける重力"), SerializeField] float _gravity;
    GroundJudg groundJudg;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        groundJudg = GetComponent<GroundJudg>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && groundJudg.IsGroung)
        {
           _rb.AddForce(Vector2.up * _jumpPower,ForceMode2D.Impulse);
        }
        if(!groundJudg.IsGroung)
        {
            _rb.AddForce(Vector2.down * _gravity);
        }
        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 velocity = _rb.velocity;
        velocity.x = x * _speed;
        _rb.velocity = velocity;

        if (x != 0)
        {
            _transform.localScale = new Vector3(x, 1, 1);
        }
    }
}
