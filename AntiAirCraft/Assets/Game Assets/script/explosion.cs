using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public Transform explosionPrefab;
    public Artillery Artillery;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag== "AirCraft")
        {
            AirCraft air = collision.collider.gameObject.GetComponent<AirCraft>();
            air.manageAirCraft.Lines[air.currentLine] = false;
        }
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Instantiate(explosionPrefab, pos, rot);
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
    void OnBecameInvisible()
    {
        if (Artillery)
        {
            Artillery.countShoot--;
            Destroy(gameObject);
        }
    }
}
