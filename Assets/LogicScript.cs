using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    private void Awake()
    {
        if (gameOverScreen == null)
        {
            gameOverScreen = FindInactiveObject("GameOverScreen");
        }

        if (gameOverScreen == null)
        {
            gameOverScreen = CreateGameOverScreen();
        }

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }

        if (scoreText != null)
        {
            scoreText.text = playerScore.ToString();
        }
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        if (scoreText != null)
        {
            scoreText.text = playerScore.ToString();
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver() {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    private GameObject FindInactiveObject(string objectName)
    {
        foreach (GameObject sceneObject in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (sceneObject.name == objectName && sceneObject.scene.IsValid())
            {
                return sceneObject;
            }
        }

        return null;
    }

    private GameObject CreateGameOverScreen()
    {
        Canvas canvas = FindFirstObjectByType<Canvas>();
        if (canvas == null)
        {
            return null;
        }

        GameObject panel = new GameObject("GameOverScreen");
        panel.transform.SetParent(canvas.transform, false);

        RectTransform panelTransform = panel.AddComponent<RectTransform>();
        panelTransform.anchorMin = new Vector2(0.5f, 0.5f);
        panelTransform.anchorMax = new Vector2(0.5f, 0.5f);
        panelTransform.sizeDelta = new Vector2(500, 300);

        Image background = panel.AddComponent<Image>();
        background.color = new Color(0, 0, 0, 0.8f);

        GameObject messageObject = new GameObject("GameOverText");
        messageObject.transform.SetParent(panel.transform, false);
        Text message = messageObject.AddComponent<Text>();
        message.text = "Game Over";
        message.alignment = TextAnchor.MiddleCenter;
        message.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        message.fontSize = 42;
        message.color = Color.white;
        RectTransform messageTransform = messageObject.GetComponent<RectTransform>();
        messageTransform.anchorMin = new Vector2(0, 0.5f);
        messageTransform.anchorMax = new Vector2(1, 1);
        messageTransform.offsetMin = new Vector2(10, 0);
        messageTransform.offsetMax = new Vector2(-10, -20);

        GameObject buttonObject = new GameObject("RestartButton");
        buttonObject.transform.SetParent(panel.transform, false);
        Image buttonImage = buttonObject.AddComponent<Image>();
        buttonImage.color = Color.white;
        Button button = buttonObject.AddComponent<Button>();
        button.onClick.AddListener(restartGame);
        RectTransform buttonTransform = buttonObject.GetComponent<RectTransform>();
        buttonTransform.anchorMin = new Vector2(0.25f, 0.1f);
        buttonTransform.anchorMax = new Vector2(0.75f, 0.4f);
        buttonTransform.offsetMin = Vector2.zero;
        buttonTransform.offsetMax = Vector2.zero;

        GameObject buttonTextObject = new GameObject("RestartText");
        buttonTextObject.transform.SetParent(buttonObject.transform, false);
        Text buttonText = buttonTextObject.AddComponent<Text>();
        buttonText.text = "Restart";
        buttonText.alignment = TextAnchor.MiddleCenter;
        buttonText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        buttonText.fontSize = 28;
        buttonText.color = Color.black;
        RectTransform buttonTextTransform = buttonTextObject.GetComponent<RectTransform>();
        buttonTextTransform.anchorMin = Vector2.zero;
        buttonTextTransform.anchorMax = Vector2.one;
        buttonTextTransform.offsetMin = Vector2.zero;
        buttonTextTransform.offsetMax = Vector2.zero;

        return panel;
    }
}
