using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    bool onClick = false;
    SpringJoint2D spj;
    Rigidbody2D rj;

    public Transform blotPos;
    public float maxDistance = 2f;
    public float relaeseTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        spj = GetComponent<SpringJoint2D>();
        rj = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            if(Vector3.Distance(transform.position,blotPos.position) > maxDistance)
            {
                Vector3 direction = (transform.position - blotPos.position).normalized * maxDistance;
                transform.position = blotPos.position + direction;
            }
        }
    }

    private void OnMouseDown()
    {
        onClick = true;
        rj.isKinematic = true;
    }

    private void OnMouseUp()
    {
        onClick = false;
        rj.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(relaeseTime);
        spj.enabled = false;
    }
}
