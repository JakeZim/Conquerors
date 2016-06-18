using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour {
    //The deck class will hold the list of cards the user has in their deck.
    //Variables
    
    //List of the cards in deck - index 0 is the bottom while cards.Count is the top card
    List<GameObject> cards = new List<GameObject>();

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
    /// Gus trying to add cards to the deck
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
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    #endregion
}
