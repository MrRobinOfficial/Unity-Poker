using ImGuiNET;
using imnodesNET;
using UImGui;
using UnityEngine;

namespace UnityPoker
{
    public class MyShowDemoWindow : MonoBehaviour
    {
        private void OnEnable() => UImGuiUtility.Layout += OnLayout;

        private void OnDisable() => UImGuiUtility.Layout -= OnLayout;

        private void OnLayout(UImGui.UImGui uImGui)
        {
            ImGui.ShowDemoWindow();
        }
    }
}

