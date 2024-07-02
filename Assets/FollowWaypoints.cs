using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0; //to keep track of which waypoint we're on

    public float speed = 10.0f;
    public float rotSpeed = 10.0f; //2

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //we have to loop all this waypoints
        if (Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 10)
            currentWP++;

        if (currentWP >= waypoints.Length)
            currentWP = 0;

        //this.transform.LookAt(waypoints[currentWP].transform);

        //make character look at the location
        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
