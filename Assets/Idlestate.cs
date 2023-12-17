using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idlestate : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(enemyTransform.position, enemy.player.position) <= 4)
            animator.SetBool("MonsterRun", true);

        if (enemy.atkDelay <= 0)
        animator.SetTrigger("MonsterAttack");
        
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
