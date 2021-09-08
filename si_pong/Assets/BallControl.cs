using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidBody2d;
    public float xInitialForce;
    public float yInitialForce;
    private Vector2 trajectoryOrigin;
    void ResetBall(){
        transform.position = Vector2.zero;
        rigidBody2d.velocity=Vector2.zero;
    }
    void PushBall(){
        float yRandomInitialForce= Random.Range(-yInitialForce,yInitialForce);
        float randomDirection= Random.Range(0,2);
        if (randomDirection<1.0f){
            rigidBody2d.AddForce(new Vector2(-xInitialForce,yRandomInitialForce));
        }else{
            rigidBody2d.AddForce(new Vector2(xInitialForce,yRandomInitialForce));
        }
    }
    void RestartGame(){
        ResetBall();
        Invoke("PushBall",2);
    }
    
    // Start is called before the first frame update
    public Vector2 TrajectoryOrigin{
        get{return trajectoryOrigin;}
    }
    private void OnCollisionExit2D(Collision2D collision){
            trajectoryOrigin=transform.position;
        }
    void Start()
    {
        trajectoryOrigin=transform.position;
        rigidBody2d=GetComponent<Rigidbody2D>();
        RestartGame();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
