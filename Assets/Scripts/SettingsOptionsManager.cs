using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsOptionsManager : MonoBehaviour
{

    [SerializeField] Transform options;
    [SerializeField] RectTransform selection;
    public int currentOption = 0;

    SceneLoader sceneLoader;

    void Start() {
        sceneLoader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentOption++;
            UpdateSelection();
        } 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentOption--;
            UpdateSelection();
        }
        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X)) && currentOption == 2)
        {
            sceneLoader.LoadScene("Start Screen");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            options.GetChild(currentOption).GetComponent<VolumeText>().MoreVolume();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            options.GetChild(currentOption).GetComponent<VolumeText>().LessVolume();
        }
    }

    private void UpdateSelection() {
        currentOption = (int)Mathf.Repeat(currentOption, options.childCount);
        selection.position = new Vector2(selection.position.x, options.GetChild(currentOption).transform.position.y);
    }

}
