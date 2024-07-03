using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
        for (int i = 0; i < codeObjects.Count; i++) 
        {
            GameObject go = codeObjects[i];
                if (go != null) 
                {
                    if (go.name == "Panel_Function")
                    {
                    CodingElement_Function codingElement = go.GetComponent<CodingElement_Function>();
                    string CodeName = codingElement.availableFunctions.options[codingElement.availableFunctions.value].ToString();

                    
                    } 

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
