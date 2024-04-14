using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMov : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
    }
}
