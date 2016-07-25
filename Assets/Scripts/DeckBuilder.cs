using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeckBuilder : MonoBehaviour {

    //The UI content area for all cards
    public GameObject AllContent;

    //Used to define the grid for cards to be shown in the menu
    public GameObject cardPlacementHolder;

    //The left and right boundaries of the scroll rect to determine width
    public GameObject[] cols;

    public GameObject popUp;

    //The ratio between width and height of the card placement holder
    static float spacing = 10f;

	// Use this for initialization
	void Start () {



        Color[] colorList = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };

        int rows = 12;

        for(int r = 0; r < rows; r++)
        {
            for(int c = 0; c < 5; c++)
            {
                Debug.Log("Card added");
                GameObject newCardPlacement = (GameObject)Instantiate(cardPlacementHolder);
                newCardPlacement.transform.SetParent(cols[c].transform, false);

                newCardPlacement.GetComponent<RectTransform>().anchorMin = new Vector2(0.1f, 1f);
                newCardPlacement.GetComponent<RectTransform>().anchorMax = new Vector2(0.9f, 1f);
                newCardPlacement.GetComponent<ShowPopUp>().popUp = popUp;

                newCardPlacement.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -r * (newCardPlacement.GetComponent<RectTransform>().sizeDelta.y + spacing));

                newCardPlacement.GetComponent<Image>().color = colorList[c];
            }
        }
        foreach(GameObject col in cols)
        {
            col.GetComponent<LayoutElement>().minHeight = rows * ((150 + spacing));
        }




	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreateAllContentGrid()
    {

    }
}
