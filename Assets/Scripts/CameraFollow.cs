using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float PPUScale;
    public float PPU;
    Camera mycam;
    public float range;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    public GameObject player;
    public float offset;
    private Vector3 playerPosition;
    public float offsetSmoothing;


    // Use this for initialization
    void Start()
    {
        mycam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {


        // Set PPUScale to a value that is your current screen height divided by your base art resolution
        PPUScale = Screen.height / 480f;
        // Set the OrthoSize to this wacky formula
        mycam.orthographicSize = ((Screen.height) / (PPUScale * PPU)) * 0.5f;

        


        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0f)
        {

            playerPosition = new Vector3(playerPosition.x + offset, target.position.y, -10);


        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, target.position.y, -10);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
            

        }
    }
}