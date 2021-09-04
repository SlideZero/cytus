using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleNote : MonoBehaviour
{
    enum noteRank
    {
        EXCELLENT, PERFECT, GOOD, BAD
    };
    noteRank Rank;

    public GameObject scanline;
    public float noteNumber = 0f;                                                      //Numero de nota (beat) en la canción
    public float spawnRange = 0f;
    public float spawnBeat = 0f;
    public float animatorSpeed = 0f;

    //Componentes de este objeto padre
    [SerializeField] private CircleCollider2D tapCollider;
    [SerializeField] private SpriteRenderer spriteRend;
    [SerializeField] private SpriteMask spriteMask;
    [SerializeField] private Animator animator;

    //Componente animado hijo (indicador circular)
    [SerializeField] private GameObject circleIndicator;
    [SerializeField] private SpriteRenderer circleSpriteRend;
    [SerializeField] private Animator circleAnimator;

    //Componente circulo interior indicativo
    [SerializeField] private GameObject innerCircle;

    //Componente circulo color
    [SerializeField] private GameObject backgroundColor;
    [SerializeField] private SpriteRenderer bgColor;

    private void Awake()
    {
        tapCollider = GetComponent<CircleCollider2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        spriteMask = GetComponent<SpriteMask>();
        animator = GetComponent<Animator>();

        //Componentes del indicador hijo
        circleSpriteRend = circleIndicator.GetComponent<SpriteRenderer>();
        circleAnimator = circleIndicator.GetComponent<Animator>();

        bgColor = backgroundColor.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Rank = noteRank.BAD;

        tapCollider.enabled = false;
        spriteRend.enabled = false;
        spriteMask.enabled = false;
        animator.enabled = false;

        //Componentes del indicador hijo
        circleSpriteRend.enabled = false;
        circleAnimator.enabled = false;

        //Componente circulo interior indicativo
        innerCircle.SetActive(false);

        bgColor.enabled = false;

        //Asignación de variables y valores
        spawnBeat = noteNumber - spawnRange;
        animatorSpeed = spawnRange * BPM._bPM.secPerBeat;

        animator.speed = 1 / animatorSpeed;
        circleAnimator.speed = 1 / (1.5f * BPM._bPM.secPerBeat);
    }

    // Update is called once per frame
    void Update()
    {
        if (BPM._bPM.startGame)
        {
            if (BPM._bPM.songPosInBeats >= spawnBeat)
            {
                tapCollider.enabled = true;
                spriteRend.enabled = true;
                spriteMask.enabled = true;
                animator.enabled = true;

                //circleSpriteRend.enabled = true;
                //circleAnimator.enabled = true;

                innerCircle.SetActive(true);

                bgColor.enabled = true;

				//animator.speed = 1 / BPM._bPM.secPerBeat;
				//animator.SetTrigger("PlayAppear");
				animator.SetTrigger("PlayGrow");
				//circleAnimator.SetTrigger("PlayTap");
			}

            /*if(BPM._bPM.songPosInBeats >= spawnBeat)
			{
				animator.speed = 1 / animatorSpeed;
				animator.SetTrigger("PlayGrow");
			}*/

            if (BPM._bPM.songPosInBeats >= noteNumber - 1.5f)
            {
                circleSpriteRend.enabled = true;
                circleAnimator.enabled = true;
                circleAnimator.SetTrigger("PlayTap");
            }
                
            //if (BPM._bPM.songPosInBeats > noteNumber + 1f)
              //  DestroyNote();
        }
        //Debug.Log(Rank);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (BPM._bPM.songPosInBeats >= noteNumber - 0.5f)
        {
            if ((collision.transform.position.y >= transform.position.y - 0.5f) && (collision.transform.position.y <= transform.position.y + 0.5f))
            {
                //if (BPM._bPM.songPosInBeats >= noteNumber && BPM._bPM.songPosInBeats < noteNumber + 0.5f)
                Rank = noteRank.EXCELLENT;
            }
            else if ((collision.transform.position.y >= transform.position.y - 1f) || (collision.transform.position.y <= transform.position.y + 1f))
            {
                //if (BPM._bPM.songPosInBeats >= noteNumber - 1 || BPM._bPM.songPosInBeats <= noteNumber + 1)
                Rank = noteRank.PERFECT;
            }

			

			/*else if(BPM._bPM.songPosInBeats < noteNumber - 1 || BPM._bPM.songPosInBeats > noteNumber + 1)
            {
                Rank = noteRank.GOOD;
            }*/
        }
		if (BPM._bPM.songPosInBeats >= noteNumber - 1f)
		{
		    if ((collision.transform.position.y < transform.position.y - 1f) || (collision.transform.position.y > transform.position.y + 1f))
			{
				Rank = noteRank.GOOD;
			}
		}
		//Debug.Log(Rank);
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        
            Rank = noteRank.BAD;

            if (BPM._bPM.songPosInBeats > noteNumber)
                DestroyNote(0.0f);

    }

    public void TapNote()
    {
		if (Rank == noteRank.EXCELLENT)
		{
			GameObject ripple = ObjectPooler.SharedInstance.GetPooledObject("RippleExcellent");
			if (ripple != null)
			{
				ripple.SetActive(true);
				ripple.transform.position = transform.position;
			}
			ScoreManager.scoreManager.AddScorePoints(20);
		}
		if (Rank == noteRank.PERFECT)
        {
            GameObject ripple = ObjectPooler.SharedInstance.GetPooledObject("RipplePerfect");
            if (ripple != null)
            {
                ripple.SetActive(true);
                ripple.transform.position = transform.position;
            }
            ScoreManager.scoreManager.AddScorePoints(10);
        }
        else if (Rank == noteRank.GOOD)
        {
            GameObject ripple = ObjectPooler.SharedInstance.GetPooledObject("RippleGood");
            if (ripple != null)
            {
                ripple.SetActive(true);
                ripple.transform.position = transform.position;
            }
            ScoreManager.scoreManager.AddScorePoints(5);
        }
        else if (Rank == noteRank.BAD)
        {
            ScoreManager.scoreManager.AddScorePoints(-5);
        }

		ScoreManager.scoreManager.AddNote(Rank.ToString());
        DestroyNote(0);
    }

    private void DestroyNote(float delay)
    {
        Destroy(gameObject, delay);
    }

    private void OnMouseDown()
    {
        TapNote();
    }
}




/*if((scanline.transform.position.y >= transform.position.y - 0.5f) && (scanline.transform.position.y <= transform.position.y + 0.5f))
        {
            Rank = noteRank.PERFECT;
        }
        else if((scanline.transform.position.y >= transform.position.y - 1f) || (scanline.transform.position.y <= transform.position.y + 1f))
        {
            Rank = noteRank.GOOD;
        }
        else
        {
            Rank = noteRank.BAD;
        }*/
