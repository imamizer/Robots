using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeCompiler : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompileCode(TMP_InputField codeInput)
    {
        if (codeInput == null) return;
        string code = codeInput.text;


        string[] codeLines = code.Split("\n");



        Debug.Log(codeLines[0]);
        Debug.Log(codeLines[1]);
    }
}
