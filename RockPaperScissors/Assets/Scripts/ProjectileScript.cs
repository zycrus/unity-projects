using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timer;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameObject parent;
    private Rigidbody body;
    private bool isActive;
    private int direction;
    float hSpeed;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Spawn()
    {
        transform.position = new Vector3(0, 0, 0);
        isActive = parent.activeSelf;
        direction = player.direction;
        hSpeed = speed * direction;
        body.velocity = new Vector3(hSpeed, body.velocity.y, 0);
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            isActive = false;
            parent.SetActive(false);
            timer = 10;
        }
    }
}
