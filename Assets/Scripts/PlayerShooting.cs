using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public float shootPower;
    
    [SerializeField] GameObject bulletPrefab;

    GameObject gameController;
    InputManager inputManager;
    PlayerMovement player;
    
    void Start() {
        gameController = GameObject.Find("Game Controller");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        inputManager = gameController.GetComponent<InputManager>();
    }

    void Update() {
        if (Input.GetKeyDown(inputManager.interactKey))
        {
            Shoot();
        }
    }

    private void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();

        bulletBody.AddRelativeForce(Vector2.right * shootPower * player.direction);
    }

}
