using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door2 : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float movementSpeed = 0.5f;

    bool isOpen = false;

    void Update()
    {
        if (isOpen)
        {
            MoveDoor(target.position);
        }
    }

    public void OpenDoor()
    {
        if (!isOpen) 
        {
            isOpen = true;
            Debug.Log("Abriendo puerta");
        }
    }

    void MoveDoor(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }
}
