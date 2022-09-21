using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Dummy")
        {
            Animator enemyAnim = collision.transform.GetComponent<Animator>();
            Rigidbody2D enemyBody = collision.transform.GetComponent<Rigidbody2D>();
            enemyAnim.SetTrigger("Damage");
            enemyBody.AddForce(transform.right * 2, ForceMode2D.Impulse);
            enemyBody.AddForce(enemyBody.transform.up * 5, ForceMode2D.Impulse);
        }
    }
}
