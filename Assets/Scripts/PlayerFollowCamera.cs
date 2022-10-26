using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    
    [SerializeField] Transform player;
    [SerializeField] float smoothing;

    public Vector2 maxPosition;
    public Vector2 minPosition;
    public Vector2 aspectRatio;

    void LateUpdate()
    {
        if (transform.position != player.transform.position)
        {
            Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
