using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject teleportPoint;
    [SerializeField] string otherPortal;
    [SerializeField] string objectTag;

    private void Start()
    {
        teleportPoint = GameObject.Find(otherPortal + "(Clone)");
    }
    private void Update()
    {
        teleportPoint = GameObject.Find(otherPortal + "(Clone)");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(objectTag))
        {
            TeleportMovement player = collision.GetComponent<TeleportMovement>();
            if (!player.hasTeleported)
            {
                player.hasTeleported = true;
                collision.transform.position = teleportPoint.transform.position;
            }   
        }
    }
    
}
