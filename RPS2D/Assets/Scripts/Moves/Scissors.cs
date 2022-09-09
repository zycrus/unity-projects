using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    [Header("Timers")]
    [SerializeField] private float timer = 0.0f;
    [SerializeField] private float cooldown = 0.1f;
    [SerializeField] private PlayerControls player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponentInParent<PlayerControls>();
        transform.localScale = new Vector3(player.direction, transform.localScale.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(player.direction, transform.localScale.y, 0);

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Meelee()
    {
        timer = cooldown;
        player.recoverTimer = cooldown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dummy")
        {
            DummyActions dummy;
            dummy = collision.GetComponent<DummyActions>();
            dummy.Hurt(cooldown, player.direction);
        }
    }
}
