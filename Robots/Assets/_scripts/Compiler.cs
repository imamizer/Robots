using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Compiler : MonoBehaviour
{
    Functions functions;
    // Start is called before the first frame update
    void Start()
    {
        functions = gameObject.GetComponent<Functions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //if(position > loc)

    public void compile(string code)
    {
        // "if" line
        if (code.Substring(0, 2) == "if")
        {
            string condition = code.Split('(', ')')[1];
            if (condition.Contains("<"))
            {
            }
            else if (condition.Contains(">"))
            {
            }
            else if (condition.Contains("="))
            {
            }
        }

        //variable line
        else if (code.Substring(0, 3) == "variable")
        {
        }

        //function line
        else if (code.Contains(")") & code.Contains("("))
        {
            string function = code.Split('(')[0];
            switch (function)
            {
                case "move":
                    Debug.Log("aaaa");
                    //functions.Move()
                    break;
            }
        }

    }
}
