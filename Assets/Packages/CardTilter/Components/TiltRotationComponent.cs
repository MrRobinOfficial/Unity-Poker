// Copyright (c) 2018 Maxim Tiourin
// Please direct any bug reports/feedback to maximtiourin@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizzik {
    /*
     * Author - Maxim Tiourin (maximtiourin@gmail.com)
     *
     * The Tilt Rotation Component tilts an object towards its direction of movement, creating a rotational effect similar to that of "Hearthstone" cards when being dragged.
     * Any faceUpDirection can be used, allowing for tilting along any axis as desired.
     */
    public class TiltRotationComponent : MonoBehaviour {
        public Vector3 faceUpDirection = new Vector3(0f, 0f, -1f); //What the faceUp direction for the object is, used in determining rotation based on movement.
        public float rotationSpeed = 10f; //How quickly the object begins tilting upon starting to move.
        public float rotationVelocityDamping = .3f; //How much of a damping effect to apply on the maximum angle of rotation when moving at greater speeds.
        public float rotationResetCutoff = .1f; //What magnitude of velocity the object should drop below to begin resetting its rotation. 
        public float rotationResetSpeed = 20f; //How quickly the object resets its rotation to the faceUpDirection when not moving.

        private bool setPrevPos; //Whether or not the previous position has been initialized
        private Vector3 prevPos; //The previous position of the object
        private Vector3 velocity; //The current velocity of the object
        
        void Update() {
            if (!setPrevPos) {
                prevPos = transform.position;
                setPrevPos = true;
            }

            velocity = transform.position - prevPos;

            if (velocity.magnitude < rotationResetCutoff) {
                transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.FromToRotation(Vector3.zero, faceUpDirection), Time.deltaTime * rotationResetSpeed);
            }
            else {
                transform.localRotation = Quaternion.Slerp(
                        transform.localRotation,
                        Quaternion.FromToRotation(faceUpDirection, faceUpDirection + new Vector3(velocity.x * rotationVelocityDamping, velocity.y * rotationVelocityDamping, velocity.z * rotationVelocityDamping)),
                        Time.deltaTime * rotationSpeed
                    );
            }

            prevPos = transform.position;
        }
    }
}
