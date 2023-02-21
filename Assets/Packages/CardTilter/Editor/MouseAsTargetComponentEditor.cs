// Copyright (c) 2018 Maxim Tiourin
// Please direct any bug reports/feedback to maximtiourin@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Fizzik {
    [CustomEditor(typeof(MouseAsTargetComponent))]
    public class MouseAsTargetComponentEditor : Editor {
        public override void OnInspectorGUI() {
            MouseAsTargetComponent ct = (MouseAsTargetComponent) target;

            ct.targetCamera = (Camera) EditorGUI.ObjectField(EditorGUILayout.GetControlRect(), new GUIContent("Target Camera", "Which camera should be used for calculating the Mouse Position."), ct.targetCamera, typeof(Camera), true);

            EditorGUILayout.LabelField(new GUIContent("Lock Axis", "Locks the object's movement on the given axes when following the mouse position, preventing it from moving on those axes. If the target camera uses perspective projection, then whichever axes are locked are used to determine the distance from camera to object when calculating mouse position. For example, if the object only moves on the XY axes, then for perspective cameras the Z axis should be locked. Orthographic cameras have no lock restrictions."));

            EditorGUI.indentLevel++;

            ct.posLockX = EditorGUILayout.Toggle(new GUIContent("X Axis", "Lock the object's movement on the X Axis."), ct.posLockX);
            ct.posLockY = EditorGUILayout.Toggle(new GUIContent("Y Axis", "Lock the object's movement on the Y Axis."), ct.posLockY);
            ct.posLockZ = EditorGUILayout.Toggle(new GUIContent("Z Axis", "Lock the object's movement on the Z Axis."), ct.posLockZ);

            EditorGUI.indentLevel--;

            if (GUI.changed) EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
