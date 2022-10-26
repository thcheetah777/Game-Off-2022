using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogueObject : ScriptableObject
{

    [TextArea]
    public string[] sentences;
    public AudioClip[] overrideDialogueSounds;

}
