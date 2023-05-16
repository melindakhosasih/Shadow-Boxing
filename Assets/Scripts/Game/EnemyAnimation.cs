using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        anim = GetComponent<Animator>();
        while(true) {
            yield return new WaitForSeconds(2);
            anim.SetInteger("AttackIndex", Random.Range(0, 4));
            anim.SetTrigger("Attack");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collider) {
        
    }
}
