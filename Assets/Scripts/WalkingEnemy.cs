using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class WalkingEnemy : MonoBehaviour
{

    public int direction = 1;
    public float speed = 2;
    public float moveRange = 5;

    private float endPos;
    private float startPos;

    Enemy enemy;

    void Start() {
        enemy = GetComponent<Enemy>();
        endPos = transform.position.x + moveRange;
        startPos = transform.position.x;
    }

    void Update() {
        enemy.enemyBody.velocity = Vector2.right * direction * speed;
        CheckFlip();
    }

    private void Flip(int newDirection) {
        direction = newDirection;
        transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, direction > 0 ? 0 : 180, transform.eulerAngles.z);
    }

    private void CheckFlip() {
        if (startPos > endPos)
        {
            if (transform.position.x <= endPos) Flip(1);
            if (transform.position.x >= startPos) Flip(-1);
        } else
        {
            if (transform.position.x <= startPos) Flip(1);
            if (transform.position.x >= endPos) Flip(-1);
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        if (Application.isPlaying)
        {
            Gizmos.DrawLine(new Vector2(startPos, transform.position.y), new Vector2(endPos, transform.position.y));   
        } else
        {
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + moveRange, transform.position.y));
        }
    }

}
