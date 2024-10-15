using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InimigoPadrão : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehaviour;

    [SerializeField]
    private TankController tank;
    [SerializeField]
    AIDetector detector;

    private void Awake()
    {
        detector = GetComponentInChildren<AIDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
      if (detector.TargetVisible)
      {
            shootBehaviour.PerformAction(tank, detector); 
      }
      else
      {
            patrolBehaviour.PerformAction(tank, detector); 
      }
    }

}
