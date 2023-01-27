using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingNPC: MonoBehaviour {
    private Vector3 spawnPosition;
    private float nextTurnTime = 0f;

    void Start() {
        spawnPosition = transform.position;
        SetNewDirection();
    }

    void Update() {
        // Move forward
        transform.position += transform.forward * Time.deltaTime * 2f;
    
        // If we have walked into the water, turn around
        if (transform.position.y <= 99.5) {
            Debug.Log("Dwarf fell into the water, respawning");
            transform.position = spawnPosition;
        }

        if (Time.timeSinceLevelLoad > nextTurnTime) {
            SetNewDirection();
        }
    }

    private void SetNewDirection() {
        nextTurnTime = Time.timeSinceLevelLoad + Random.Range(0.5f, 5f);
        transform.Rotate(0f, Random.Range(0f, 360f), 0f);
    }
}
