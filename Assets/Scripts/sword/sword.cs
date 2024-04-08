using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;
    private BoxCollider2D colllider2D;
    public Animation animator;
    public GameObject swordParent;

    void Start()
    {
        swordParent.SetActive(false);
        playerSpriteRenderer= transform.root.GetComponent<SpriteRenderer>();
        colllider2D= GetComponent<BoxCollider2D>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0)){
            attack();
        }

        if (playerSpriteRenderer.flipX == true)
        {
            swordParent.transform.rotation = Quaternion.Euler(0,0,0);
        }

    }

    public void attack()
    {
        swordParent.SetActive(true);
        animator.Play("Attack");
        colllider2D.enabled = true;
        Invoke("Disableattack", 0.5f);
        swordParent.SetActive(false);
    }

    private void Disableattack()
    {
        colllider2D.enabled=false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
         
        }
    }
}
