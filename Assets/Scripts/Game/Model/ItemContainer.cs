using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour {

    public static int itemsCollected = 0;

    public int itemCount = 1;
    public string foundText = "You scored an item!";
    public string emptyText = "Bupkis";
    public AudioClip emptyClip;

    private string messageText;
    private AudioSource audioSource;
    private bool showGUI = false;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        messageText = foundText;
        tag = "Item";
	}

    private void OnMouseDown() {
        if (0 < itemCount) {
            --itemCount;
            ++itemsCollected;
        }
        else {
            audioSource.clip = emptyClip;
            messageText = emptyText;
        }

        audioSource.Play();
        StartCoroutine(GUIMessageTimer());
    }

    private IEnumerator GUIMessageTimer() {
        showGUI = true;
        yield return new WaitForSeconds(3);
        showGUI = false;
    }

    public void OnGUI() {
        if (!showGUI) return;

        GUI.skin.GetStyle("Label").fontSize = 15;
        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 50, 150, 25), messageText);
    }
}
