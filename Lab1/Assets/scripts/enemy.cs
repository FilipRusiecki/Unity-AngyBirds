using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{


    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerLauncher.instance.player == null)
        {
            return;   
        }
        if (collision.relativeVelocity.magnitude > 2 &&
            PlayerLauncher.instance.player.lunching == true)
        {
            GameManager.instance.DestroyEnemy(this);
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }




}
