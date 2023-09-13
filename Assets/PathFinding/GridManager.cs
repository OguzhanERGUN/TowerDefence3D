using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [Tooltip("World Grid Size - Should match UnityEditor snap settings")]
    [SerializeField] int unityGridSize = 10;
    public int UnityGridSize { get { return unityGridSize; } }


    Dictionary<Vector2Int, Node> grids = new Dictionary<Vector2Int, Node>();
    public Dictionary<Vector2Int, Node> Grids { get { return grids; } }

    private void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (grids.ContainsKey(coordinates))
        {
            return grids[coordinates];
        }
        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (grids.ContainsKey(coordinates))
        {
            grids[coordinates].isWalkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / unityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / unityGridSize);

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinate(Vector2Int coordinates)
    {
        Vector3 position = new Vector3();
        position.x = coordinates.x * unityGridSize;
        position.z = coordinates.y * unityGridSize;

        return position;
    }

    private void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                grids.Add(coordinates, new Node(coordinates, true ));
                Debug.Log(grids[coordinates].coordinates + " = " + grids[coordinates].isWalkable);
            }
        }
    }
}
