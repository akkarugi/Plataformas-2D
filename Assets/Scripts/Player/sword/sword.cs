using UnityEngine;

public class sword : MonoBehaviour
{
    private BoxCollider2D colllider2D;
    public Animator animator;
    public GameObject swordParent;

    public AnimationClip attackAnimation;

    public int finalBossHealth = 3;
    public GameObject[] hearts;

    private bool canDamage = true;

    private float damageDelay = 1f;
    public AudioSource AttackSound;
    public AudioSource HitSound;
    public AudioSource finalBossMusic;
    public AudioSource finalBossDead;

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
        damageDelay -= Time.deltaTime;
    }

    public void Attack()
    {
        if (canDamage && animator != null && attackAnimation != null)
        {
            AttackSound.Play();
            animator.Play(attackAnimation.name);
            colllider2D.enabled = true;
            Invoke("DisableAttack", 0.5f);
            canDamage = false;
            Invoke("ResetDamage", 1f);
        }

    }

    private void DisableAttack()
    {
        colllider2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HitSound.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("FinalBoss") && damageDelay <= 0f)
        {
            HitSound.Play();
            damageDelay = 1f;
            finalBossHealth--;
            UpdateHearts();
            if (finalBossHealth <= 0)
            {
                finalBossDead.Play();   
                finalBossMusic.Stop();
                finalBossMusic.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < finalBossHealth);
        }
    }

    private void ResetDamage()
    {
        canDamage = true;
    }
}
