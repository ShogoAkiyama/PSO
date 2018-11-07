using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphScript : MonoBehaviour {

    public Transform pointPrefab;
    [Range(10, 150)] public int resolution = 150;

    Transform[] points;


    public Transform axis;
    Transform[] axises = new Transform[3];

    //public Transform sphere;
    //Transform localSphere;

    void Awake(){

        // 座標軸をプロット
        Transform point;
        Vector3 position;
        Vector3 scale;


        //// ボールをプロット
        //position.x = position.z = 2f;
        //position.y = 2f;
        //scale.x = scale.y = scale.z = 1;

        //localSphere = Instantiate(sphere);
        //localSphere.localPosition = position;
        //localSphere.SetParent(transform, true);
        //localSphere.localScale = scale;


        //// X座標
        //position.x = position.z = 2f;
        //position.y = -2.0f;
        //scale.y = 0.1f;
        //scale.x = scale.z = 4;

        //point = Instantiate(axis);
        //point.localPosition = position;
        //point.localScale = scale;
        //point.SetParent(transform, true);
        //axises[0] = point;


        // Y座標
        position.y = position.z = 0f;
        position.x = 2f;
        scale.z = 0.1f;
        scale.x = scale.y = 4;

        point = Instantiate(axis);
        point.localPosition = position;
        point.localScale = scale;
        point.SetParent(transform, true);
        axises[1] = point;


        //// Z座標
        position.x = position.y = 0f;
        position.z = 2;
        scale.x = 0.1f;
        scale.y = scale.z = 4;

        point = Instantiate(axis);
        point.localPosition = position;
        point.localScale = scale;
        point.SetParent(transform, true);
        axises[2] = point;


        // 関数をプロット
        points = new Transform[resolution];

        float step = 4f / resolution;
        scale = Vector3.one * step;   // 大きさの単位を決定

        position.x = position.y = position.z = 0f;

        for (int z = 0; z < resolution; z++)
        {
            position.z = z * step;

            for (int i = 0, x = 0; x < resolution; i++, x++)
            {
                point = Instantiate(pointPrefab);
                position.x = x * step;

                position.y = function(position.x, position.z);

                point.localPosition = position;
                point.localScale = scale;
                point.SetParent(transform, true);
                points[i] = point;
            }
        }


    }

    float function(float x, float z){

        // Michalewicz
        float m = 10f;
        float y = -Mathf.Sin(x) * Mathf.Pow(Mathf.Sin(x * x / Mathf.PI), 2 * m) - Mathf.Sin(z) * Mathf.Pow(Mathf.Sin(2 * z * z / Mathf.PI), 2 * m);

        return y;
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //Vector3 position;
        //position.x = position.y = position.z = 0f;

        //for (int i = 0; i < resolution; i++)
        //{
            
        //    Transform point = points[i];
        //    position = point.localPosition;
        //    position.y = position.y * Mathf.Sin(Time.time);
        //    point.localPosition = position;
        //    points[i] = point;
        //    //point.GetComponent<Rigidbody>().MovePosition(position);

        //}

	}
}
