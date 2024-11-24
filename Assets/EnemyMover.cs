using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //PrintWaypointName();

        StartCoroutine(FollowPath());//we want the enemy to transition from one tile to another tile, and it should be visible to the user
        //should not be an abrupt transition each time the enemy moves
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    void PrintWaypointName(){
        foreach(Waypoint waypoint in path){
            Debug.Log(waypoint.name);
        }
    }*/

    IEnumerator FollowPath(){//can iterate and count on with enumerator; returning something that is countable
        foreach(Waypoint waypoint in path){//waypoint script is tied to the tile
            Vector3 startPosition = transform.position;//enemy game object
            Vector3 endPosition = waypoint.transform.position;//tile
            float travelPercentage = 0;

            //transform.LookAt(endPosition);

            while(travelPercentage < 1f){
                travelPercentage = travelPercentage + Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercentage);
                yield return new WaitForEndOfFrame();
            }
            

            //transform.position = waypoint.transform.position; why were we able to replace this transform.position
            
        }//transform refers to the game object that this script is tied to; tied to the enemy game object here
    }
}
