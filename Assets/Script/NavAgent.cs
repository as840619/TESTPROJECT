using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    [SerializeField] Transform _idle;
    [SerializeField] float _time;
    void Start()
    {
        _time = 1;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, _idle.position) < 10 && Vector3.Distance(transform.position, _idle.position) < 3)
        {
            _time -= Time.deltaTime;
            if (_time <= 0)
            {
                OpenFire();
                _time = 1;
            }
            _navMeshAgent.isStopped = true;
        }
        if (Vector3.Distance(transform.position, _idle.position) > 10 && Vector3.Distance(transform.position, _idle.position) < 30)
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_idle.position);
        }
        else if (Vector3.Distance(transform.position, _idle.position) > 30)
        {
            _navMeshAgent.isStopped = true;
        }
    }

    [Header("¤l¼u")]
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _idleMuzzle;
    [SerializeField] float _bulletSpeed;
    void OpenFire()
    {
        transform.LookAt(_idle.position);
        Vector3 dirction = transform.TransformDirection(Vector3.forward * _bulletSpeed);
        Vector3 position = _idleMuzzle.transform.position;
        Rigidbody rigidbody = Instantiate(_bullet, position, transform.rotation).GetComponent<Rigidbody>();
        rigidbody.transform.tag = gameObject.tag;
        rigidbody.velocity = dirction;
    }
}

