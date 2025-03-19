using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    public float speed;
    //public int shot;//���еļ���
    public float targetDistance;//���ӵľ���

    private Rigidbody2D rg2d;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        rg2d.velocity = transform.up * speed;
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (transform.position - startPos).sqrMagnitude;
        if(distance> targetDistance)
        {
            Destroy(gameObject);
        }
    }
}
