using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject gameOverPanel;
    public int health = 3;
    public Sprite[] damageSprites; 

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        health--;

  
        if (health >= 0 && health < damageSprites.Length)
        {
            sr.sprite = damageSprites[damageSprites.Length - health - 1];
        }


        if (health <= 0)
        {
           
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }

            gameObject.SetActive(false);

            Destroy(gameObject);
        }
        else
        {
            Respawn();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();               
            Destroy(other.gameObject);  
        }
    }

    void Respawn()
    {
        transform.position = new Vector3(0f, -4f, 0f);
        gameObject.SetActive(true);
    }

}
