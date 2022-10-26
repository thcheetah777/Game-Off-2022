using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public bool mapOpen = false;
    public float panSpeed;

    [SerializeField] GameObject map;
    [SerializeField] GameObject mapCamera;

    GameObject gameController;
    InputManager inputManager;
    PlayerMovement player;

    void Start() {
        gameController = GameObject.Find("Game Controller");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        inputManager = gameController.GetComponent<InputManager>();
    }

    void Update() {
        if (Input.GetKeyUp(inputManager.mapKey))
        {
            ToggleMapVisibility();
        }
        if (mapOpen)
        {
            if (Input.GetKey(inputManager.moveRightKey)) {
                mapCamera.transform.position += Vector3.right * panSpeed;
            }
            if (Input.GetKey(inputManager.moveLeftKey)) {
                mapCamera.transform.position += Vector3.left * panSpeed;
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                mapCamera.transform.position += Vector3.up * panSpeed;
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                mapCamera.transform.position += Vector3.down * panSpeed;
            }
        }
    }

    private void ToggleMapVisibility() {
        mapOpen = !mapOpen;
        map.SetActive(mapOpen);
        Time.timeScale = mapOpen ? 0 : 1;
        player.canRun = !mapOpen;
        player.canJump = !mapOpen;
    }

}
