using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PSOScript : MonoBehaviour
{
    [Range(3, 40)]
    public int ParticleNum = 3;
    Particle[] nest;
    public Transform pointPrefab;

    public Transform bestPrefab;
    Transform[] points;
    Transform bestpoint;

    [Range(10, 120)]
    public int frame = 10;
    int countframe;

    // Use this for initialization
    void Awake()
    {
        Particle.frame = frame;
        nest = new Particle[ParticleNum];
        points = new Transform[ParticleNum];
        for (int i = 0; i < ParticleNum; ++i)
        {
            nest[i] = new Particle();
            nest[i].Start();
            Vector3 position = nest[i].position;
            Transform point = Instantiate(pointPrefab);
            point.localPosition = position;
            point.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            point.SetParent(transform, false);
            points[i] = point;
        }
        bestpoint = Instantiate(bestPrefab);
        bestpoint.localScale = Particle.gbest;
        bestpoint.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        bestpoint.SetParent(transform, false);
    }

    void Start()
    {
        countframe = 0;
        Particle.gbest = new Vector3(0, 1e9f, 0);
        Particle.gbestnum = 1e9f;

    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ParticleNum; ++i)
        {
            if (countframe > frame)
                nest[i].Update();
            else
                nest[i].Move();
            Transform point = points[i];
            point.position = nest[i].position;

        }
        if (countframe++ > frame)
            countframe = 0;
        bestpoint.position = Particle.gbest;

    }


}


public class Particle
{
    static float W = 0.7f;
    static float C = 1.4f;

    static float Ub = 4.0f;
    static float Lb = 0.0f;


    public static int frame = 10;

    public static Vector3 gbest;
    public static float gbestnum = 1E9f;

    public Vector3 position;
    public Vector3 velocity;
    //    float fitness;

    Vector3 pbest;
    float pbestnum;

    public Particle() { }

    public void Start()
    {
        /* init */
        this.position = new Vector3(Random.Range(Lb, Ub), Random.Range(Lb, Ub), Random.Range(Lb, Ub));
        this.velocity = new Vector3(Random.Range(Lb, Ub), Random.Range(Lb, Ub), Random.Range(Lb, Ub));
        this.velocity = 0.1f * this.velocity;
        this.culcate();

        this.pbestnum = this.position.y;
        this.pbest = this.position;
        if (gbestnum > this.position.y)
        {
            gbest = this.position;
            gbestnum = this.position.y;
        }
    }

    public void Update()
    {
        this.velocity = W * this.velocity
                        + C * (this.pbest - this.position)
                        + C * (gbest - this.position);
        //this.position = this.position + step * this.velocity;
        this.flat();
        this.culcate();

        if (this.pbestnum > this.position.y)
        {
            this.pbest = this.position;
            this.pbestnum = this.position.y;
        }
        if (gbestnum > this.position.y)
        {
            gbest = this.position;
            gbestnum = this.position.y;
        }

    }
    public void Move()
    {
        this.position = this.position + this.velocity / frame;
        this.flat();
        this.culcate();
    }

    void culcate()
    {
        float m = 10f;
        float x = position.x, z = position.z;
        this.position.y = -Mathf.Sin(x) * Mathf.Pow(Mathf.Sin(x * x / Mathf.PI), 2 * m) - Mathf.Sin(z) * Mathf.Pow(Mathf.Sin(2 * z * z / Mathf.PI), 2 * m);
    }

    void flat()
    {
        this.position = Vector3.Max(this.position, Vector3.one * Lb);
        this.position = Vector3.Min(this.position, Vector3.one * Ub);
    }
}

