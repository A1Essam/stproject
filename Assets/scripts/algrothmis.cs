using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class algrothmis : MonoBehaviour
{
    GameObject player;
    public GameObject enmys;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(stutes.stutesmode==2)
            enmys.transform.position+= SeekBehavior(enmys.transform.position,player.transform.position,0.05f);
        if (stutes.stutesmode == 3)
            enmys.transform.position -= SeekBehavior(enmys.transform.position, player.transform.position, 0.05f);
        if (stutes.stutesmode == 1)
            enmys.transform.position += ArriveBehavior(enmys.transform.position, player.transform.position, 0.05f);
        if (stutes.stutesmode == 4)
            pursure(enmys, player);
        if (stutes.stutesmode == 5)
            Evade(enmys, player);
    }


    Vector3 SeekBehavior(Vector3 source, Vector3 target, float maxSpeed)
    {
        Vector3 velocity = (target - source).normalized * maxSpeed;
        return velocity;
    }

    Vector3 ArriveBehavior(Vector3 source, Vector3 target, float maxSpeed)
    {
        Vector3 desiredVelocity = target - source;
        float distance = Vector3.Magnitude(desiredVelocity);
        float slowingRadius = 1;

        if (distance < slowingRadius)
        {
            desiredVelocity = desiredVelocity.normalized * maxSpeed * (distance / slowingRadius);
        }
        else
        {
            desiredVelocity = desiredVelocity.normalized * maxSpeed;
        }

        return desiredVelocity;
    }

    void pursure(GameObject source, GameObject target)
    {

    float moveSpeed = 0.5f;
    float rotationSpeed = 1.0f;

    int minDistance = 5;
    int safeDistance = 60;

    int iterationAhead = 30;

            var targetSpeed = target.gameObject.GetComponent<Rigidbody>().velocity;

            Vector3 targetFuturePosition = target.transform.position + (targetSpeed* iterationAhead);

            Vector3 direction   = targetFuturePosition - transform.position;
            direction.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed* Time.deltaTime);

            if (direction.magnitude > minDistance)
            {

                Vector3 moveVector = direction.normalized* moveSpeed * Time.deltaTime;

                transform.position += moveVector;
            }

        
    }

    void Evade(GameObject source, GameObject target) {
        float moveSpeed = 3f;
        float rotationSpeed = 1.0f;

        int minDistance = 5;
        int safeDistance = 60;

        int iterationAhead = 30;

        var targetSpeed = target.gameObject.GetComponent<Rigidbody>().velocity;

        Vector3 targetFuturePosition = target.transform.position + (targetSpeed * iterationAhead);

        Vector3 direction = targetFuturePosition - transform.position;
        direction.y = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        if (direction.magnitude < safeDistance) {

            Vector3 moveVector   = direction.normalized * moveSpeed * Time.deltaTime;

            transform.position += moveVector;

        }
    }

   
}
