using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanLine : MonoBehaviour
{
    [Tooltip("BPM de la canción (este campo es automático).")]
    [SerializeField] private float bPM = 0f;                                         //BPM de la canción
    [Tooltip("Velocidad de desplazamiento del Scanline. " +
        "Tiempo que toma al Scanline ir de arriba a abajo " +
        "basado en la duración en beats por segundo que recorre en el trayecto" +
        "(este campo es automático).")]
    [SerializeField] private float frequency = 0f;                                   //Velocidad de desplazamiento por beats del scanline (segundos)
    [Tooltip("Bandera para la dirección del Scanline (este campo es automático).")]
    [SerializeField] private int dir = 0;                                            //Bandera para la dirección del Scanline
    [Tooltip("Velocidad de desplazamiento del Scanline (este campo es automático).")]
    [SerializeField] private float speed = 0f;                                       //Velocidad de desplazamiento del Scanline (ciclo arriba-abajo)

    [Tooltip("Beat inicial de desplazamiento del Scanline." +
        "Debe ser mayor a 0 para poder inicializar un cálculo (este campo es automatico).")]
    public float inicialBeat = 0f;                                                   //Beat que inicializa el calculo del desplazamiento

    [SerializeField] private GameObject tLine;
    private Animator tLineAnim;
    [SerializeField] private GameObject bLine;
    private Animator bLineAnim;

    [SerializeField] private float sheetHeight = 0f;

    private void Awake()
    {
        //Inicialización del beat para el primer calculo
        inicialBeat = 1;
        //inicialización de la dirección del Scanline
        //dir = 1;
        tLineAnim = tLine.GetComponent<Animator>();
        bLineAnim = bLine.GetComponent<Animator>();        
    }
    
    void Start()
    {
        //Obtener BPM de la canción a traves del Manager
        bPM = (BPM._bPM.bPM);
        /*Inicialización de la frecuencia de desplazamiento.
         Esta frecuencia inicial ocurre del beat 0 al beat inicial (beat 1, en mayoria de casos).
         Si el Scanline se desplaza desde el punto maximo al minimo o veceversa, la frecuencia incial
         se da por la duración de un beat en segundos (60 / BPM), contando que el punto medio de la
         pantalla representa el beat 0.
         Si el Scanline comienza en la parte media de la pantalla, la velocidad de la frecuancia
         debe duplicarse (120 / BPM) para desplazarse mas lentamente y alcanzar el punto maximo o minimo en el primer beat.
         Todo esto se aplica a musica escrita en 4/4.*/
        frequency = 120 / bPM;
        sheetHeight = tLine.transform.position.y - bLine.transform.position.y;
        transform.position = new Vector3(0, tLine.transform.position.y - (sheetHeight / 2), 0);
    }

    
    void Update()
    {
        //sheetHeight = tLine.transform.position.y - bLine.transform.position.y;
        if (BPM._bPM.startGame)
        {
            //Dirección del Scanline hacia arriba
            if (dir == 1)
            {
                //Calculo de la velocidad de desplazamiento del Scanline
                speed = (sheetHeight * Time.deltaTime) / (frequency);
                //Desplazamiento del Scanline
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, tLine.transform.position.y), speed);
                //Alcance del punto maximo del Scanline
                if(transform.position.y >= tLine.transform.position.y)//3.5f)
                {
                    tLineAnim.SetTrigger("ReachTopLimit");
                    //Aumento del contador de beats que permite realizar el calculo de tiempo al siguiente intervalo de beats
                    inicialBeat += 2;
                    //Calculo de la velocidad en segundos necesaria para el proximo intervalo de beats del Scanline
                    frequency = (inicialBeat - BPM._bPM.songPosInBeats) * BPM._bPM.secPerBeat;
                    //Cambio de dirección del Scanline
                    dir = -1;
                }
            }
            else if (dir == -1)
            {
                speed = (sheetHeight * Time.deltaTime) / (frequency);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, bLine.transform.position.y), speed);
                if(transform.position.y <= bLine.transform.position.y)
                {
                    bLineAnim.SetTrigger("ReachBottomLimit");
                    inicialBeat += 2;
                    frequency = (inicialBeat - BPM._bPM.songPosInBeats) * BPM._bPM.secPerBeat;
                    dir = 1;
                }
            }
            
        }
    }
}
