using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EtatBras1 { Fixe = 0, Positif = 1, Negatif = -1 };

public class BrasControlleur1 : MonoBehaviour
{

    public EtatBras1 rotationEtat = EtatBras1.Fixe;
    public float vitesse = 30.0f;

    private ArticulationBody articulation;

    void Start()
    {
        articulation = GetComponent<ArticulationBody>();
    }

    void FixedUpdate()
    {
        if (rotationEtat != EtatBras1.Fixe)
        {
            float rotationChange = (float)rotationEtat * vitesse * Time.fixedDeltaTime;
            float rotationGoal = AxeRotation() + rotationChange;
            RotationVers(rotationGoal);
        }


    }

    float AxeRotation()
    {
        float RotationRads = articulation.jointPosition[0];
        float Rotation = Mathf.Rad2Deg * RotationRads;
        return Rotation;
    }

    void RotationVers(float primaryAxisRotation)
    {
        var drive = articulation.xDrive;
        drive.target = primaryAxisRotation;
        articulation.xDrive = drive;
    }
}
