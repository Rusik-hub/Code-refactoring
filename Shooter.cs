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

    private Coroutine _waitShootingCoroutine;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        bool isWork = true;
        _waitShootingCoroutine = new WaitForSeconds(_timeWaitShooting);

        while (gameObject.enabled)
        {
            var vectorDirection = (ObjectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + vectorDirection, Quaternion.identity);

            newBullet.transform.up = vectorDirection;
            newBullet.velocity = vectorDirection * _speed;

            yield return _waitShootingCoroutine;
        }
    }
}