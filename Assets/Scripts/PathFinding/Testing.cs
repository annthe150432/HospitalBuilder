using Assets.Scripts.PathFinding;
using Assets.Scripts.PathFinding.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
   /* [SerializeField]
    private CharacterPathfindingMovementHandler characterPathfinding;*/
    private PathFinding pathFinding;
    List<PathNode> unwalkable;
    void Start()
    {
        pathFinding = new PathFinding(26, 15);
        unwalkable = new List<PathNode>();
        SetUnwalkableList(unwalkable);
    }

    // this code id stupid because I haven't thought of another way yet... :<
    void SetUnwalkableList(List<PathNode> unwalkable)
    {
        // first room at the bottom (from left to right)
        for (int i = 0; i <= 6; i++)
        {
            unwalkable.Add(pathFinding.GetNode(i, 4));
            unwalkable.Add(pathFinding.GetNode(i, 5));
        }
        unwalkable.Add(pathFinding.GetNode(6, 1));
        unwalkable.Add(pathFinding.GetNode(6, 0));

        // second and third rooms at the bottom
        for (int i = 12; i <= 22; i++)
        {
            unwalkable.Add(pathFinding.GetNode(i, 4));
            unwalkable.Add(pathFinding.GetNode(i, 5));
        }
        unwalkable.Add(pathFinding.GetNode(25, 4));
        unwalkable.Add(pathFinding.GetNode(25, 5));
        unwalkable.Add(pathFinding.GetNode(12, 3));
        unwalkable.Add(pathFinding.GetNode(12, 0));
        for (int i = 0; i <= 3; i++)
        {
            unwalkable.Add(pathFinding.GetNode(19, i));
        }

        // first room on top
        for (int i = 8; i <= 14; i++)
        {
            unwalkable.Add(pathFinding.GetNode(13, i));
        }
        for (int i = 15; i <= 19; i++)
        {
            unwalkable.Add(pathFinding.GetNode(i, 8));
            unwalkable.Add(pathFinding.GetNode(i, 9));
        }
        for (int i = 8; i <= 14; i++)
        {
            unwalkable.Add(pathFinding.GetNode(19, i));
        }

        // second room on top
        for(int i = 21; i <= 25; i++)
        {
            unwalkable.Add(pathFinding.GetNode(i, 8));
            unwalkable.Add(pathFinding.GetNode(i, 9));
        }
        foreach (PathNode node in unwalkable)
        {
            node.SetIsWalkable(false);
        }
        return;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            Debug.Log(x + ", " + y);
            List<PathNode> path = pathFinding.FindPath(0,0,x,y);
            if (path != null)
            {
                if (path != null)
                {
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 1f + Vector3.one * 0.5f, new Vector3(path[i + 1].x, path[i + 1].y) * 1f + Vector3.one * 0.5f, Color.green, 0.5f);
                    }
                }
            }
            //characterPathfinding.SetTargetPosition(mouseWorldPosition);
        }*/

        /*if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathFinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            pathFinding.GetNode(x, y).SetIsWalkable(!pathFinding.GetNode(x, y).isWalkable);
        }*/

    }
}
