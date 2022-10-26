using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{

    [SerializeField] GameObject talkIcon;
    [SerializeField] DialogueObject dialogueObject;

    private bool onNpc = false;
    
    GameObject gameController;
    DialogueManager dialogueManager;

    void Start() {
        gameController = GameObject.Find("Game Controller");
        dialogueManager = gameController.GetComponent<DialogueManager>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.C) && onNpc)
        {
            StartCoroutine(dialogueManager.PlayDialogue(dialogueObject));
            if (talkIcon != null) { talkIcon.SetActive(false); }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (talkIcon != null) { talkIcon.SetActive(true); }
        onNpc = true;
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (talkIcon != null) { talkIcon.SetActive(false); }
        onNpc = false;
    }
}
