using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Player player;
    public float drawRate = 0.5f;
	public int turn = 0;

    void Start()
    {
        StartCoroutine("FillHand");
    }

    //Draw from deck at set rate till their starting hand size is full
    IEnumerator FillHand()
    {
        for (int x = 0; x < player.hand.GetStartHandSize(); x++)
        {
            yield return new WaitForSeconds(drawRate);
            DrawCard();
            
        }
    }

	void DrawCard (){
		player.DrawCard ();
	}

	public void NextTurn (){
		turn++;
		DrawCard ();
	}
}
