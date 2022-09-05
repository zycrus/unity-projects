using UnityEngine;

public class AttackScripts : MonoBehaviour
{
    public GameObject player;

    void AttackDone()
    {
        player.GetComponent<PlayerMovement>().isAttacking = false;
        this.gameObject.SetActive(false);
    }
}
