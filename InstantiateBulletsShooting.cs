using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeWaitShooting;

    public Transform ObjectToShoot;

    private void Start()
    {
        StartCoroutine(_shootingWorker());
    }

    private IEnumerator _shootingWorker()
    {
        bool isWork = true;

        while (isWork)
        {
            var vector3direction = (ObjectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + vector3direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = vector3direction;
            newBullet.GetComponent<Rigidbody>().velocity = vector3direction * _speed;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}