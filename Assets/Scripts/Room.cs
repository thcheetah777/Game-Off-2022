using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Room : MonoBehaviour
{
    
    private PlayerFollowCamera cam;
    private BoxCollider2D roomCollider;
    public float playerMoveAmount;

    SpriteRenderer mapRenderer;
    
    void Start()
    {
        cam = Camera.main.GetComponent<PlayerFollowCamera>();
        roomCollider = GetComponent<BoxCollider2D>();
        mapRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player")
        {
            Vector2 cameraSize = new Vector2(2 * Camera.main.orthographicSize * Camera.main.aspect, 2 * Camera.main.orthographicSize);

            cam.minPosition = new Vector2(roomCollider.bounds.min.x + cameraSize.x / 2, roomCollider.bounds.min.y + cameraSize.y / 2);
            cam.maxPosition = new Vector2(roomCollider.bounds.max.x - cameraSize.x / 2, roomCollider.bounds.max.y - cameraSize.y / 2);

            // Checking if room is smaller than camera
            if (roomCollider.transform.localScale.y < cameraSize.y)
            {
                cam.minPosition.y = roomCollider.bounds.center.y;
                cam.maxPosition.y = roomCollider.bounds.center.y;
            }
            if (roomCollider.transform.localScale.x < cameraSize.x)
            {
                cam.minPosition.x = roomCollider.bounds.center.x;
                cam.maxPosition.x = roomCollider.bounds.center.x;
            }

            // Move player into the room more so it doesn't cause problems
            Rigidbody2D playerBody = collider.gameObject.GetComponent<Rigidbody2D>();
            if (playerBody.velocity.x < 0)
            {
                playerBody.MovePosition(new Vector2(playerBody.position.x + -playerMoveAmount, playerBody.position.y));
            } else
            {
                playerBody.MovePosition(new Vector2(playerBody.position.x + playerMoveAmount, playerBody.position.y));
            }

            // Show room on map
            mapRenderer.enabled = true;
        }
    }

    public void SetRoomSizeToCamera() {
        transform.localScale = new Vector2(2 * Camera.main.orthographicSize * Camera.main.aspect, 2 * Camera.main.orthographicSize);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
