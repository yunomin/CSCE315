using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folllowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, offset.y, offset.z);
    }
}