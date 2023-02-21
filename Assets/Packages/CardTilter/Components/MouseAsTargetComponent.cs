// Copyright (c) 2018 Maxim Tiourin
// Please direct any bug reports/feedback to maximtiourin@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizzik {
    /*
     * Author - Maxim Tiourin (maximtiourin@gmail.com)
     *
     * The Mouse As Target Component moves an object to the position of the mouse cursor along its unlocked axes, taking in to account a target camera's projection mode.
     */
    public class MouseAsTargetComponent : MonoBehaviour {
        public Camera targetCamera; //Which camera should the mouse position be calculated from

        //Whether or not to lock the object's position changes along the given axis. Any locked axes are used for raycasting from the camera to determine mouse position in perspective view.
        public bool posLockX;
        public bool posLockY;
        public bool posLockZ;

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }

        // Update is called once per frame
        void Update() {
            Vector3 mousePosition = Input.mousePosition;

            bool orthographic = targetCamera.orthographic;

            Vector3 target = transform.position;

            if (orthographic) {
                //Orthographic camera, simply find world position and use axis lock mask
                target = targetCamera.ScreenToWorldPoint(mousePosition);
            }
            else {
                //Perspective camera, need to use the defined raycastPlane to determine where the mouse is
                float distanceToCamera = VectorWithNegatedAxisMask(Vector3.zero, transform.position - targetCamera.transform.position).magnitude;

                target = targetCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distanceToCamera));
            }

            transform.position = VectorWithAxisMask(transform.position, target);
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

        private Vector3 VectorWithNegatedAxisMask(Vector3 defaultVector, Vector3 target) {
            Vector3 res = defaultVector;

            if (posLockX) {
                res.x = target.x;
            }
            if (posLockY) {
                res.y = target.y;
            }
            if (posLockZ) {
                res.z = target.z;
            }

            return res;
        }
    }
}
