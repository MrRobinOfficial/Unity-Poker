// Copyright (c) 2018 Maxim Tiourin
// Please direct any bug reports/feedback to maximtiourin@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizzik {
    /*
     * Author - Maxim Tiourin (maximtiourin@gmail.com)
     *
     * The Follow Target Component moves an object towards a target through linear interpolation. Allows for snapping the object position to the target when within a certain distance.
     */
    public class FollowTargetComponent : MonoBehaviour {
        public GameObject target;
        
        public float followSpeed = 8f; //How quickly the object moves towards target
        public bool snapEnable = true; //Whether or not snapping is enabled.
        public float snapDistance = .1f; //How close the object needs to be near target before snapping into place on the target

        //Whether or not to lock the object's position changes along the given axis
        public bool posLockX;
        public bool posLockY;
        public bool posLockZ;

        void Update() {
            if (target != null) {
                Vector3 maskedTargetPosition = VectorWithAxisMask(transform.position, target.transform.position);

                //Move towards target position
                if (Vector3.SqrMagnitude(maskedTargetPosition - transform.position) < snapDistance * snapDistance) {
                    //Snap if within snapping distance
                    transform.position = VectorWithAxisMask(transform.position, target.transform.position);
                }
                else {
                    //Move towards target
                    transform.position = Vector3.Lerp(transform.position, maskedTargetPosition, Time.deltaTime * followSpeed);
                }
            }
        }

        private Vector3 VectorWithAxisMask(Vector3 defaultVector, Vector3 target) {
            Vector3 res = defaultVector;

            if (!posLockX) {
                res.x = target.x;
            }
            if (!posLockY) {
                res.y = target.y;
            }
            if (!posLockZ) {
                res.z = target.z;
            }

            return res;
        }
    }
}
