using UnityEngine;

public class AIDetector : MonoBehaviour
{
    [SerializeField]
    private bool isTargetVisible;
    private Transform isTarget;

    public bool TargetVisible
    {
        get
        {
            
            return isTargetVisible;
        }
        set
        {
            // Isso permitirá que outros scripts modifiquem o valor
            isTargetVisible = value;
        }
    }

    public Transform Target
    {
        get
        {

            return isTarget;
        }
        set
        {
            // Isso permitirá que outros scripts modifiquem o valor
            isTarget = value;
        }
    }

}