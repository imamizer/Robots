using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class compiler : MonoBehaviour
{
    public TMP_Text codeInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void compileCode()
    {
        if (codeInput.text == null) return;

        //BroadcastMessage(codeInput.text, 5);
        gameObject.SendMessage(codeInput.text, 5);
    }

    
}
