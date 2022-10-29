using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WalkingEnemy))]
[RequireComponent(typeof(Panic))]
public class Worm : MonoBehaviour
{

    Panic panic;
    WalkingEnemy walkingEnemy;

    void Start() {
        panic = GetComponent<Panic>();
        walkingEnemy = GetComponent<WalkingEnemy>();
    }

    void FixedUpdate() {
        if (panic.justSawPlayer)
        {
            StartCoroutine(SawPlayer());
        }
    }

    private IEnumerator SawPlayer() {
        int directionBefore = walkingEnemy.direction;
        walkingEnemy.direction = 0;
        yield return new WaitForSecondsRealtime(panic.stunTime);
        walkingEnemy.speed = walkingEnemy.speed * panic.speedMultipler;
        walkingEnemy.direction = directionBefore;
    }

}
