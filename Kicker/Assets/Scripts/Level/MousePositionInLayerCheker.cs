using UnityEngine;

public static class MousePositionInLayerCheker
{
    public static bool CheckMousePosition(string[] layerNames)
    {
        for (int i = 0; i < layerNames.Length; i++)
        {
            if (LaunchRaycast(layerNames[i]) == true)
            {
                return true;
            }
        }
        return false;
    }

    private static bool LaunchRaycast(string layerName)
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 10f, LayerMask.GetMask(layerName));
    }
}
