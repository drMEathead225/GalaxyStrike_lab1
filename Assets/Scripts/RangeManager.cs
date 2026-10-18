using UnityEngine;

public class RangeManager : MonoBehaviour
{
    [SerializeField] GameObject[] targets;   // set Size, then drag every target in

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetTargets();
        }
    }

    void ResetTargets()
    {
        // For each GameObject in the targets array, call it "target" and re-enable it
        foreach (GameObject target in targets)
        {
            target.SetActive(true);
        }
    }
}
