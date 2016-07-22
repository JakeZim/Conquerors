using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeckBuilder : MonoBehaviour {

    //The UI content area for all cards
    public GameObject AllContent;

    //Used to define the grid for cards to be shown in the menu
    public GameObject cardPlacementHolder;

    //THe ratio between width and height of the card placement holder
    static float placementRatio = 1.618f;

	// Use this for initialization
	void Start () {
        float placementWidth = AllContent.GetComponent<RectTransform>().rect.xMax - AllContent.GetComponent<RectTransform>().rect.xMin;
        Debug.Log(placementWidth);
        Vector2 placementRect = new Vector2(placementWidth, placementWidth * placementRatio);


        Color[] colorList = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };

        int rows = 12;

        for(int r = 0; r < rows; r++)
        {
            for(int c = 0; c < 5; c++)
            {
                Debug.Log("Card added");
                GameObject newCardPlacement = (GameObject)Instantiate(cardPlacementHolder);
                newCardPlacement.transform.SetParent(AllContent.transform, false);

                newCardPlacement.GetComponent<RectTransform>().sizeDelta = placementRect;

                newCardPlacement.GetComponent<RectTransform>().anchoredPosition = new Vector2(placementWidth * c, placementWidth * placementRatio * r);

                newCardPlacement.GetComponent<Image>().color = colorList[c];
            }
        }




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
