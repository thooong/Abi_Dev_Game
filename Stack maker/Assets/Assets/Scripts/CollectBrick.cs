using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBrick : MonoBehaviour
{
    public Stack<GameObject> brickStacks;
    public GameObject EarnStackPrefab;
    public Transform PosStack;
    public Transform playerMesh;
    public Animator AnimatorPlayer;
    public float HighStack = 0.3f;
    private void Awake()
    {
        HighStack = 0.3f;
        brickStacks = new Stack<GameObject>();
    }
    public void ChangeHeightModel()
    {
        playerMesh.transform.localPosition = new Vector3(playerMesh.transform.localPosition.x, 0.3f * brickStacks.Count, playerMesh.transform.localPosition.z);
    }

    public void EarnStack()
    {
        GameObject stackEarn = Instantiate(EarnStackPrefab, PosStack.transform);
        brickStacks.Push(stackEarn);

        stackEarn.transform.localPosition = new Vector3(0, (brickStacks.Count - 1) * HighStack, 0);
        playerMesh.transform.localPosition = new Vector3(playerMesh.transform.localPosition.x, 0.3f * brickStacks.Count, playerMesh.transform.localPosition.z);

    }
    public void DeleteStack(GameObject brickPosition)
    {
        GameObject stack = brickStacks.Pop();
        stack.transform.position = new Vector3(brickPosition.transform.position.x, playerMesh.position.y - HighStack, brickPosition.transform.position.z);
        Instantiate(EarnStackPrefab, brickPosition.transform);
        Destroy(stack);
        ChangeHeightModel();

    }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag(cmpTAG.TAG_EmptyStack))
        {
            DeleteStack(other.gameObject);
          
        }
        if (other.CompareTag(cmpTAG.TAG_Finish))
        {
          AnimatorPlayer.Play("Win");
        }
    }

}
