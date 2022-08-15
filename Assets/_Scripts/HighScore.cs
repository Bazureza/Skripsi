using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text HighScoreText;

    void Start () {
        HighScoreText.text = PlayerPrefs.GetInt("Score").ToString();
	}
}
