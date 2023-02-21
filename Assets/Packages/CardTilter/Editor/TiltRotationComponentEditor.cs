// Copyright (c) 2018 Maxim Tiourin
// Please direct any bug reports/feedback to maximtiourin@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Fizzik {
    [CustomEditor(typeof(TiltRotationComponent))]
    public class TiltRotationComponentEditor : Editor {
        public override void OnInspectorGUI() {
            TiltRotationComponent ct = (TiltRotationComponent) target;

            ct.faceUpDirection = EditorGUILayout.Vector3Field(new GUIContent("Face Up Direction", "What the \"Face Up\" direction for the object is. If the object were a playing card facing the viewer, the face up direction would be a normal vector going from the surface of the card towards the viewer."), ct.faceUpDirection).normalized;

            ct.rotationSpeed = EditorGUILayout.FloatField(new GUIContent("Tilt Speed", "How quickly the object begins tilting towards a direction once it starts moving."), ct.rotationSpeed);

            ct.rotationVelocityDamping = EditorGUILayout.FloatField(new GUIContent("Tilt Damping", "How much of a damping effect to apply towards tilt when moving. Values lower than 1.00 will reduce the amount of tilt at higher speeds. Values greater than 1.00 will increase the amount of tilt at higher speeds."), ct.rotationVelocityDamping);
     
            ct.rotationResetCutoff = EditorGUILayout.FloatField(new GUIContent("Tilt Reset Speed Cutoff", "What magnitude of velocity (or speed) the object should drop below to begin resetting its rotation to its 'Face Up Direction'."), ct.rotationResetCutoff);
            ct.rotationResetSpeed = EditorGUILayout.FloatField(new GUIContent("Tilt Reset Speed", "How quickly the object resets its rotation to the 'Face Up Direction' when no longer moving."), ct.rotationResetSpeed);

            if (GUI.changed) EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
