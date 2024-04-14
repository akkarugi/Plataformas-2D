using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    public float movementSpeed = 1f;
    bool movingToB = true; 

    void Update()
    {
       
        Vector3 targetPosition = movingToB ? pointB.position : pointA.position;

       
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

     
        if (Vector3.Distance(transform.position, targetPosition) <= 0.01f)
        {
           
            movingToB = !movingToB;
           
            Flip();
        }
    }

    void Flip()
    {
        
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
