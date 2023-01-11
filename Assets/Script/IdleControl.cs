using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IdleControl : MonoBehaviour
{
    Animator _idleAni;
    Rigidbody _rigidBody;
    GameObject _fire;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _rigidBody = GetComponent<Rigidbody>();
        _idleAni = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "RedFlower" || collision.gameObject.tag == "Iron" || collision.gameObject.tag == "Rock")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                GameManager.AddCell1(-10);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "RedFlower")
            {
                GameManager.AddCell1(1);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Iron")
            {
                GameManager.AddCell2(1);
                GameManager.AddCell3(1);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Rock")
            {
                GameManager.AddCell6(1);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Portal" || collision.gameObject.tag == "Finish")
        {
            if (collision.gameObject.tag == "Portal")
            {
                transform.position = new Vector3(0, 0, 500);
            }
            if (collision.gameObject.tag == "Finish")
            {
                EditorApplication.isPlaying = false;
            }
        }
    }

    [Header("²¾°Ê")]
    [SerializeField] float _moveSpeed = 10;

    void Walk()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var lookPoint = new Vector3(horizontal, 0, vertical);
        transform.position += lookPoint * _moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + lookPoint);

        if (horizontal != 0 || vertical != 0)
        {
            _idleAni.SetBool("Walk", true);
        }
        else
        {
            _idleAni.SetBool("Walk", false);
        }
    }

    [SerializeField] float _jumpSpeed = 10;
    void Jump()
    {
        _rigidBody.velocity += new Vector3(0, _jumpSpeed, 0);
        _idleAni.SetTrigger("Jump");
        GameManager.AddCell1(-3);
    }

    [Header("¤l¼u")]
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _idleMuzzle;
    [SerializeField] Rigidbody _bulletSpeed;
    void OpenFire(int bulletAmount)
    {
        for (int n = 0; n < bulletAmount; n++)
        {
            Vector3 dirction = new Vector3(Random.Range(-10, 10), Random.Range(1, -1),30);
            Vector3 position = _idleMuzzle.transform.position;
            Rigidbody rigidbody = Instantiate(_bulletSpeed, position, transform.rotation);
            rigidbody.transform.tag = gameObject.tag;
            rigidbody.velocity = transform.TransformDirection(dirction);
        }
        if(bulletAmount > 0)
        {
            if(bulletAmount == 1)
            {
                GameManager.AddCell2(-1);
            }
            else
            {
                GameManager.AddCell3(-5);
            }
        }
    }
}
