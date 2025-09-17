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

        enemy.Flip();
    }
    public void MoveToPoint()
    {
        


        // BetweenTargetAndEnemy
        if(Vector2.Distance(transform.position, TargetPoint.position) < 0.1f){
            enemy.MoveEnemy(Vector2.zero);
            StartCoroutine(WaitTime(1.5f));

            enemy.animator.SetBool("Idle", true);
            enemy.animator.SetBool("Walk", false);

        }
        else
        {
            enemy.MoveEnemy(MoveDirection);
            enemy.animator.SetBool("Idle", false);
            enemy.animator.SetBool("Walk", true);
        }


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
    IEnumerator WaitTime(float waitTime)
    {


        yield return new WaitForSeconds(waitTime);
        
        FindTargetPos();
        enemy.Flip();
       
    }

}
