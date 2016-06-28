using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Allows drop zones to be selective
	public Draggable.Slot cardType = Draggable.Slot.GENERIC;

	// Triggers when pointer enters a droppable zone
	public void OnPointerEnter(PointerEventData eventData) {
		// As long as something is being dragged....
		if (eventData.pointerDrag == null) {
			return;
		}

		// If a draggable object is hovered over this dropzone, set its
		// placeholder parent as this dropzone
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			d.placeholderParent = this.transform;
		}
	}

	// Triggers when pointer exits a droppable zone
	public void OnPointerExit(PointerEventData eventData){
		// As long as something is being dragged....
		if (eventData.pointerDrag == null) {
			return;
		}

		// If a draggable objectexits this dropzone, set its
		// palceholder parent as its return parent
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null && d.placeholderParent == this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}

	// Triggers when a game object is dropped over a droppable zone
	public void OnDrop(PointerEventData eventData) {
		Debug.Log ("OnDrop to " + gameObject.name);

		// If a draggable object is dropped onto this dropzone, set its
		// return parent as this dropzone
		Draggable d = eventData.pointerDrag.GetComponent<Draggable> ();
		if (d != null) {
			if(cardType == d.cardType || cardType == Draggable.Slot.GENERIC){
			d.parentToReturnTo = this.transform;
		
			}
	
		}

	}

}