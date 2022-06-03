using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 50f; 
    private bool canMove = false;
    Vector3 target;
    public Vector3 direction;
    public static PlayerController instance;
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;

    private void Awake()
    {
        instance = this;   
    }
    RaycastHit hit;
    void Update()
    {
 
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if(Physics.Raycast(transform.position, direction, out hit, 1))
        {
            if (!hit.transform.CompareTag(cmpTAG.TAG_WALL))
            {             
               canMove = true;
               target = hit.transform.position;
            }
            else
            {
               canMove =false;        
           }
        }
        Swipe();
    }

    void Swipe()
    {

        if (Input.GetMouseButtonDown(0)) firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (Input.GetMouseButtonUp(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();

            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                PlayerController.instance.direction = Vector3.forward;
                return;
            }

            else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                PlayerController.instance.direction = Vector3.back;
                return;
            }

            else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                PlayerController.instance.direction = Vector3.left;
                return;
            }
            else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                PlayerController.instance.direction = Vector3.right;
                return;
            }

        }
    }
}


public static class cmpTAG
{
    public static string TAG_WALL = "Wall";
    public static string TAG_EmptyStack = "EmptyStack";
    public static string TAG_Finish = "Finish";
    public static string TAG_Player = "Player";


}
