// Copyright (c) 2018 Maxim Tiourin
// Please direct any bug reports/feedback to maximtiourin@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Fizzik {
    [CustomEditor(typeof(FollowTargetComponent))]
    public class FollowTargetComponentEditor : Editor {
        public override void OnInspectorGUI() {
            FollowTargetComponent ct = (FollowTargetComponent) target;

            ct.target = (GameObject) EditorGUI.ObjectField(EditorGUILayout.GetControlRect(), new GUIContent("Target Object", "Which target object should this object be following?"), ct.target, typeof(GameObject), true);

            ct.followSpeed = EditorGUILayout.FloatField(new GUIContent("Follow Speed", "How quickly this object moves towards the target."), ct.followSpeed);

            ct.snapEnable = EditorGUILayout.Toggle(new GUIContent("Enable Snapping", "Whether or not snapping to the target's position when close enough is enabled."), ct.snapEnable);
            if (ct.snapEnable) {
                EditorGUI.indentLevel++;

                ct.snapDistance = EditorGUILayout.FloatField(new GUIContent("Snap Distance", "How close this object needs to be to the target before snapping into place on the target position."), ct.snapDistance);

                EditorGUI.indentLevel--;
            }

            EditorGUILayout.LabelField(new GUIContent("Lock Axis", "Locks the object's movement on the given axes when following the target."));

            EditorGUI.indentLevel++;

            ct.posLockX = EditorGUILayout.Toggle(new GUIContent("X Axis", "Lock the object's movement on the X Axis."), ct.posLockX);
            ct.posLockY = EditorGUILayout.Toggle(new GUIContent("Y Axis", "Lock the object's movement on the Y Axis."), ct.posLockY);
            ct.posLockZ = EditorGUILayout.Toggle(new GUIContent("Z Axis", "Lock the object's movement on the Z Axis."), ct.posLockZ);

            EditorGUI.indentLevel--;

            if (GUI.changed) EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
