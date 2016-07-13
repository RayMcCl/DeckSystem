using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneManager : MonoBehaviour {

    public Text usernameEntryField;
    public Text usernameDisplayField;
	public Button loginButton;
	public GameManager gM;
	public Player player;

    //
    public void ButtonPressed ()
    {
        //Update Username Field and Display
        usernameDisplayField.text = "Now Playing as " + usernameEntryField.text;
		usernameDisplayField.gameObject.SetActive(true);
		usernameEntryField.transform.parent.gameObject.SetActive(false);
		loginButton.gameObject.SetActive(false);
		gM.enabled = true;
		player.enabled = true;
	}
}
