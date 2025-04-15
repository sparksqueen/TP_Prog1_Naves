using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{

    public float speed = 5f;
    public GameObject bulletPrefab;
    private float halfWidth;
    private float halfHeight;

    void Start()
    {
        halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        halfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.instance.isGameStarted)
            return;

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.position += speed * Time.deltaTime * movement;


        ClampPosition();

        if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 spawnPosition = transform.position + Vector3.up * 0.5f;
                Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
            }

    }

    void ClampPosition() {
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));

        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, bottomLeft.x + halfWidth, topRight.x - halfWidth);
        currentPos.y = Mathf.Clamp(currentPos.y, bottomLeft.y + halfHeight, topRight.y - halfHeight);

        transform.position = currentPos;


    }
}
