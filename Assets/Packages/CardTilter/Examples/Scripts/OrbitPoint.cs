// Copyright (c) 2018 Maxim Tiourin
// Please direct any bug reports/feedback to maximtiourin@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizzik {
    /*
     * Author - Maxim Tiourin (maximtiourin@gmail.com)
     *
     * Orbits a point in the XY plane for use with demonstrating a follow target for the CardTilter
     */
    public class OrbitPoint : MonoBehaviour {
        public Vector3 orbitPoint = new Vector3(0f, 0f, 0f);
        public float orbitDistance = 30f;
        public float orbitSpeed = 4f;

        private float theta;

        void Update() {
            transform.position = orbitPoint + new Vector3(orbitDistance * Mathf.Cos(theta), orbitDistance * Mathf.Sin(theta), 0f);

            theta += Time.deltaTime * orbitSpeed;
        }
    }
}
