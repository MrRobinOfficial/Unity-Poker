using Inputter;
using UnityEngine;
using UnityEngine.InputSystem;

public class TruckInput : MonoBehaviour
{
    // Add reference via the editor side
    // private InputActionReference m_ShiftUpReference;

    // Or create input reference directly via the script (at Start() function)
    [SerializeField] private InputAction m_ShiftUp;
    [SerializeField] private InputAction m_ShiftDown;

    private InputAction m_ShiftFirstGear;
    private InputAction m_ShiftSecondGear;
    private InputAction m_ShiftThirdGear;
    private InputAction m_ShiftFourthGear;
    private InputAction m_ShiftFifthGear;
    private InputAction m_ShiftSixthGear;
    private InputAction m_ShiftReverseGear;

    /**
     * Gear Index:
     * 
     * -1 = R
     * 0 = N
     * 1 = 1st
     * 2 = 2nd
     * 3 = 3rd
     * 4 = 4th
     * 5 = 5th
     * 6 = 6th
     */

    private int m_GearIndex = 0; // N

    private void Start()
    {
        if (LogitechG29.current == null)
        {
            Debug.LogError("Connect Logitech G29 to this system!");
            enabled = false;
            return;
        }

        m_ShiftUp = new InputAction(name: "Shift Up", InputActionType.Button, binding: "<Keyboard>/e");

        m_ShiftDown = new InputAction(name: "Shift Down", InputActionType.Button, binding: "<Keyboard>/q");

        m_ShiftUp.AddBinding(LogitechG29.current.rightShift);
        m_ShiftDown.AddBinding(LogitechG29.current.leftShift);

        m_ShiftFirstGear = new InputAction(name: "Shift 1st Gear", InputActionType.Button);

        m_ShiftSecondGear = new InputAction(name: "Shift 2nd Gear", InputActionType.Button);

        m_ShiftThirdGear = new InputAction(name: "Shift 3rd Gear", InputActionType.Button);

        m_ShiftFourthGear = new InputAction(name: "Shift 4th Gear", InputActionType.Button);

        m_ShiftFifthGear = new InputAction(name: "Shift 5th Gear", InputActionType.Button);

        m_ShiftSixthGear = new InputAction(name: "Shift 6th Gear", InputActionType.Button);

        m_ShiftReverseGear = new InputAction(name: "Shift R Gear", InputActionType.Button);

        m_ShiftFirstGear.AddBinding(LogitechG29.current.shifter1);
        m_ShiftSecondGear.AddBinding(LogitechG29.current.shifter2);
        m_ShiftThirdGear.AddBinding(LogitechG29.current.shifter3);
        m_ShiftFourthGear.AddBinding(LogitechG29.current.shifter4);
        m_ShiftFifthGear.AddBinding(LogitechG29.current.shifter5);
        m_ShiftSixthGear.AddBinding(LogitechG29.current.shifter6);
        m_ShiftReverseGear.AddBinding(LogitechG29.current.shifter7);

        m_ShiftUp.performed += OnShiftUp;
        m_ShiftDown.performed += OnShiftDown;

        m_ShiftFirstGear.performed += OnShiftFirstGear;
        m_ShiftSecondGear.performed += OnShiftSecondGear;
        m_ShiftThirdGear.performed += OnShiftThirdGear;
        m_ShiftFourthGear.performed += OnShiftFourthGear;
        m_ShiftFifthGear.performed += OnShiftFifthGear;
        m_ShiftSixthGear.performed += OnShiftSixthGear;
        m_ShiftReverseGear.performed += OnShiftReverseGear;
    }

    private void OnDestroy()
    {
        // Remove callbacks once we don't need them anymore. Helps to get rid of memory leaks. If you don't know about memory leaks, then watch this video: https://www.youtube.com/watch?v=67m5jwoNkfo

        m_ShiftUp.performed -= OnShiftUp;
        m_ShiftDown.performed -= OnShiftDown;

        m_ShiftFirstGear.performed -= OnShiftFirstGear;
        m_ShiftSecondGear.performed -= OnShiftSecondGear;
        m_ShiftThirdGear.performed -= OnShiftThirdGear;
        m_ShiftFourthGear.performed -= OnShiftFourthGear;
        m_ShiftFifthGear.performed -= OnShiftFifthGear;
        m_ShiftSixthGear.performed -= OnShiftSixthGear;
        m_ShiftReverseGear.performed -= OnShiftReverseGear;
    }

    private void OnShiftUp(InputAction.CallbackContext ctx)
    {
        // Put some logic over here!

        ShiftToSpecificGear(m_GearIndex + 1);
    }

    private void OnShiftDown(InputAction.CallbackContext ctx)
    {
        // Put some logic over here!

        ShiftToSpecificGear(m_GearIndex - 1);
    }

    private void OnShiftReverseGear(InputAction.CallbackContext ctx) => ShiftToSpecificGear(gearIndex: -1);
    private void OnShiftFirstGear(InputAction.CallbackContext ctx) => ShiftToSpecificGear(gearIndex: 1);
    private void OnShiftSecondGear(InputAction.CallbackContext ctx) => ShiftToSpecificGear(gearIndex: 2);
    private void OnShiftThirdGear(InputAction.CallbackContext ctx) => ShiftToSpecificGear(gearIndex: 3);
    private void OnShiftFourthGear(InputAction.CallbackContext ctx) => ShiftToSpecificGear(gearIndex: 4);
    private void OnShiftFifthGear(InputAction.CallbackContext ctx) => ShiftToSpecificGear(gearIndex: 5);
    private void OnShiftSixthGear(InputAction.CallbackContext ctx) => ShiftToSpecificGear(gearIndex: 6);

    private void ShiftToSpecificGear(int gearIndex)
    {
        if (gearIndex < -1 || gearIndex > 6)
            return;

        Debug.Log(message: $"You shifted to: {gearIndex}", this);
        Debug.Log(message: $"New gear = {GetGearIndexAsString(gearLength: 6, gearIndex)}", this);

        // Shift logic
    }

    /// <summary>
    /// Helper function for getting gear index as string
    /// </summary>
    /// <param name="gearLength"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    private static string GetGearIndexAsString(int gearLength, int index)
    {
        return index == 0
                ? "N"
                : (index % (gearLength + 1)) switch
                {
                    < -1 => $"R [{GetGearIndexAsString(gearLength, Mathf.Abs(index))}]",
                    -1 => "R",
                    1 => $"{index}st",
                    2 => $"{index}nd",
                    3 => $"{index}rd",
                    _ => $"{index}th",
                };
    }
}