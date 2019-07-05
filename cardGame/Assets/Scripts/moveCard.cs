using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCard : MonoBehaviour
{
    public GameObject newSpace;
    public GameObject swapAlly;
    public GameObject enemy;
    public GameObject card;
    cardSpecs specs;
    public string fieldLayer;
    public bool occupied = false;

    private void Awake()
    {
        specs = card.GetComponent<cardSpecs>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(fieldLayer))
            newSpace = other.gameObject;
        if (other.gameObject.tag == "card" && other.GetComponent<cardSpecs>().teamNumber == specs.teamNumber)
        {
            swapAlly = other.gameObject;
            occupied = true;
        }
        else if (other.gameObject.tag == "card" && other.GetComponent<cardSpecs>().teamNumber != specs.teamNumber)
        {
            enemy = other.gameObject;
            occupied = true;
        }
    }
    private void OnDisable()
    {
        newSpace = null;
        swapAlly = null;
        enemy = null;
        occupied = false;
    }
    public void moveCard1Space()
    {
        card.transform.position = new Vector3(newSpace.transform.position.x, newSpace.transform.position.y, card.transform.position.z);
    }
    public void swapCard1Space()
    {
        Vector3 oldCardPos = new Vector3(card.transform.position.x, card.transform.position.y, card.transform.position.z);
        card.transform.position = new Vector3(swapAlly.transform.position.x, swapAlly.transform.position.y, swapAlly.transform.position.z);
        swapAlly.transform.position = oldCardPos;
        swapAlly.GetComponent<cardSpecs>().navButtonParent.SetActive(false);
        swapAlly.GetComponent<cardSpecs>().navButtonParent.SetActive(true);
        card.GetComponent<cardSpecs>().navButtonParent.SetActive(false);
        card.GetComponent<cardSpecs>().navButtonParent.SetActive(true);
    }
}
