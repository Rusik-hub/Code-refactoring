using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Transform[] _places;
    private Transform _spawner;
    private int _placesCount;
    private int _placeIndex;
    private float _speed;

    private void Start()
    {
        _places = new Transform[_spawner.childCount];

        for (int i = 0; i < _spawner.childCount; i++)
            _places[i] = _spawner.GetChild(i).GetComponent<Transform>();
    }
    
    private void Update()
    {
        var currentTarget = _places[_placeIndex];
        transform.position = Vector3.MoveTowards(transform.position,
            currentTarget.position, _speed * Time.deltaTime);

        if (transform.position == currentTarget.position)
            SetNextTarget();
    }

    private Vector3 SetNextTarget()
    {
        _placeIndex++;

        if (_placeIndex == _places.Count)
            _placeIndex = 0;

        var nextPointPosition = _places[_placeIndex].transform.position;

        transform.forward = nextPointPosition - transform.position;

        return nextPointPosition;
    }
}