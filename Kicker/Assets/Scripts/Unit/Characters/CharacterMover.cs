using System;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject movableOject;
    private bool isCanMove = false;
    private float offsetX, offsetY;
    private Vector2 destination;

    private BoxCollider2D boxCollider2D => movableOject.GetComponent<BoxCollider2D>();

    public event Action OnFinishedMove;

    public void StartMove(Vector2 pointPosition) 
    {
        destination = pointPosition;
        isCanMove = true;
    }

    private void FixedUpdate()
    {
        if (isCanMove == true)
        {
            movableOject.transform.position = Vector2.MoveTowards(movableOject.transform.position, destination, Time.fixedDeltaTime * speed);
            ChangePositionCollider();

            if (movableOject.transform.position.x == destination.x && movableOject.transform.position.y == destination.y)
            {
                isCanMove = false;
                OnFinishedMove?.Invoke();
            }
        }
    }

    private void ChangePositionCollider()
    {
        offsetX = (movableOject.transform.position.x - destination.x) * -1;
        offsetY = (movableOject.transform.position.y - destination.y) * -1;
        boxCollider2D.offset = new Vector2(offsetX, offsetY);
    }
}
