using UnityEngine;
using UnityEngine.UI;

public class SongTimeLine : MonoBehaviour
{
    [SerializeField] private Slider songTimeLine;

    private float songLenght = 0f;

    private void Start()
    {
        songLenght = BPM._bPM.song.clip.length;
        songTimeLine.maxValue = songLenght;
    }

    private void Update()
    {
        songTimeLine.value = BPM._bPM.songPosition;
    }
}
