using UnityEditor.Rendering;
using UnityEngine;

public class TsunamiMove : Tsunami
{
    protected override void Start()
    {
        base.Start();
        sO_TSUNAMI.startTime = Time.time + sO_TSUNAMI.startDelayPhase1;
    }

    private void Update()
    {
        this.MoveToPhase();
    }
    private void MoveToPhase()
    {
         float currentTime = Time.time;
        if (currentTime >= sO_TSUNAMI.startTime && !sO_TSUNAMI.isPhase1Active)
        {
            sO_TSUNAMI.isPhase1Active = true;
        }
        if (currentTime >= sO_TSUNAMI.startTime + sO_TSUNAMI.startDelayPhase2 && !sO_TSUNAMI.isPhase2Active && !sO_TSUNAMI.isPhase1Active)
        {
            sO_TSUNAMI.isPhase2Active = true;
        }
        if (sO_TSUNAMI.isPhase1Active)
        {
            MoveTsunami(sO_TSUNAMI.phase1Speed, sO_TSUNAMI.phase1Length, () => sO_TSUNAMI.isPhase1Active = false);
        }
        else if (sO_TSUNAMI.isPhase2Active)
        {
            MoveTsunami(sO_TSUNAMI.phase2Speed, sO_TSUNAMI.phase2Length, () => sO_TSUNAMI.isPhase2Active = false);
        }
    }
    private void MoveTsunami(float speed, float phaseLength, System.Action onPhaseComplete)
    {
        Vector3 currentPosition = transformTsunami.position;
        float targetY = phaseLength;
        if (currentPosition.y <= targetY)
        {
            transformTsunami.position += Vector3.forward * speed * Time.deltaTime;
        }
        else
        {
            onPhaseComplete?.Invoke();
        }
    }
}