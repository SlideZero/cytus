using UnityEngine;

public enum NoteType
{
    Single, Hold
};

[ExecuteInEditMode]
public class GridSize : MonoBehaviour
{
    private const float widthDivisions = 0.03125f;

    public NoteType noteType;

    public RectTransform myTransform;
    //public beatAlign beatAlineation;
    [Range(0, 16)]
    public int rowSelector;
    [Range(2,30)]
    public int columnSelector;
    /*public GameObject childColor;
    private SpriteRenderer spriteRend;
    private SpriteRenderer childSpriteRend;*/

    private void Awake()
    {
        //myTransform = GetComponent<RectTransform>();
        //childColor = 
    }

    private void Update()
    {
        AlignNotes(columnSelector, rowSelector);

        if (noteType == NoteType.Hold)
        {
           
        }
    }

    /*private void ChangeColor()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        childSpriteRend = childColor.GetComponent<SpriteRenderer>();
    */

    private void AlignNotes(int column, int row)
    {
        myTransform = GetComponent<RectTransform>();
        float columnPos = column * widthDivisions;
        float rowPos = row * 0.0625f;

        myTransform.anchorMin = new Vector2(columnPos, rowPos);
        myTransform.anchorMax = new Vector2(columnPos, rowPos);
        myTransform.pivot = new Vector2(0.5f, 0.5f);
    }
}

