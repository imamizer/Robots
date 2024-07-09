using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodingElement_Condition : MonoBehaviour
{
    public TMP_Dropdown availableConditions;
    public Transform Input_object;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void selectedCondition()
    {
        int selectedIndex = availableConditions.value;
        string selectedCondition = availableConditions.options[selectedIndex].text;
        
        clearInputs();
        switch (selectedCondition) 
        {
            case "=":
                //add parameters
                Instantiate(Input_object, transform);
                Instantiate(Input_object, transform);
                break;
        }
    }

    void clearInputs()
    {
        int childcount = transform.childCount;
        if (childcount > 1) 
        {
            for (int i = 1; i < childcount; i++) 
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
