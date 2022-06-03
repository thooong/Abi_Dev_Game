
using UnityEngine;

public class EdibleStack : MonoBehaviour
{
    public GameObject EdibleModel;
    public void EarnStack1()
    {
        Object.Destroy(EdibleModel);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(cmpTAG.TAG_Player))
        {
            EarnStack1();
            if (other.TryGetComponent<CollectBrick>(out CollectBrick CollectBrick))
            {
                CollectBrick.EarnStack();
            }

        }

    }
}
