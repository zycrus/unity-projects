using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [Header("Actions")]
    [SerializeField] private float startingSpeed = 10f;
    [SerializeField] private float speed = 10f;

    [Header("Direction Detection")]
    [SerializeField] private PlayerControls player;

    [Header("Timers")]
    [SerializeField] private float lifeTimer = 5f;
    [SerializeField] private float cooldown = 0.2f;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<PlayerControls>();
        player = GetComponentInParent<PlayerControls>();

        player.recoverTimer = cooldown;

        body = GetComponent<Rigidbody2D>();
        speed *= player.direction;
        startingSpeed *= player.direction;
        body.velocity = (new Vector2(startingSpeed, body.velocity.y));
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        //body.velocity = new Vector2(speed, body.velocity.y);
        body.AddRelativeForce(new Vector2(speed, body.velocity.y));

        if (lifeTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Paper")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "Dummy")
        {
            DummyActions dummyAction;
            dummyAction = collision.GetComponent<DummyActions>();
            dummyAction.Hurt(0.1f, player.direction);
            Destroy(this.gameObject);
        }
    }
}
