using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planemov : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody heli;
    private float wantedYRotation;
    private float currentYRotation;
    private float rotateAmountByKeys=2.5f;
    private float rotationYVelocity;
     private float MovementForwardSpeed=500f;
    private float tiltAmountForward=0;
    private float tiltVelocityForward;

     public float smooth = 5.0f;
    public float tiltAngle = 60.0f;

    public float speed = 100.0f;
    public float rotationSpeed = 5.0f;

    float tiltAroundX=0.0f;
    float tiltAroundZ=0.0f;
    void Awake() {
        heli=GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        MovementLand();
        RotationLand();
        MovementUpDown();
        //MovementForward();
        Rotation();

        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
         transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        
        // heli.rotation=Quaternion.Euler(
        //      new Vector3(tiltAmountForward,currentYRotation,heli.rotation.z)
        // );
    }

    public float upForce;

    void MovementUpDown(){
        if(Input.GetKey(KeyCode.I)){
            upForce=450f;
             heli.AddRelativeForce(Vector3.up*upForce);
            tiltAroundZ = tiltAngle-30;
            //tiltAmountForward=Mathf.SmoothDamp(tiltAmountForward,20,ref tiltVelocityForward,0.1f);
        }
        else if(Input.GetKey(KeyCode.K)){
            upForce=200f;
            heli.AddRelativeForce(Vector3.down*upForce);
            tiltAroundZ = (-1)* tiltAngle+30;
            //tiltAmountForward=Mathf.SmoothDamp(tiltAmountForward,20,ref tiltVelocityForward,0.1f);
        }else if(!Input.GetKey(KeyCode.I)&&!Input.GetKey(KeyCode.K)){
            upForce=0.1f;
            tiltAroundZ=0.0f;
            heli.AddRelativeForce(Vector3.down*upForce);
            
        }
    }

   
    

    void MovementLand(){
            float translation = Input.GetAxis("Vertical") * speed;
            translation *= Time.deltaTime;
            // if(Input.GetKeyDown(KeyCode.LeftShift) && Input.GetAxis("Vertical")==1){
            //      translation =100f*Time.deltaTime; 
            //      transform.Translate(translation,0,0);    
            // }
            transform.Translate(translation,0,0);
            //heli.AddRelativeForce(Vector3.forward*MovementForwardSpeed);
            //tiltAmountForward=Mathf.SmoothDamp(tiltAmountForward,20*Input.GetAxis("Vertical"),ref tiltVelocityForward,0.1f);
        
    }
    void RotationLand(){
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            rotation *= Time.deltaTime;
            transform.Rotate(0, rotation, 0);
            //heli.AddRelativeForce(Vector3.forward*MovementForwardSpeed);
            //tiltAmountForward=Mathf.SmoothDamp(tiltAmountForward,20*Input.GetAxis("Vertical"),ref tiltVelocityForward,0.1f);
        
    }

    
    void Rotation(){
        if(Input.GetKey(KeyCode.J)){
            //wantedYRotation-=rotateAmountByKeys;
            upForce=450f;
            tiltAroundX =tiltAngle;
            heli.AddRelativeForce(Vector3.left*upForce);
            heli.AddRelativeForce(Vector3.down*(upForce-100));
        }
        if(Input.GetKey(KeyCode.L)){
           // wantedYRotation+=rotateAmountByKeys;
           tiltAroundX = (-1)* tiltAngle;
            upForce=450f;
            heli.AddRelativeForce(Vector3.right*upForce);
            heli.AddRelativeForce(Vector3.down*(upForce-100));
        }else if(!Input.GetKey(KeyCode.J)&&!Input.GetKey(KeyCode.L)){
            tiltAroundX=0.0f;
             upForce=0.0f;
            heli.AddRelativeForce(Vector3.zero);
        }
        // currentYRotation=Mathf.SmoothDamp(currentYRotation,wantedYRotation,ref rotationYVelocity,0.25f);

    } 
}
