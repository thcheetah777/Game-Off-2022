using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRoomBorder : MonoBehaviour
{

    public float padding;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(1 / transform.parent.localScale.x, 1 / transform.parent.localScale.y, 1);
        spriteRenderer.size = new Vector2(transform.parent.localScale.x - padding, transform.parent.localScale.y - padding);
    }

}
