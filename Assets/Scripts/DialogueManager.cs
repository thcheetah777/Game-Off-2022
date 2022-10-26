using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    private AudioSource dialogueAudioSource;

    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] float typeSpeed;
    [SerializeField] AudioClip defaultDialogueSound;

    bool isTalking = false;
    bool isTyping = false;

    PlayerMovement playerMovement;
    GameObject player;
    
    void Start() {
        dialogueAudioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    public IEnumerator PlayDialogue(DialogueObject dialogueData) {
        if (isTalking) { yield break; }
        ToggleIsTalking();
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        for (int i = 0; i < dialogueData.sentences.Length; i++)
        {
            if (dialogueData.overrideDialogueSounds.Length > 0)
            {
                StartCoroutine(TypewriteText(dialogueData.sentences[i], dialogueText, dialogueData.overrideDialogueSounds));
            } else
            {
                StartCoroutine(TypewriteText(dialogueData.sentences[i], dialogueText, new AudioClip[] {defaultDialogueSound}));
            }
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.C) && !isTyping);
            ResetDialogueText();
        }
        ToggleIsTalking();
    }

    private void ToggleIsTalking() {
        playerMovement.canRun = !playerMovement.canRun;
        playerMovement.canJump = !playerMovement.canJump;
        isTalking = !isTalking;
        dialoguePanel.SetActive(!dialoguePanel.activeSelf);
    }

    private IEnumerator TypewriteText(string text, TMP_Text textToChange, AudioClip[] dialogueSounds) {
        isTyping = true;
        for (int i = 0; i < text.Length; i++)
        {
            dialogueAudioSource.PlayOneShot(dialogueSounds[Random.Range(0, dialogueSounds.Length)]);
            textToChange.text = textToChange.text + text[i].ToString();
            yield return new WaitForSeconds(typeSpeed / 100);
        }
        isTyping = false;
    }

    private void ResetDialogueText() {
        dialogueText.text = "";
    }
}
