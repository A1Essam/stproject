using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    public GameObject player;
    public GameObject prefab;
    float speed = 0.15f;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generateenmy", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += transform.forward *speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += transform.right * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position -= transform.right * speed;
        }


        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        player.transform.position += new Vector3(-direction.z * Time.deltaTime*2f,0, direction.x*Time.deltaTime * 2f);
        Debug.Log(direction);
    }

    

    void generateenmy()
    {
        GameObject enmy =  Instantiate(prefab);
        enmy.transform.position = new Vector3(1.49f, 0.502f, 40.12f);
    }

}
