using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0; //to keep track of which waypoint we're on

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //we have to loop all this waypoints
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
            currentWP++;

        if (currentWP >= waypoints.Length)
            currentWP = 0;

        this.transform.LookAt(waypoints[currentWP].transform);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
