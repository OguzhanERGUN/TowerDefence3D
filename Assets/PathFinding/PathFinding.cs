using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int destinateCoordinates;

    Node startNode;
    Node destinateNode;
    Node currentSearchNode;


    Queue<Node> frontier = new Queue<Node> ();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    private List<Node> neighbors = new List<Node>();
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();



    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null)
        {
            grid = gridManager.Grids;
        }


    }
    void Start()
    {

        startNode = gridManager.Grids[startCoordinates];
        destinateNode = gridManager.Grids[destinateCoordinates];
        BreadthFirstSearch();
        BuildPath();
    }



    private void ExploreNeighbors()
    {

        for (int i = 0; i < directions.Length; i++)
        {
            Vector2Int tempNeighbor = currentSearchNode.coordinates + directions[i];
            if (gridManager.GetNode(tempNeighbor) != null)
            {
                neighbors.Add(gridManager.GetNode(tempNeighbor));
            }

            foreach (Node neighbor in neighbors)
            {
                if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
                {
                    neighbor.connectedTo = currentSearchNode;
                    reached.Add(neighbor.coordinates, neighbor);
                    frontier.Enqueue(neighbor);
                }
            }
        }

    }

    private void BreadthFirstSearch()
    {
        bool isRunning = true;

        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while (frontier.Count > 0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if (currentSearchNode.coordinates == destinateCoordinates)
            {
                isRunning = false;
            }
        }
    }

    private List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinateNode;

        path.Add(currentNode);
        currentNode.isPath = true;



        while (currentNode.connectedTo != null)
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;

        }

        path.Reverse();

        return path;
    }
}





