using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{

    [SerializeField] GameObject talkIcon;
    [SerializeField] DialogueObject dialogueObject;

    private bool onNpc = false;
    
    GameObject gameController;
    DialogueManager dialogueManager;
    InputManager inputManager;

    void Start() {
        gameController = GameObject.Find("Game Controller");
        inputManager = gameController.GetComponent<InputManager>();
        dialogueManager = gameController.GetComponent<DialogueManager>();
    }

    void Update() {
        if (Input.GetKeyDown(inputManager.interactKey) && onNpc)
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
