using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHit : MonoBehaviour
{
    private int count = 0;
    private float lastTime;
    private bool hittable;
    private bool canTrigger = true;
    private float triggerCooldown = 1f;
    private float lastTriggerTime;

    void OnTriggerEnter(Collider obj)
    {
        if (canTrigger && (obj.gameObject.tag == "Enemy_LeftHand" || obj.gameObject.tag == "Enemy_RightHand"))
        {
            TutorialManager.GetInstance().IncrementCounter();
            canTrigger = false;
            lastTriggerTime = Time.time;
            StartCoroutine(ResetTriggerCooldown());
        }
    }

    private IEnumerator ResetTriggerCooldown()
    {
        yield return new WaitForSeconds(triggerCooldown);
        canTrigger = true;
    }

}
