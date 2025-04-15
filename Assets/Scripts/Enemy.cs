using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private PlayerHealth playerHealth;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (IsOffScreen())
        {
            if (playerHealth != null)
                playerHealth.TakeDamage();

            Destroy(gameObject);
        }
    }

    bool IsOffScreen()
    {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        return transform.position.y < bottomLeft.y - 1f;
    }
}
