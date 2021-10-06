using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour
{
    public Player player;
    public float offset = 2.0f;
    // Start is called before the first frame update
    public static camerafollow instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }
    public void SetPlayer(Player newPlayer)
    {
        player = newPlayer;
        Vector3 newpos = player.transform.position;

        newpos.z = -10;
        transform.position = newpos;
    }

    private void FixedUpdate()
    {
        if (player.lunching == true && player.transform.position.x >=
            transform.position.x - offset)
        {
         //   transform.position = new Vector3(player.transform.position.x,
            //    player.transform.position.y, -10);

                transform.position = Vector3.Lerp(transform.position,
                new Vector3(player.transform.position.x + offset, player.transform.position.y, -10),
                Time.deltaTime * 10);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}


