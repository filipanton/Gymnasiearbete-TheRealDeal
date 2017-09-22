using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float PPUScale;
    public float PPU;
    Camera mycam;

    // Use this for initialization
    void Start()
    {
        mycam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        PPUScale = Screen.height / 480f;
        mycam.orthographicSize = ((Screen.height) / (PPUScale * PPU)) * 0.5f;

        if (target)
        {
            transform.position = new Vector3(target.position.x, target.position.y, -10) + new Vector3(0, 10 ,0);
        }
    }
}