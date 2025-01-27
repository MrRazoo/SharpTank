using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolPath : MonoBehaviour
{
    public List<Transform> patrolPoints = new List<Transform>(); // store positions Count starts from 1 and index like elements from 0.
    public int Length { get => patrolPoints.Count; }
    

    public struct PathPoint // Now our each points have its index and own position.
    {
        public int Index;
        public Vector2 Position;
    }

    public PathPoint GetClosestPatrolPoint(Vector2 tankPosition) // put the tank position and get the nearest point 
    {
        var minDistance = float.MaxValue;
        var index = -1 ;
        for(int i = 0 ; i < patrolPoints.Count ; i++)
        {
            var tempDistance = Vector2.Distance(tankPosition, patrolPoints[i].position);
            if(tempDistance < minDistance)
            {
                minDistance = tempDistance;
                index = i;
            }
            
        }
        return new PathPoint {Index = index, Position = patrolPoints[index].position };
    }

    public PathPoint GetNextIndex(int index) // put current index and get the Next Point.
    {
        var newIndex = index+1 >= patrolPoints.Count ? 0 : index + 1;
        return new PathPoint{Index = newIndex, Position = patrolPoints[newIndex].position};
    }
    
    [Header("Giamos parameters")]
    public Color pointsColor = Color.blue;
    public float pointSize = 0.5f;
    public Color lineColor = Color.red;
    
    private void OnDrawGizmos()
    {
        if(patrolPoints.Count == 0) // if List is empty.
        return;

        for(int i = patrolPoints.Count-1 ; i>=0 ; i--) // Count 4 ... i => 3 OK 
        {
            if(i == -1 || patrolPoints[i] == null) 
            return;

            Gizmos.color = pointsColor;
            Gizmos.DrawSphere(patrolPoints[i].position, pointSize); // i3

            if(patrolPoints.Count == 1 || i == 0)
            return;

            Gizmos.color = lineColor;
            Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i-1].position); // i3-i2

            if(patrolPoints.Count > 2 && i == patrolPoints.Count-1) //4 3
            {
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[0].position); // i3-i0
            }

        }
    }
}
