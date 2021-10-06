using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
public Rigidbody2D rig;
public bool lunching;
    //awakes the kinematic body
    private void Awake()
    {
        rig.isKinematic = true;
    }
    void Start()
    {
        
    }
    // Update is called once per frame
 
    void Update()
    {   
        if (lunching == true && rig.IsSleeping())   //when the player stops moving
        {
            GameManager.instance.PlayerFinished();
            Destroy(gameObject);           //destroy the game object
        }
    }

    public void Lunch(Vector2 direction)
    {
        rig.isKinematic = false;
        rig.AddForce(direction * 5, ForceMode2D.Impulse);
        lunching = true;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("you hit the enemy");
        }
    }
}
