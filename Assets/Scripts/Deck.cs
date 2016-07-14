///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Authors: Gus
/// Authors: AJ, Gus
/// Editors:
/// Purpose: This class is designed to hold a list of cards as well as provide several functions to manipulate said cards.
/// Tutorials Used: http://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable] // This means we can save all the variables in this script.
public class Deck : MonoBehaviour {
    //The deck class will hold the list of cards the user has in their deck.
    //Variables

    public GameObject BlankCard;
    public DropZone PlayerHand;
    public Transform CardPrefab;


    //List of the cards in deck - index 0 is the bottom while cards.Count is the top card
    List<GameObject> cards = new List<GameObject>();

    public static Deck current; // We should be able to set other deck instances to "current" to avoid the getcomponent function.

    //Empty constructor
    public Deck()
    {
        
    }

    /// <summary>
    /// Shuffle the deck
    /// </summary>
    public void Shuffle()
    {
        int n = cards.Count;
        while(n > 1)
        {
            n--;
            int k = Random.Range(0, n+1);
            GameObject c = cards[k];
            cards[k] = cards[n];
            cards[n] = c;
        }
    }

    /// <summary>
    /// Draw the single topmost card to player's hand
    /// </summary>
    public void DrawToHand()
    {
        GameObject drawn = Instantiate(BlankCard);
        drawn.transform.FindChild("Card Title").GetComponent<Text>().text = "NEW CARD!" + cards.Count;
        drawn.transform.FindChild("Card Description").GetComponent<Text>().text = "NEW DESCRIPTION! PEW PEW!";
        drawn.GetComponent<Card>().transform.SetParent(PlayerHand.transform,false);
        cards.RemoveAt(cards.Count-1);
    }

    /// <summary>
    /// Draw the single topmost card
    /// </summary>
    public GameObject Draw()
    {
        GameObject drawn = cards[cards.Count];
        
        //Remove card from deck
        cards.RemoveAt(cards.Count);
        return drawn;
    }

    /// <summary>
    /// Draw N cards returning a List with the top card at index 0
    /// </summary>
    public List<GameObject> Draw(int n)
    {
        List<GameObject> drawn = new List<GameObject>();
        for(int i = 0; i < n; i++)
        {
            drawn[i] = Draw();
        }

        return drawn;
    }
    
    /// <summary>
    /// View the top n cards with the top card at index 0
    /// </summary>
    public List<GameObject> View(int n)
    {
        List<GameObject> peek = new List<GameObject>();
        for (int i = 0; i < n; i++)
        {
            peek[i] = cards[cards.Count - i];
        }

        return peek;
    }

    /// <summary>
    /// Add cards to the deck
    /// </summary>
    public void AddCard(GameObject Card, int position) /// position = -1 for on the bottom, 0 for on top, -2 is at random, any other number is that many from the top.
    {
        if (position == -1)
        {
            cards.Insert(0, Card);
        }

        else if (position == -2)
        {
            int x = Random.Range(0, cards.Count);
            cards.Insert(x, Card);
        }

        else if (position == 0)
        {
            cards.Add(Card);
        }

        else
        {
            cards.Insert(cards.Count-position, Card);
        }

    }

    #region Required overides for MonoBehavior - may be removed later
    // Use this for initialization
    void Start () {
        for(int i = 0; i < 30; i++)
        {
            cards.Add(new GameObject());
        }

        Vector3 deckLocation = new Vector3(0, 0, 0);
        Vector3 offset = new Vector3(0, .1f, 0);
        /*foreach (GameObject c in cards)
        {
            GameObject clone = (GameObject)Instantiate(BlankCard, deckLocation, new Quaternion(-1,0,0,1));
           // clone.GetComponent<Card>().title = c.title; // This is giving errors and I don't know what we were trying to do previously with this line. 
           // I changed all instances of Card with GameObject except for this one here because even doing so didn't resolve the issue so I need more guidance.
            deckLocation += offset;
        }*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    #endregion
}
