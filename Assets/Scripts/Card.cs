//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Authors: Jake
/// Editors:
/// Purpose: 
/// Tutorials Used: 
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public string title;

    public Card()
    {
		title = "Default Title";
		// Previously was this: Random.Range(0, 10000).ToString(); 
		// However, that caused errors
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    //, IBeginDragHandler, IDragHandler, IEndDragHandler

    //private Vector2 grabPoint;
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    //Keep the card "held" at the same position during the drag instead of snapping to the center
    //    float diffX = this.transform.position.x - eventData.position.x;
    //    float diffY = this.transform.position.y - eventData.position.y;
    //    grabPoint = new Vector2(diffX, diffY);
    //}

    //
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Debug.Log("Title: " + title);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }


    //public void OnDrag(PointerEventData eventData)
    //{
    //    this.transform.position = eventData.position + grabPoint;
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    Debug.Log("END DRAG");
    //}
}
