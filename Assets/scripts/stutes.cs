using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stutes : MonoBehaviour
{

    public static int stutesmode ;
    
    void Start()
    {
        stutesmode = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changemode(int m)
    {
        stutesmode = m;
    }

    


}
