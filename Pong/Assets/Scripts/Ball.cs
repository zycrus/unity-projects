using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    Transform ballTransform;
    Rigidbody2D body;

    private void Start()
    {
        ballTransform = GetComponent<Transform>();
        body = GetComponent<Rigidbody2D>();
    }

    public void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        body.velocity = new Vector2(speed * x, speed * y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed *= 1.01f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            ballTransform.position = new Vector3(0, 0, 0);
        }
    }
}
