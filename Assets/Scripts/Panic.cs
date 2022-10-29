using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panic : MonoBehaviour
{

    public float range = 5;
    public float speedMultipler = 2;
    public float stunTime = 1;
    public bool seenPlayer = false;
    public bool justSawPlayer = false;
    public bool seeingPlayer = false;
    public LayerMask playerLayer;

    void FixedUpdate() {
        if (Physics2D.OverlapCircle(transform.position, range, playerLayer))
        {
            seeingPlayer = true;
            if (seenPlayer != true)
            {
                justSawPlayer = true;
                seenPlayer = true;
            } else
            {
                justSawPlayer = false;
            }
        } else
        {
            seeingPlayer = false;
        }
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
