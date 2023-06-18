using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour{
    [SerializeField] Transform resetTransform;
    [SerializeField] GameObject player;
    [SerializeField] Camera playerHead;
    private bool isReset = false;


    // Start is called before the first frame update
    void Start()
    {
        isReset = false;
        // ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReset) {
            ResetPosition();
            isReset = true;
        }
        // OVRManager.display.RecenterPose();
    }

    // [ContextMenu("Reset Position")]
    public void ResetPosition() {
        print("reset position");
        var rotationAngleY = playerHead.transform.rotation.eulerAngles.y - resetTransform.rotation.eulerAngles.y;
        player.transform.Rotate(0, rotationAngleY, 0);

        var distanceDiff = resetTransform.position - playerHead.transform.position;
        Vector3 pos = player.transform.position + distanceDiff;
        // pos.y = 0;
        pos.y = player.transform.position.y;
        player.transform.position = pos;
    }
}
