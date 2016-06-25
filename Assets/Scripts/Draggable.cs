using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private Vector2 grabPoint;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Keep the card "held" at the same position during the drag instead of snapping to the center
        float diffX = this.transform.position.x - eventData.position.x;
        float diffY = this.transform.position.y - eventData.position.y;
        grabPoint = new Vector2(diffX, diffY);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position + grabPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("END DRAG");
    }
}
