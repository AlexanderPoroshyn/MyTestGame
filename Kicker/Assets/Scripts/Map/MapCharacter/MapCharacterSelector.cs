using System;
using UnityEngine;

public class MapCharacterSelector : MonoBehaviour
{
    private bool isSelected = false;

    private MapPointForSelect selectedMapPoint;

    public event Action OnSelected;

    private void Update()
    {
        if (isSelected == false && selectedMapPoint != null && Input.GetKey(KeyCode.Space))
        {
            OnSelected?.Invoke();
            selectedMapPoint.Activate();

            isSelected = true;
        }
    }

    public void CheckPointsForSelect()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 10f, LayerMask.GetMask("MapPointForSelect"));
        if (hit == true)
        {
            selectedMapPoint = hit.transform.gameObject.GetComponent<MapPointForSelect>();
        }
        else
        {
            selectedMapPoint = null;
        }
    }
}
