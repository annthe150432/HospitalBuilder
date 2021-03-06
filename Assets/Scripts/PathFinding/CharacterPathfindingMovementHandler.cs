using Assets.Scripts.PathFinding.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    LinkedList<string> checkin;
    private void Start()
    {
        checkin = new LinkedList<string>();
        int ran = Random.Range(1, 3);
        if (ran == 1)
        {
            checkin.AddFirst("Bed");
        }
        else
        {
            checkin.AddFirst("Blood");
        }
        checkin.AddFirst("Table");
        destinations = new List<Vector3>();
        destinations = AddDestinations(destinations);
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1.5f;
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
            //SetTargetPosition(destinations[ran]);
            if (checkin.Count == 0)
            {
                SetTargetPosition(destinations[destinations.Count-1]); // get out
            }
            string des = checkin.First();
            FuntionalObject funtionalObject = ObjectFactory.Instance.GetAvailableObject(des);
            if (funtionalObject == null)
            {
                return;
            }
            Vector3 target = new Vector3(funtionalObject.Tile.X, funtionalObject.Tile.Y);
            SetTargetPosition(target);
            checkin.RemoveFirst();
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
