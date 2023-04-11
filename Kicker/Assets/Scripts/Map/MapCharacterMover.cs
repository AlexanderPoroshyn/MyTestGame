using System;
using UnityEngine;

public class MapCharacterMover : MonoBehaviour
{
    private bool isMoving = false;

    private MapPointForStep pointUp, pointLeft, pointRight, pointDown;
    private bool isCanMoveUp, isCanMoveLeft, isCanMoveRight, isCanMoveDown;

    private MapPointForStep characterLocation;
    private MapPointForStep followPoint;

    public event Action OnStartedMove, OnFinishedMove;

    [SerializeField] private float speed;

    private void Update()
    {
        if (isMoving == false)
        {
            if (Input.GetKey(KeyCode.W) && isCanMoveUp)
            {
                StartFollow(characterLocation.GetDirectionUp());
            }
            if (Input.GetKey(KeyCode.A) && isCanMoveLeft)
            {
                StartFollow(characterLocation.GetDirectionLeft());
            }
            if (Input.GetKey(KeyCode.S) && isCanMoveDown)
            {
                StartFollow(characterLocation.GetDirectionDown());
            }
            if (Input.GetKey(KeyCode.D) && isCanMoveRight)
            {
                StartFollow(characterLocation.GetDirectionRight());
            }
        }
        if (isMoving == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, followPoint.transform.position, speed * Time.deltaTime);
            if (transform.position == followPoint.transform.position)
            {
                isMoving = false;
                OnFinishedMove?.Invoke();
            }
        }
    }

    private void StartFollow(MapPointForStep selectedPointForFollow)
    {
        followPoint = selectedPointForFollow;
        OnStartedMove?.Invoke();
        isMoving = true;
    }

    public void CheckAvailableDirections()
    {
        characterLocation = GetMapPoint();

        if (characterLocation != null)
        {
            if (characterLocation.GetDirectionUp() != null)
            {
                isCanMoveUp = true;
            }
            else
            {
                isCanMoveUp = false;
            }
            if (characterLocation.GetDirectionLeft() != null)
            {
                isCanMoveLeft = true;
            }
            else
            {
                isCanMoveLeft = false;
            }
            if (characterLocation.GetDirectionRight() != null)
            {
                isCanMoveRight = true;
            }
            else
            {
                isCanMoveRight = false;
            }
            if (characterLocation.GetDirectionDown() != null)
            {
                isCanMoveDown = true;
            }
            else
            {
                isCanMoveDown = false;
            }
        }
        else
        {
            isCanMoveUp = false;
            isCanMoveLeft = false;
            isCanMoveRight = false;
            isCanMoveDown = false;
        }
    }

    private MapPointForStep GetMapPoint()
    {
        MapPointForStep mapPoint = null;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 10f, LayerMask.GetMask("MapPoint"));
        if (hit == true)
        {
            mapPoint = hit.transform.gameObject.GetComponent<MapPointForStep>();
        }
        return mapPoint;
    }
}
