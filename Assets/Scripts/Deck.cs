using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Deck {

    int maxDeckSize = 52;
    List<Card> deck = new List<Card>();
    public GameObject cardPrefab;
    public Transform canvas;
    public RectTransform spawnLoc;
    public bool drawCard = false;

    #region Constructors
    //
    public Deck()
    {

    }

    public Deck(List<Card> nDeck) {
        this.deck = nDeck;
    }

    public Deck(List<Card> nDeck, int nMaxDeckSize)
    {
        this.deck = nDeck;
        this.maxDeckSize = nMaxDeckSize;
    }

    public Deck(int nMaxDeckSize)
    {
        this.maxDeckSize = nMaxDeckSize;
    }
    
    #endregion
    
    #region Getters and Setters
    
    public int GetMaxDeckSize () 
    {
        return this.maxDeckSize;   
    }
    
    public void SetMaxDeckSize (int nMaxDeckSize)
    {
        this.maxDeckSize = nMaxDeckSize;
    }
    #endregion
    
    public bool LoadDeck(string path)
    {	
        //Parse Through Text Document for Deck
		string[] data = Parser.ParseText (path);
		if (data != null) {
			deck = new List<Card> (0);
			for (int x = 0; x < data.Length; x = x + 7) {
				int l = int.Parse (data [x + 6]);
				if (l < 5) {
					for (int y = 0; y < l; y++) {
						GameObject obj = GameObject.Instantiate (cardPrefab, spawnLoc.localPosition, Quaternion.identity) as GameObject;
						obj.transform.SetParent (canvas, false);
						obj.transform.SetAsFirstSibling ();
						obj.transform.localPosition = spawnLoc.localPosition;
						Card card = obj.GetComponent<Card> ();
						card.SetCardName (data [x]);
						card.SetBackName (data [x + 1]);

						card.SetCardType (int.Parse (data [x + 3]));
						card.SetValue (int.Parse (data [x + 4]));
						card.SetSortWeight (int.Parse (data [x + 5]));
						card.SetSpriteLIndex (SpriteManager.GetSpriteIndex (data [x + 2]));
						card.RefreshSprite ();
						deck.Add (card);
					}
				} else
					Debug.Log ("TOO MANY");
			}
			return true;
		}
        else
			return false;
    }

    // Add card at beginning of deck if deck is smaller than deckSize
    public bool AddCard(Card c)
    {
        if (deck.Count + 1 >= maxDeckSize)
            return false;
        else
        {
            deck.Add(c);
            return true;
        }
    }
    
    // Insert card at i if deck is smaller than deckSize
    public bool InsertCard (Card c, int i)
    {
        if (deck.Count + 1 >= maxDeckSize)
            return false;
        else
        {
            deck.Insert(i, c);
            return true;
        }
    }

    //If the location is valid, remove the card. Otherwise, return false
    public bool RemoveCard(int i)
    {
        if (deck.Count > i)
        {
            deck.RemoveAt(i);
            return true;
        }
        else
            return false;
        
    }
    
    // Shuffle Deck at random
    public void ShuffleDeck ()
    {
        for(int x = 0; x < deck.Count; x++){
            Card temp = deck[x];
            int r = Random.Range(0, deck.Count);
            deck[x] = deck[r];
            deck[r] = temp;
        }
    }
    
    // Sort Deck based on Card sortWeight
    public void SortDeck ()
    {
        deck = Sort<Card>.SortList(deck);
    }

    //
	public Card DrawCard ()
    {
        if (deck.Count > 0)
        {
            Card c = deck[0];
            c.StartFlip();
            RemoveCard(0);
            return c;
        }
        else
            return null;
    }

    //
	public bool CanDraw () {
		if (deck.Count > 0) {
			return true;
		}
        else {
			return false;
		}
	}
}
