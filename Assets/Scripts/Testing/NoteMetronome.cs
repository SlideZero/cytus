using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMetronome : MonoBehaviour
{
    enum noteRank
    {
        PERFECT, GOOD, BAD
    };
    noteRank Rank;

    public float noteNumber = 0f;                                                      //Numero de nota (beat) en la canción
    public float metronomeDuration = 0f;                                               //Duración de la animación (beats)
    public float spawnRate = 0f;
    public Animator tapIndicator;                                                      //Animator del indicador feedbak (temporal)

    bool canTap = false;
    float beatDifference = 0f;
    float beatTime = 0f;

    public float riseIndicator = 0f;
    public SetRank noteRanker;
    CircleCollider2D triggerCollider;
    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<CircleCollider2D>();
        
        beatDifference = noteNumber - metronomeDuration;                                //Beat utilizado para ejecutar animación
        beatTime = metronomeDuration * BPM._bPM.secPerBeat;                             //Tiempo de duración de la animación (segundos)
        riseIndicator = spawnRate - metronomeDuration;
        tapIndicator.speed = (1f) / beatTime;                                           //Velocidad de ejecución del animator para animación
    }

    // Update is called once per frame
    void Update()
    {
        if (BPM._bPM.startGame)
        {
            if(BPM._bPM.songPosInBeats >= (beatDifference - riseIndicator) && BPM._bPM.songPosInBeats <= beatDifference)
            {
                //tapIndicator.transform.localScale += new Vector3(1, 1) * ((2f * Time.deltaTime) / (riseIndicator * BPM._bPM.secPerBeat));
            }

            else if (BPM._bPM.songPosInBeats >= beatDifference && BPM._bPM.songPosInBeats <= noteNumber)
            {
                canTap = true;
                tapIndicator.SetTrigger("PlayTap");
                //tapIndicator.transform.localScale -= new Vector3(1, 1) * ((2f * Time.deltaTime) / beatTime);
                //triggerCollider.radius -= (radius * Time.deltaTime) / beatTime;
                /*if (tapIndicator.transform.localScale.x >= 1.2f)
                {
                    Rank = noteRank.BAD;
                }
                else if(tapIndicator.transform.localScale.x >= 0.5f)
                {
                    Rank = noteRank.GOOD;
                }
                else
                {
                    Rank = noteRank.PERFECT;
                }*/
                Rank = (noteRank)noteRanker.SetRankNote;
                if (BPM._bPM.songPosInBeats >= noteNumber)
                    Destroy(gameObject, 0.2f);
                    
            }
        }
        Debug.Log(Rank);
    }

    public void TapNote()
    {
        if (canTap)
        {
            if (Rank == noteRank.PERFECT)
            {
                GameObject ripple = ObjectPooler.SharedInstance.GetPooledObject("RippleNote");
                if (ripple != null)
                {
                    ripple.SetActive(true);
                    ripple.GetComponent<SpriteRenderer>().color = Color.yellow;
                    ripple.transform.position = transform.position;
                }
                ScoreManager.scoreManager.AddScorePoints(10);
                triggerCollider.enabled = false;
            }
            else if (Rank == noteRank.GOOD)
            {
                GameObject ripple = ObjectPooler.SharedInstance.GetPooledObject("RippleNote");
                if (ripple != null)
                {
                    ripple.SetActive(true);
                    ripple.GetComponent<SpriteRenderer>().color = Color.blue;
                    ripple.transform.position = transform.position;
                }
                ScoreManager.scoreManager.AddScorePoints(5);
                triggerCollider.enabled = false;
            }
            else if (Rank == noteRank.BAD)
            {
                ScoreManager.scoreManager.AddScorePoints(-5);
                triggerCollider.enabled = false;
            }
            ScoreManager.scoreManager.AddNote(Rank.ToString());
            Destroy(gameObject, 0.2f);
        }
        else
        {
            Rank = noteRank.BAD;
            ScoreManager.scoreManager.AddScorePoints(-5);
        }
    }
}
