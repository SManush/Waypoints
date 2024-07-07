using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0; //to keep track of which waypoint we're on

    public float speed = 10.0f;
    public float rotSpeed = 10.0f; //2
    public float lookAhead = 10.0f; //not to get any closer

    GameObject tracker; //created a tracker that a tank will follow

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder); //create tracker
        DestroyImmediate(tracker.GetComponent<Collider>()); 
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    void ProgressTracker()
    {
        if (Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhead) return; //not to get any closer

        //we have to loop all this waypoints
        if (Vector3.Distance(tracker.transform.position, waypoints[currentWP].transform.position) < 10)
            currentWP++;

        if (currentWP >= waypoints.Length)
            currentWP = 0;

        tracker.transform.LookAt(waypoints[currentWP].transform);
        tracker.transform.Translate(0, 0, (speed + 20) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();

        //this.transform.LookAt(waypoints[currentWP].transform);

        //make character look at the location

        Quaternion lookatWP = Quaternion.LookRotation(tracker.transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
