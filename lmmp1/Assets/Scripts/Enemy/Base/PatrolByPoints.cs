using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolByPoints : MonoBehaviour
{

    
    public Transform leftPoint;
    public Transform rightPoint;
    private Enemy enemy;
    public Vector2 MoveDirection;
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
        if(Vector2.Distance(transform.position, leftPoint.position) < 0.1f){
            FindTargetPos();
        }
        enemy.MoveEnemy(MoveDirection);

    }
    public void FindTargetPos()
    {
        if(Vector2.Distance(transform.position, leftPoint.position) > Vector2.Distance(transform.position, rightPoint.position))
        {
            MoveDirection = (leftPoint.position - enemy.transform.position).normalized;

        }
        else
        {
            MoveDirection = (rightPoint.position - enemy.transform.position).normalized;
        }
    }

}
