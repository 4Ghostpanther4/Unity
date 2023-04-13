using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalShooter : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject orangePortalPrefab;
    [SerializeField] GameObject bluePortalPrefab;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OrangePortal();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            BluePortal();
        }
    }
    void OrangePortal()
    {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, 100, layer);
        
        Debug.Log(hitInfo.point);
        if(hitInfo.point != Vector2.zero)
        {
            Destroy(GameObject.Find("OrangePortal(Clone)"));
            Instantiate(orangePortalPrefab, hitInfo.point, Quaternion.Euler(0, 0, 0));
        }
       
    }
    void BluePortal()
    {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right, 100, layer);

        Debug.Log(hitInfo.point);
        if(hitInfo.point != Vector2.zero)
        {
            Destroy(GameObject.Find("BluePortal(Clone)"));
            Instantiate(bluePortalPrefab, hitInfo.point, Quaternion.Euler(0, 0, 0));
        }
        
    }
}
