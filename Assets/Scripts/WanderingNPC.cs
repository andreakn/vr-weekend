using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingNPC: MonoBehaviour {
    private Vector3 lastSafePosition = Vector3.zero;
    private float nextTurnTime = 0f;
    private bool isReturningToSafeArea = false;

    void Start() {
        lastSafePosition = transform.position;
        SetNewDirection();
    }

    void Update() {
        if (isReturningToSafeArea) {
            if (Vector3.Distance(lastSafePosition, transform.position) < 0.1f) {
                Debug.Log("Dwarf returned home");
                isReturningToSafeArea = false;
                SetNewDirection();
            }
        } else {
            // Move forward
            transform.position += transform.forward * Time.deltaTime * 2f;
        
            // If we have walked into the water, turn around
            if (transform.position.y <= 99.5) {
                Debug.Log("Dwarf fell into the water, turning around");
                isReturningToSafeArea = true;
                float newY = transform.rotation.eulerAngles.y;
                transform.Rotate(0f, 180f, 0f);
            } else {
                if (Time.timeSinceLevelLoad > nextTurnTime) {
                    SetNewDirection();
                }
            }
        }
    }

    private void SetNewDirection() {
        nextTurnTime = Time.timeSinceLevelLoad + Random.Range(0.5f, 5f);

        // Rotate in a random direction
        transform.Rotate(0f, Random.Range(0f, 360f), 0f);
    }
}
