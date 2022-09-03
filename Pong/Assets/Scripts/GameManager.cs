using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject scoreUI;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject winTextUI;
    [SerializeField] private GameObject tutorialUI;
    private TextMeshProUGUI winText;

    [Header("World")]
    [SerializeField] private GameObject worldObjects;
    [SerializeField] private GameObject ballObject;
     private Ball ballScript;
    [SerializeField] private GameObject leftPlayer;
    private Paddle leftPlayerScript;
    [SerializeField] private GameObject rightPlayer;
    private Paddle rightPlayerScript;

    public enum states
    {
        TutorialState,
        MainGameState,
        WinState
    }
    private states currenState = states.MainGameState;

    private void Start()
    {
        winText = winTextUI.GetComponent<TextMeshProUGUI>();
        ballScript = ballObject.GetComponent<Ball>();
        leftPlayerScript = leftPlayer.GetComponent<Paddle>();
        rightPlayerScript = rightPlayer.GetComponent<Paddle>();
        SetState(states.TutorialState);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currenState != states.MainGameState)
                SetState(states.MainGameState);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void SetState(states state, string winner = "")
    {
        currenState = state;
        if (currenState == states.TutorialState)
        {
            worldObjects.SetActive(true);
            scoreUI.SetActive(false);
            winUI.SetActive(false);
            tutorialUI.SetActive(true);
        }
        if (currenState == states.MainGameState)
        {
            worldObjects.SetActive(true);
            scoreUI.SetActive(true);
            winUI.SetActive(false);
            tutorialUI.SetActive(false);
            ballScript.Launch();
            leftPlayerScript.RestPos();
            rightPlayerScript.RestPos();
        }
        if (currenState == states.WinState)
        {
            winText.text = winner + " Wins!";
            worldObjects.SetActive(false);
            scoreUI.SetActive(false);
            winUI.SetActive(true);
            tutorialUI.SetActive(false);
        }
    }
}
