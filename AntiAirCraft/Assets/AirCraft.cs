using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraft : MonoBehaviour
{
    public int currentLine;
    public float speed = 1;
    public enum Direction { east, west}
    public Direction direction;
    public bool move;
    public bool letMove;
    public Transform leftPoint;
    public Transform rightPoint;
    public bool bombing;
    public ManageAirCraft manageAirCraft;
    public LayerMask layerMask;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        manageAirCraft = GameObject.FindObjectOfType<ManageAirCraft>();
    }

    // Update is called once per frame
    void Update()
    {
        if (letMove)
        {
            if (!manageAirCraft.Lines[currentLine])
            {
                move = true;
            }
        }
        if (move)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            manageAirCraft.Lines[currentLine] = true;
            switch (direction)
            {
                case Direction.east:
                    if (transform.position.x < leftPoint.transform.position.x)
                    {
                        ChangeLine();
                    }
                    break;
                case Direction.west:
                    if (transform.position.x > rightPoint.transform.position.x)
                    {
                        ChangeLine();
                    }
                    break;
            }
        }
        if (bombing)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask))
            {
                if (hit.collider.tag == "target")
                {
                    GameObject cloneAirCraft = Instantiate(bomb, transform.position,transform.rotation);
                    cloneAirCraft.GetComponent<Rigidbody>().AddForce(Vector3.up * -500);
                    bombing = false;
                }
            }
        }
    }

    public void ChangeLine()
    {
        Debug.Log("ChangeLine");
        move = false;
        letMove = false;
        manageAirCraft.Lines[currentLine] = false;
        currentLine++;
        if (currentLine > manageAirCraft.Lines.Length-1)/// delete object
        {
            Destroy(gameObject);
        }
        else
        {
            //manageAirCraft.Lines[currentLine] = true;
            if (currentLine == manageAirCraft.Lines.Length - 1)///bombing
            {
                bombing = true;
            }
            if (direction == Direction.west) direction = Direction.east;
            else direction = Direction.west;
            transform.position = new Vector3(transform.position.x, transform.position.y - manageAirCraft.heightLines, transform.position.z);
            transform.rotation = Quaternion.Inverse(transform.rotation);
            letMove = true;
        }
    }
}
