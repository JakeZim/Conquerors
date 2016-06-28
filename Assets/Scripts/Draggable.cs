using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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

	// Allows for dropzones to be selective
	public enum Slot {RECRUIT, ASSET, EVENT, GENERIC};
	public Slot cardType = Slot.GENERIC;

	// Tracks where the object should bounce to if an 'illegal' drop is made
	public Transform parentToReturnTo = null;
	public Transform placeholderParent = null;

	GameObject placeholder = null;

	// Runs when a object that has been clicked and held starts to move
    public void OnBeginDrag(PointerEventData eventData)
    {
		// Creates a placeholder so that dragging the card looks nicer
		placeholder = new GameObject ();
		placeholder.transform.SetParent (this.transform.parent);
		LayoutElement le = placeholder.AddComponent<LayoutElement> ();
		le.preferredWidth = this.GetComponent<LayoutElement> ().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement> ().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;
		placeholder.transform.SetSiblingIndex (this.transform.GetSiblingIndex());

		// Sets the return parent as its parent prior to dragging
		parentToReturnTo = this.transform.parent;
		placeholderParent = parentToReturnTo;
		// Sets the parent to the canvas during the duration of the drag
		this.transform.SetParent (this.transform.parent.parent);

		// Blocks ray casts while card is being dragged
		// Allows for droppable zones to work
		GetComponent<CanvasGroup> ().blocksRaycasts = false;

       	//Keep the card "held" at the same position during the drag instead of snapping to the center
       	float diffX = this.transform.position.x - eventData.position.x;
       	float diffY = this.transform.position.y - eventData.position.y;
       	grabPoint = new Vector2(diffX, diffY);
    }

	// Triggers a whole bunch while the object is being dragged
    public void OnDrag(PointerEventData eventData)
    {
       	this.transform.position = eventData.position + grabPoint;

		if (placeholder.transform.parent != placeholderParent) {
			placeholder.transform.SetParent(placeholderParent);
		}

		// default placeholder to the very right
		int newSiblingIndex = placeholderParent.childCount;

		// Update position of placeholder as the card is dragged across the dropzone
		for (int i = 0; i < placeholderParent.childCount; i++) {
			if (this.transform.position.x < placeholderParent.GetChild (i).position.x) {
				newSiblingIndex = i;

				if (placeholder.transform.GetSiblingIndex () < newSiblingIndex) {
					newSiblingIndex--;
				}

				break;
			}
		}
    }

	// Runs when the mouse button is released
    public void OnEndDrag(PointerEventData eventData)
    {
       	Debug.Log("END DRAG");

		// Places object in parent specified by parentToReturnTo
		this.transform.SetParent (parentToReturnTo);

		//Places object in its placeholders position instead of at the end
		this.transform.SetSiblingIndex (placeholder.transform.GetSiblingIndex ());

		// Allows for ray casts again after dragging
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		//Removes placeholder
		Destroy(placeholder);
   	}
}	
