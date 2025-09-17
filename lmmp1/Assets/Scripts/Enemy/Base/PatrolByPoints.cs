using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PatrolByPoints : MonoBehaviour
{

    
    public Transform leftPoint;
    public Transform rightPoint;
    private Enemy enemy;
    public Vector2 MoveDirection;
    public Transform TargetPoint;
    //   _direction = (enemy.targetPos - enemy.transform.position).normalized;
    //c enemy.MoveEnemy(_direction* enemy.CurrentStats.speed/3 * speedBuffer)

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        FindTargetPos();
    }
    public void MoveToPoint()
    {
        
        // BetweenTargetAndEnemy
        if(Vector2.Distance(transform.position, TargetPoint.position) < 0.1f){
            FindTargetPos();
            enemy.Flip();
            Debug.Log("LJITK");
        }
        enemy.MoveEnemy(MoveDirection);

    }
    public void FindTargetPos()
    {
        if(Vector2.Distance(transform.position, leftPoint.position) > Vector2.Distance(transform.position, rightPoint.position))
        {
            MoveDirection = (leftPoint.position - transform.position).normalized;
            TargetPoint = leftPoint;
        }
        else
        {
            MoveDirection = (rightPoint.position - transform.position).normalized;
            TargetPoint = rightPoint;
        }
    }

}
