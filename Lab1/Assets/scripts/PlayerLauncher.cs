using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerStartPos;
    public Player player;
    public bool holdingPlayer;

    private Camera cam;
    public static PlayerLauncher instance;
    public void Awake()
    {
        instance = this;
    }
    bool InputDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }
    bool InputUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            return true;
        }
        return false;
    }
    void Start()
    {
        cam = Camera.main;

    }
    public void SetNewPlayer(GameObject playerPrefab)
    {
        player = Instantiate(playerPrefab, playerStartPos.position, Quaternion.identity).GetComponent<Player>();
        camerafollow.instance.SetPlayer(player);
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (InputDown() && !player.lunching)
        {
            Vector3 touchWorldPosition;
            touchWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            touchWorldPosition.z = 0;
            if (Vector3.Distance(touchWorldPosition, player.transform.position) < 3.0f)
            {
                holdingPlayer = true;


            }


        }
        if (InputUp() && holdingPlayer == true)
        {
            holdingPlayer = false;
            player.Lunch(playerStartPos.position - player.transform.position);
        }
        if (holdingPlayer && player.lunching == false)
        {
            Vector3 newPos;

            if (Input.touchCount > 0)
            {
                newPos = cam.ScreenToWorldPoint(Input.touches[0].position);
            }
            else
            {
                newPos = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            newPos.z = 0;
            player.transform.position = newPos;
        }
    }
}
