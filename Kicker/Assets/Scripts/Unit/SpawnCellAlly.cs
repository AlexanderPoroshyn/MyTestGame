using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnCellAlly : MonoBehaviour, IPointerClickHandler
{
    public event Action<Vector2> OnClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isCanSpawn("Ally") == true)
        {
            OnClicked?.Invoke(transform.position);
        }
    }

    private bool isCanSpawn(string layerName)
    {
        return !Physics2D.Raycast(transform.position, Vector2.zero, 10f, LayerMask.GetMask(layerName));
    }
}
