using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Testing : MonoBehaviour {    
    
    [SerializeField] private PathfindingVisual pathfindingVisual;
    [SerializeField] private CharacterPathfindingMovementHandler characterPathfinding;
    
    private Pathfinding pathfinding;
    List<int> xaxis = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 4, 6, 8, 13, 18, 19, 0, 1, 2, 4, 8, 10, 11, 12, 13, 15, 16, 18, 19, 0, 4, 6, 7, 8, 13, 15, 19, 0, 2, 4, 6, 8, 10, 11, 13, 15, 16, 17, 19, 0, 2, 4, 6, 8, 10, 16, 19, 0, 2, 4, 6, 8, 10, 12, 13, 14, 16, 18, 19, 0, 2, 3, 4, 6, 10, 14, 16, 18, 19, 0, 6, 8, 10, 11, 12, 13, 14, 16, 19, 0, 2, 4, 5, 6, 8, 16, 17, 19, 0, 2, 4, 6, 8, 9, 10, 12, 13, 14, 16, 19, 0, 2, 3, 4, 6, 8, 12, 16, 18, 19, 0, 2, 4, 8, 10, 11, 12, 13, 14, 16, 18, 19, 0, 2, 4, 6, 8, 10, 16, 19, 0, 2, 4, 6, 10, 12, 13, 14, 15, 16, 17, 19, 0, 2, 4, 6, 8, 10, 14, 16, 17, 19, 0, 4, 6, 8, 10, 11, 12, 13, 14, 16, 19, 0, 2, 4, 6, 8, 14, 16, 18, 19, 0, 2, 8, 10, 12, 16, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17};
    List<int> yaxis = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7,7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19 };

    private void Start() {
        pathfinding = new Pathfinding(20, 20);
        
        pathfindingVisual.SetGrid(pathfinding.GetGrid());        

        for(int i = 0; i < xaxis.Count; i++)
        {
            int x1 = xaxis[i];
            int y1 = yaxis[i];
            pathfinding.GetNode(x1, y1).SetIsWalkable(!pathfinding.GetNode(x1, y1).isWalkable);
        }
    }
    
    private void Update() {
        /*
        if (Input.GetMouseButtonDown(0)) {
            print("Set Target");
            
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null) {
                for (int i=0; i<path.Count - 1; i++) {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i+1].x, path[i+1].y) * 10f + Vector3.one * 5f, Color.green, 5f);
                }
            }
            characterPathfinding.SetTargetPosition(mouseWorldPosition);
            
        }*/
    

        /*

        if (Input.GetMouseButtonDown(1)) {
            
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
            
        }
        */
    }

}
