using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManager;
    public Text gameScore;
    public Text gameNote;
    public Text beats;

    private int _score = 0;

    private void Start()
    {
        scoreManager = this;
    }

    public void AddScorePoints(int points)
    {
        _score += points;
        gameScore.text = "Score: " + _score.ToString();
    }

    public void AddNote(string noteRank)
    {
        gameNote.text = noteRank; 
    }

    private void Update()
    {
        beats.text = "Beat: " + (int)BPM._bPM.songPosInBeats;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
