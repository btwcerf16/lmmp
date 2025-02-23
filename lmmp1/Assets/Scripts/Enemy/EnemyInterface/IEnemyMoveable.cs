

using UnityEngine;

public interface IEnemyMoveable
{
    Rigidbody2D rigidbody2D { get; set; }
    bool IsFacingRight { get; set; }
    void MoveEnemy(Vector2 velocity);
    void CheckRotateOfFace(Vector2 velocity);
}
