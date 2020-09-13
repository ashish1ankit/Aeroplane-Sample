using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody heli;

    void Awake() {
        heli=GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        MovementUpDown();
        MovementForward();
        Rotation();

        heli.AddRelativeForce(Vector3.up*upForce);
        heli.rotation=Quaternion.Euler(
            new Vector3(tiltAmountForward,currentYRotation,heli.rotation.z)
        );
    }

    public float upForce;

    void MovementUpDown(){
        if(Input.GetKey(KeyCode.I)){
            upForce=450f;
        }
        else if(Input.GetKey(KeyCode.K)){
            upForce=-200f;
        }else if(!Input.GetKey(KeyCode.I)&&!Input.GetKey(KeyCode.K)){
            upForce=98.1f;
        }
    }

    private float MovementForwardSpeed=500f;
    private float tiltAmountForward=0;
    private float tiltVelocityForward;
    

    void MovementForward(){
        if(Input.GetAxis("Vertical")!=0){
            heli.AddRelativeForce(Vector3.forward*Input.GetAxis("Vertical")*MovementForwardSpeed);
            tiltAmountForward=Mathf.SmoothDamp(tiltAmountForward,20*Input.GetAxis("Vertical"),ref tiltVelocityForward,0.1f);
        }
    }

    private float wantedYRotation;
    private float currentYRotation;
    private float rotateAmountByKeys=2.5f;
    private float rotationYVelocity;
    void Rotation(){
        if(Input.GetKey(KeyCode.J)){
            wantedYRotation-=rotateAmountByKeys;
        }
        if(Input.GetKey(KeyCode.L)){
            wantedYRotation+=rotateAmountByKeys;
        }
        currentYRotation=Mathf.SmoothDamp(currentYRotation,wantedYRotation,ref rotationYVelocity,0.25f);

    } 
}
