using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [Header("Direction Detection")]
    [SerializeField] private PlayerControls player;
    [SerializeField] private float xSize = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(xSize * player.direction, transform.localScale.y, 1);
    }
}
