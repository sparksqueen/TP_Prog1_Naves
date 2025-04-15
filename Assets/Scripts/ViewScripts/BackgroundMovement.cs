using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Vector3 startPosition;
    private float spriteHeight;

    void Start()
    {
        startPosition = transform.position;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        float newY = Mathf.Repeat(Time.time * scrollSpeed, spriteHeight);
        transform.position = startPosition + Vector3.down * newY;
    }
}

