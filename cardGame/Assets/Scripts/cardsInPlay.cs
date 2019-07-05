using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardsInPlay : MonoBehaviour
{
    public cardSpecs[] cardsOnField;

    // Update is called once per frame
    void Update()
    {
        cardsOnField = GetComponents<cardSpecs>();
    }
}
