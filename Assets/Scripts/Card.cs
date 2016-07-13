using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Card : MonoBehaviour, IComparable<Card>
{

    public int spriteLIndex = 0;
    int type = 0;
    int value = 0;
    int sortWeight = 0;
    public string cardName = "King";
    public string backName = "Back";
    public bool faceUp = true;
    public Image img;
    public Animator animator;
    public CardMotion motion;

    #region Constructors
    
    public Card(){
    }

    public Card(string nCardName, string nBackName, int nSpriteLIndex, int nType, int nValue, int nSortWeight)
    {
        this.cardName = nCardName;
        this.backName = nBackName;
        this.spriteLIndex = nSpriteLIndex;
        this.type = nType;
        this.value = nValue;
        this.sortWeight = nSortWeight;
    }

    #endregion
    
    #region Getters and Setters
    
    public string GetCardName ()
    {
        return cardName;
    }
    
    public string GetBackName () 
    {
        return backName;
    }
    
    public int GetCardType()
    {
        return type;
    }
    
    public int GetValue()
    {
        return value;
    }
    
    public int GetSortWeight()
    {
        return sortWeight;
    }
    
    public int GetSpriteLIndex ()
    {
        return spriteLIndex;
    }
    
    public void SetCardName (string nCardName)
    {
        cardName = nCardName;
    }

    public void SetBackName (string nBackName)
    {
        backName = nBackName;
    }
    
    public void SetCardType(int nType)
    {
        type = nType;
    }
    
    public void SetValue(int nValue)
    {
        value = nValue;
    }
    
    public void SetSortWeight(int nSortWeight)
    {
        sortWeight = nSortWeight;
    }
    
    public void SetSpriteLIndex(int nI)
    {
        spriteLIndex = nI;
    }
    
    #endregion

    #region Operators

    public static bool operator <(Card c1, Card c2) 
    {
        
        return c1.GetSortWeight() < c2.GetSortWeight();
    }

    public static bool operator >(Card c1, Card c2) 
    {
        return c1.GetSortWeight() > c2.GetSortWeight();
    }

    public int CompareTo(Card other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in weight
        return sortWeight - other.sortWeight;
    }

    #endregion

    //Update Card Image on Awake
    void Awake () {
        SetCardSprite(cardName, backName, spriteLIndex);
    }
	
    //Set Card Sprite to Front if Face Up or Back if Face Down and update
    //global variables to reflect changes
	public void SetCardSprite(string front, string back, int spriteLInd)
    {
        if (!faceUp)
            img.sprite = SpriteManager.GetCardSprite(back, spriteLInd);
        else
            img.sprite = SpriteManager.GetCardSprite(front, spriteLInd);
        cardName = front;
        backName = back;
        spriteLIndex = spriteLInd;
    }

    //Update the Sprite 
	public void RefreshSprite ()
	{
		SetCardSprite (cardName, backName, spriteLIndex);	
	}

    //Begin Card Flip animation by setting Flip animation trigger
    public void StartFlip()
    {
        animator.SetTrigger("Flip");
    }

    //Triggered by flip animation event, swap front to back or back to front on
    //90 degree rotation
    public void FlipCard()
    {
        if (faceUp) { 
            faceUp = false;
            SetCardSprite(cardName, backName, spriteLIndex);
        }
        else{
            faceUp = true;
            SetCardSprite(cardName, backName, spriteLIndex);
        }
    }
    
    //
    public void MoveCard (Vector2 loc)
    {
        motion.SetTarget(loc);
    }

    //
    public void MoveCardToHand (Vector2 loc)
    {
        motion.SetHandLocation(loc);
    }
}
