using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_platform : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] Transform target;
    public float movement_speed = 0.5f;
    bool is_up = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (!is_up)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.position, movement_speed * Time.deltaTime);
            if(Vector3.Distance(transform.position,target.position)<= 0.01f)
                is_up = true; 
        }

        else if (is_up)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, origin.position, movement_speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, origin.position) <= 0.01f)
                is_up = false;
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
