using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrasCommande1 : MonoBehaviour
{
    public GameObject Bras1;


    void Update()
    {
        float input = Input.GetAxis("Bras1");
        EtatBras1 rotationEtat = MoveStateForInput(input);
        BrasControlleur1 controller = Bras1.GetComponent<BrasControlleur1>();
        controller.rotationEtat = rotationEtat;


    }

    EtatBras1 MoveStateForInput(float input)
    {
        if (input > 0)
        {
            return EtatBras1.Positif;
        }
        else if (input < 0)
        {
            return EtatBras1.Negatif;
        }
        else
        {
            return EtatBras1.Fixe;
        }
    }
}
