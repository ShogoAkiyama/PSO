using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSOMgrScript : MonoBehaviour {
    public Object PSOprehab;
    const int MaxCnt = 500;
    int FrameCnt;
    Object pso;


	// Use this for initialization
	void Start () {
        FrameCnt = 0;
        pso = Instantiate(PSOprehab);
	}
	
	// Update is called once per frame
	void Update () {
        if(FrameCnt++ > MaxCnt){
            Destroy(pso);
            pso = Instantiate(PSOprehab);
            FrameCnt = 0;
            Debug.Log("New Object");
        }
	}
}
