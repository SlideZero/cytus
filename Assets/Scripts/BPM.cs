using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPM : MonoBehaviour
{
    //Sync Rhythm by FrameRate System
    public static BPM _bPM;
    private float _beatInterval,                            // _beatInterval (duracion del beat/corchea)
                  _beaTimer,                                // Actualización del Beat (por frame)
                  _beatIntervalD8,                          // Duración del Beat/Corchea en 8 tiempos (division maxima en notación musical)
                  _beatTimerD8;                             // Actualización del Beat dividido en 8 tiempos (por frame)

    public float bPM = 0f;                                  // BPM de la canción/ritmo
    public static bool beatFull,                            // Controlador de contador de Beats
                       beatD8;                              // Controlador de contador de Beats divididos en 8 tiempos
    public static int beatCountFull,                        // Cantidad de Beats alcanzados
                      beatCountD8;                          // Cantidad de Beats divididos en 8 tiempos alcanzados

    //Sync Rhythm Popertly by AudioSettings
    public AudioSource song;                                // Canción que se reproduce en el nivel
    [Tooltip("Current position of the song in seconds")]
    public float songPosition = 0f;                         // Posición de la canción en el sistema de Audio (intervalo de tiempo no dependiente del FrameRate)
    [Tooltip("Current position of the song in beats")]
    public float songPosInBeats = 0f;
    public float songOffset = 0f;                           // Colchon de sincronización para introducción con delay 
    [Tooltip("The Duration of a Beat ")]
    public float secPerBeat = 0f;
    [Tooltip("How much time in seconds has passed since the song started")]
    public double dspTimeSong = 0;                          // Posición de la cancion al ser reproduc¡da
    public float lastBeat = 0f;                             // Posición del ultimo Beat de la canción
    public float lastBeatD8 = 0f;                           // Posición del último Beat e la cancion dividado en 8 tiempos
    public bool startGame = false;

    /*public Transform[] tapPoints;
    public float[] notes;
    public int nextIndex = 0;
    public GameObject notesPref;
    */
    //Singleton & Variables Assigment
    private void Awake()
    {
        _beatInterval = 60 / bPM;
        _beatIntervalD8 = _beatInterval / 8;
        secPerBeat = _beatInterval;
        _bPM = this;
        /*if (_bPM != null && _bPM != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _bPM = this;
            DontDestroyOnLoad(this.gameObject);
        }*/
    }

    private void Start()
    {
        Application.targetFrameRate = 120;

        /*for(int i = 0; i < tapPoints.Length; i++)
        {
            tapPoints[i] = notesPref.transform.GetChild(i);
        }
        
        for (int i = 0; i < notes.Length; i++)
        {
            //Debug.Log(tapPoints[i].GetComponent<TapNode>().nodeNote);
            notes[i] = tapPoints[i].GetComponent<TapNode>().nodeNote;
        }*/
    }

    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.H) || Input.GetMouseButtonDown(0)) && !startGame)
        {
            startGame = true;
            song.Play();
            dspTimeSong = AudioSettings.dspTime;
        }
        songPosition = (float)(AudioSettings.dspTime - dspTimeSong) * song.pitch - songOffset;
        songPosInBeats = songPosition / secPerBeat;
        
        if (startGame)
        {
            BeatDetection();
        }
    }

    //By Frame Detection
    /*void BeatDetection()
    {
        //full beat count
        beatFull = false;
        _beatInterval = 60 / bPM;
        _beaTimer += Time.deltaTime;
        if(_beaTimer >= _beatInterval)
        {
            _beaTimer -= _beatInterval;
            beatFull = true;
            beatCountFull++;
        }

        //divided beat count
        beatD8 = false;
        _beatIntervalD8 = _beatInterval / 8;
        _beatTimerD8 += Time.deltaTime;
        if(_beatTimerD8 >= _beatIntervalD8)
        {
            _beatTimerD8 -= _beatIntervalD8;
            beatD8 = true;
            beatCountD8++;
        }
    }*/

    //By Position Detection
    void BeatDetection()
    {
        //full beat count
        beatFull = false;
        if (songPosition > lastBeat + _beatInterval)
        {
            lastBeat += _beatInterval;
            beatFull = true;
            beatCountFull++;
        }

        //divided beat count
        beatD8 = false;
        if (songPosition > lastBeatD8 + _beatIntervalD8)
        {
            lastBeatD8 += _beatIntervalD8;
            beatD8 = true;
            beatCountD8++;
        }
    }
}
