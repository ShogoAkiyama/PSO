using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    public GameObject ball;
    public float moveSpeed = 3.0f;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        //  rb = this.GetComponent<Rigidbody>();
        //this.transform.position = new Vector3(0, 10, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if(this.transform.position.x >= 0.3)
                this.transform.position += this.transform.right * -0.05f;
            
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (this.transform.position.x <= 3.8)
                this.transform.position += this.transform.right * 0.05f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        { 
            if (this.transform.position.z <= 3.8)
              this.transform.position += this.transform.forward * 0.05f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (this.transform.position.z >= 0.3)
                this.transform.position += this.transform.forward * -0.05f;
        }



        if(Input.GetKeyDown("space")){
            Instantiate(ball, this.transform.position, this.transform.rotation);
        }
	}
}
