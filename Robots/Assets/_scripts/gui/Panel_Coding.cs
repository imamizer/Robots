using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Coding : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ObjCodingElement_Function;
    public Transform contentToPutElements;

    public RobotController roboCont;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addCodingElement_Function()
    {
        Instantiate(ObjCodingElement_Function, contentToPutElements);
    }

    public static void removeCodingElement(Transform CodingElement)
    {
        Destroy(CodingElement);
    }

    void compileCode(List<GameObject> codeObjects)
    {
        
    }

    public void sendCommandToComppile()
    {
        List<GameObject> codeObjects = new List<GameObject>();
        for (int i = 0; i < contentToPutElements.childCount; i++) 
        {
            codeObjects.Add(contentToPutElements.GetChild(i).gameObject);
        }
        roboCont.compileCode(codeObjects);
    }


}
