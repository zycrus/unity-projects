using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyActions : MonoBehaviour
{
    [Header("Hurt")]
    [SerializeField] private float recoverTimer = 0.0f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (recoverTimer > 0.0f)
        {
            recoverTimer -= Time.deltaTime;
            spriteRenderer.color = Color.red;
        }
        else
        {
            recoverTimer = 0;
            spriteRenderer.color = Color.white;
        }
    }

    public void Hurt(float timer, float direction)
    {
        body.AddRelativeForce(new Vector2(50f * direction, 100f));
        recoverTimer = timer;
    }
}
