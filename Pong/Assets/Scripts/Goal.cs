using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameManager;
    private Paddle playerScript;
    private GameManager gameManagerScript;

    [SerializeField] private string playerName = "";

    private void Start()
    {
        playerScript = player.GetComponent<Paddle>();
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            playerScript.score += 1;
            playerScript.UpdateScore();
            gameManagerScript.SetState(GameManager.states.WinState, playerName);
        }
    }
}
