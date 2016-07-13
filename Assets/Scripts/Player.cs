using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {

    public Hand hand = new Hand();
    public Deck deck = new Deck();
	public Text errorMessage;
    public string deckPath = "";
    public string deckName = "52Deck";
    public int deckInd = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine ("LoadDeck");
	}
	//If the file is accessible, load the deck, if not try again later
	IEnumerator LoadDeck (){
		while (!deck.LoadDeck (deckPath))
			yield return new WaitForSeconds (0.5f);
	}

    //Check if the player can draw, then add card to hand and remove it from the deck
    public void DrawCard()
    {
		if (CanDraw ()) {
			Card c = deck.DrawCard ();
			if (c != null)
				hand.InsertCard (c, 0);
			else
				Debug.Log ("Cannot Find Card at index 0");
		}
	}

    //Determine if the player has room in their hand and has cards left in their deck
    //If not, update the error message text and play fade animation
	bool CanDraw () {
		if (!deck.CanDraw ()) {
			errorMessage.text = "Out of Cards in Deck";
			errorMessage.gameObject.GetComponent<Animator> ().SetTrigger ("Fade");
			return false;
		}
		if (!hand.CanDraw ()) {
			errorMessage.text = "Too Many Cards in Hand";
			errorMessage.gameObject.GetComponent<Animator> ().SetTrigger ("Fade");
			return false;
		}
		else
			return true;
	}
}
