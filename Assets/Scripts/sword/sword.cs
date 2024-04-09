using UnityEngine;

public class sword : MonoBehaviour
{
    private BoxCollider2D colllider2D;
    public Animator animator;
    public GameObject swordParent;

    public AnimationClip attackAnimation;

    void Start()
    {
        colllider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (animator != null && attackAnimation != null)
        {
            animator.Play(attackAnimation.name);
            colllider2D.enabled = true;
            Invoke("DisableAttack", 0.5f);
        }
        else
        {
            Debug.LogError("Animator or attackAnimation is not assigned in the sword script!");
        }
    }

    private void DisableAttack()
    {
        colllider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.transform.root.gameObject);
        }
    }
}
