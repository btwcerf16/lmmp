using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker // ÏĞÅÂĞÀÒÈ İÒÎ ÊÀËÈÙÅ ÅÁÀÍÍÎÅ Â ÀÁÑÒĞÀÊÒÍÛÉ ÊËÀÑÑ, À ÒÎ ß ÇÀÅÁÓÑÜ ÊÀÆÄÛÉ ĞÀÇ ÃÈÇÌÎÑ ÏĞÎÏÈÑÛÂÀÒÜ ÎÒÄÅËÜÍÎ 
{
    
    [SerializeField] public LayerMask enemyLayer { get; set; }
    [SerializeField] public Transform attack1point { get; set; }
    [SerializeField] public float attackArea { get; set; }

  
    [SerializeField] public ActorStats actorStats { get; set; }
    void Attack();

}
