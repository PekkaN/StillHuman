using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Follow_player : MonoBehaviour
{

    [SerializeField]    
    GameObject player;

     [SerializeField]   
    Vector2 posOffset;

    [SerializeField]
    float timeOfset;

    public bool faceLeft;

    bool isCrouching;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        faceLeft = player.GetComponent<PlayerController_2d>().faceLeft;
        isCrouching = player.GetComponent<PlayerController_2d>().isCrouching;
        //Cameras start position
        Vector3 startPos = transform.position;

    //player current position
    
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

    if (faceLeft){
        endPos.x += posOffset.x*-2;

}

    if (isCrouching){
        endPos.y += -2;
    }
        //this is how you lerp kuulemma
        //transform.position = Vector3.Lerp(startPos,endPos,timeOfset * Time.deltaTime);

        //this is how you use smooth dampening
        transform.position = Vector3.SmoothDamp(startPos,endPos, ref velocity, timeOfset);


        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);



    }
}
