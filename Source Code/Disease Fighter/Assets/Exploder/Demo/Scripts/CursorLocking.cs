using UnityEngine;

public class CursorLocking : MonoBehaviour
{
    public static bool IsLocked;

    void Update()
    {
        IsLocked = Screen.lockCursor;

        if (Input.GetMouseButtonDown(0))
        {
            Screen.lockCursor = true;
            // Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.lockCursor = false;
            Cursor.visible = true;
        }

        if (Screen.lockCursor == false)
        {
            Cursor.visible = true;
        }
    }
}
