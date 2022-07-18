using Assets.Scripts.PathFinding.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfindingMovementHandler : MonoBehaviour
{

    public float speed;

    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    public GameObject character;
    List<Vector3> destinations;
    public bool isMoving;
    Timer timer;
    private void Start()
    {
        destinations = new List<Vector3>();
        destinations = AddDestinations(destinations);
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1f;
        isMoving = true;
        HandleMovement();
        SetTargetPosition(destinations[0]);
    }

    private void Update()
    {
        HandleMovement();

        if (!isMoving && !timer.Running)
        {
            //int ran = Random.Range(1, destinations.Count);
            FuntionalObject funtionalObject = ObjectFactory.Instance.GetAvailableObject("Table");
            if (funtionalObject == null)
            {
                return;
            }
            Vector3 target = new Vector3(funtionalObject.Tile.X, funtionalObject.Tile.Y);
            SetTargetPosition(target);
            isMoving = true;
        }
        if (GetPosition().y <= 1.5 && GetPosition().x >= 8 && GetPosition().x <= 11)
        {
            Destroy(gameObject);
        }
    }

    private void HandleMovement()
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;

                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                //animatedWalker.SetMoveVector(moveDir);
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();

                    //  animatedWalker.SetMoveVector(Vector3.zero);
                }
            }
        }
        else
        {
            //animatedWalker.SetMoveVector(Vector3.zero);
        }
    }

    private void StopMoving()
    {
        pathVectorList = null;
        isMoving = false;
        timer.Run();
        print("Stop moving");
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = PathFinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }
    List<Vector3> AddDestinations(List<Vector3> destinations)
    {
        destinations.Add(new Vector3((float)4.2, 11)); // reception 
        destinations.Add(new Vector3(2, 2)); // rooms
        destinations.Add(new Vector3(22, 11));
        destinations.Add(new Vector3(16, 12));
        destinations.Add(new Vector3(17, 2));
        destinations.Add(new Vector3(24, 1));
        destinations.Add(new Vector3(9, 0));// end
        destinations.Add(new Vector3(9, 0));// end
        destinations.Add(new Vector3(9, 0));// end
        destinations.Add(new Vector3(9, 0));// end
        return destinations;
    }
}
