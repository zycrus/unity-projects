using TMPro;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] string axisName;
    Rigidbody2D body;
    Transform paddleTransform;

    [SerializeField] private Transform targetPos;

    [Header("Score UI")]
    [SerializeField] private GameObject playerScoreUI;
    private TextMeshProUGUI scoreText;
    public int score = 0;
    [SerializeField] private float time = 0;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        paddleTransform = GetComponent<Transform>();
        scoreText = playerScoreUI.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void Update()
    {
        body.velocity = new Vector2(0, speed * Input.GetAxisRaw(axisName));


        targetPos.position = new Vector3(targetPos.position.x, paddleTransform.transform.position.y + Input.GetAxis(axisName) / 2, targetPos.position.z);
        Vector3 targ = new Vector3(targetPos.position.x, targetPos.position.y - paddleTransform.transform.position.y, targetPos.position.z); ;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;

        paddleTransform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void RestPos()
    {
        paddleTransform.position = new Vector3(paddleTransform.position.x, 0, paddleTransform.position.z);
    }
}
