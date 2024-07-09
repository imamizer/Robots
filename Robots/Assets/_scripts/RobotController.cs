using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class RobotController : MonoBehaviour
{
    public static Dictionary<string,string> availableFunctions = new Dictionary<string,string>();


    //controller functions
    void Wait(float seconds)
    { }
    void Loop(int times)
    { }
    

    void UpdateAvailableFunctions()
    {
        availableFunctions.Add("Wait", "float");
        availableFunctions.Add("Loop", "int");
    }

    void UpdateAvailableFunctionsFromModules(Dictionary<string,string> functions)
    {
        foreach (var func in functions)
        {
            //if (availableFunctions.ContainsKey(func.Key)) 
            availableFunctions.Add(func.Key, func.Value);
        }
    }

    void RemoveAvailableFunctionsFromModules(Dictionary<string, string> functions)
    {
        foreach (var func in functions)
        {
            //if (availableFunctions.ContainsKey(func.Key)) 
            availableFunctions.Remove(func.Key);
        }
    }


    public void compileCode(List<GameObject> codeObjects)
    {   
        Debug.Log(codeObjects.Count);
        for (int i = 0; i < codeObjects.Count; i++) 
        {
            GameObject go = codeObjects[i];
            if (go == null) return;

            // function compile    
            if (go.name == "Panel_Function(Clone)")
            {
                CodingElement_Function codingElement = go.GetComponent<CodingElement_Function>();
                int selectedIndex = codingElement.availableFunctions.value;
                string functionString = codingElement.availableFunctions.options[selectedIndex].text;
                //add parameters
                string parameters = null;
                if (go.transform.childCount > 1)
                {
                    //skip first child. it is dropdown
                    for (int ii = 1; ii < go.transform.childCount; ii++)
                    {
                        if (ii == go.transform.childCount - 1) parameters = parameters + go.transform.GetChild(ii).GetComponent<TMP_InputField>().text;
                        else parameters = parameters + go.transform.GetChild(ii).GetComponent<TMP_InputField>().text + ",";
                    }
                }
                //send broadcast 
                if (parameters == null) BroadcastMessage(functionString);
                else BroadcastMessage(functionString, parameters);
                Debug.Log("func ran");
            }

            // condition compile
            else if (go.name == "Panel_Condition(Clone)")
            {
                CodingElement_Condition codingElement = go.GetComponent<CodingElement_Condition>();
                int selectedIndex = codingElement.availableConditions.value;
                string functionString = codingElement.availableConditions.options[selectedIndex].text;

                // commence condition
               
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateAvailableFunctions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
