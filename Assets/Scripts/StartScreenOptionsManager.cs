using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenOptionsManager : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            switch (currentOption)
            {
                case 0:
                    sceneLoader.LoadScene("World");
                    break;
                case 1:
                    sceneLoader.LoadScene("Settings");
                    break;
                case 2:
                    sceneLoader.LoadScene("Credits");
                    break;
            }
        }
    }

    private void UpdateSelection() {
        currentOption = (int)Mathf.Repeat(currentOption, options.childCount);
        selection.position = new Vector2(selection.position.x, options.GetChild(currentOption).transform.position.y);
    }

}
