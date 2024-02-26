using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 10.0f;
    private Transform _target;
    private int _waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, _target.position) <= 0.4)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(_waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(this.gameObject);
            return;
        }

        _waypointIndex++;
        _target = Waypoints.points[_waypointIndex];
    }
}
