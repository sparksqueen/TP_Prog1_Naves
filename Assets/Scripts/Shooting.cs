using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float speed = 5f;
    void Update()
    {

        if (!GameManager.instance.isGameStarted)
            return;
      
        Vector3 movement = Vector3.up;
        transform.position += speed * Time.deltaTime * movement;

        if (IsOffScreen())
    {
        Destroy(gameObject);
    }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddPoint();
            }

            Destroy(other.gameObject);
            Destroy(gameObject);       
        }
    }

    bool IsOffScreen()
{
    Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
    return transform.position.y > topRight.y + 1f;
}


}
