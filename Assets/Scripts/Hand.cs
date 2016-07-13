using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Hand
{
    public int maxHandSize = 7;
    public int startHandSize = 5;
    List<Card> hand = new List<Card>(0);
    public Transform handLoc;
    public Vector2 padding;
    public Vector2 direction;
    public Canvas canvas;
    
    #region Constructor
    
    public int GetMaxHandSize () 
    {
        return maxHandSize;
    }

    public int GetStartHandSize ()
    {
        return startHandSize;
    }
    
    public void SetMaxHandSize (int nMaxHandSize)
    {
        maxHandSize = nMaxHandSize;
    }

    public void SetStartHandSize (int nStartHandSize)
    {
        startHandSize = nStartHandSize;
    }
    
    #endregion
    
	public bool CanDraw (){
		if (hand.Count >= maxHandSize)
			return false;
		else
			return true;
	}

    // Insert Card at Index
    public bool InsertCard (Card c, int i)
    {
        if (hand.Count >= maxHandSize)
            return false;
        else
        {
            hand.Insert(i, c);
            SortHand();
            string d = "";
            for(int x = 0; x < hand.Count; x++)
            {
                d += hand[x].GetCardName() + ",";
            }
            return true;
        }
        //Sort the Hand after inserting
    }

    // Remove Card at Index
    public bool RemoveCard(int i)
    {
        if (hand.Count > i)
        {
            hand.RemoveAt(i);
            SortHand();
            return true;
        }
        else
            return false;
        //Sort the Hand after removing
    }
    
    // Shuffle Hand at random
    public void ShuffleHand ()
    {
        for(int x = 0; x < hand.Count; x++){
            Card temp = hand[x];
            int r = Random.Range(0, hand.Count);
            hand[x] = hand[r];
            hand[r] = temp;
        }
    }
    
    // Sort Hand based on Card sortWeight
    public void SortHand ()
    {
        hand.Sort();
        RepositionCards();
    }
    
    public void RepositionCards () {
        float cardWidth = hand[0].gameObject.GetComponent<RectTransform>().sizeDelta.x;
        for(int x = 0; x < hand.Count; x++){
            Debug.Log(cardWidth + ", " + canvas.scaleFactor + " , " + cardWidth*canvas.scaleFactor);
            Vector2 nLoc = new Vector2(direction.x*x*(cardWidth+padding.x), 0)+(Vector2)handLoc.localPosition;

            hand[x].MoveCardToHand(nLoc);
        }
    }
}