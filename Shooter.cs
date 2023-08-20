using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform _objectToShoot;

    private Rigidbody _rigidbody;
    private Coroutine _runningCoroutine;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        bool isWork = true;
        _runningCoroutine = new WaitForSeconds(_timeWaitShooting);

        while (isWork)
        {
            var vectorDirection = (ObjectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + vectorDirection, Quaternion.identity);
            _rigidbody = newBullet.GetComponent<Rigidbody>();

            _rigidbody.transform.up = vectorDirection;
            _rigidbody.velocity = vectorDirection * _speed;

            yield return _runningCoroutine;
        }
    }
}