using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {
    //The deck class will hold the list of cards the user has in their deck.
    //Variables

    public GameObject BlankCard;


    //List of the cards in deck - index 0 is the bottom while cards.Count is the top card
    List<Card> cards = new List<Card>();

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
            Card c = cards[k];
            cards[k] = cards[n];
            cards[n] = c;
        }
    }

    /// <summary>
    /// Draw the single topmost card
    /// </summary>
    public Card Draw()
    {
        Card drawn = cards[cards.Count];

        //Remove card from deck
        cards.RemoveAt(cards.Count);
        return drawn;
    }

    /// <summary>
    /// Draw N cards returning a List with the top card at index 0
    /// </summary>
    public List<Card> Draw(int n)
    {
        List<Card> drawn = new List<Card>();
        for(int i = 0; i < n; i++)
        {
            drawn[i] = Draw();
        }

        return drawn;
    }
    
    /// <summary>
    /// View the top n cards with the top card at index 0
    /// </summary>
    public List<Card> View(int n)
    {
        List<Card> peek = new List<Card>();
        for (int i = 0; i < n; i++)
        {
            peek[i] = View();
        }

        return peek;
    }

    /// <summary>
    /// View the top most card
    /// </summary>
    public Card View()
    {
        return cards[cards.Count];
    }

    #region Required overides for MonoBehavior - may be removed later
    // Use this for initialization
    void Start () {
        for(int i = 0; i < 30; i++)
        {
            cards.Add(new Card());
        }

        Vector3 deckLocation = new Vector3(0, 0, 0);
        Vector3 offset = new Vector3(0, .1f, 0);
        foreach (Card c in cards)
        {
            GameObject clone = (GameObject)Instantiate(BlankCard, deckLocation, new Quaternion(-1,0,0,1));
            clone.GetComponent<Card>().title = c.title;
            deckLocation += offset;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    #endregion
}
