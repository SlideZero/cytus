using UnityEngine;

public class TouchManager : MonoBehaviour
{
    /*public GameObject notePlayer;
    Note note;

    private void Awake()
    {
        note = notePlayer.GetComponent<Note>();
    }*/

    private void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector3.forward, 15f);
                /*if (hit.collider.CompareTag("Note"))
                {
                    note.TapNote();
                }*/
                if(hit.collider.CompareTag("SingleNote"))
                {
                    hit.collider.GetComponent<SingleNote>().TapNote();
                }
            }
        }
    }
}
