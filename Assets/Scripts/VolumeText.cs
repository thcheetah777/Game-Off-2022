using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeText : MonoBehaviour
{

    public float volume = 100;

    [SerializeField] TMP_Text text;

    public void MoreVolume() {
        volume += 10;
        UpdateText();
    }

    public void LessVolume() {
        volume -= 10;
        UpdateText();
    }

    private void UpdateText() {
        volume = Mathf.Repeat(volume, 110);
        text.text = volume + "%";
    }

}
