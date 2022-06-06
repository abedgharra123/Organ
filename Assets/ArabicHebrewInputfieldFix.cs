using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ArabicHebrewInputfieldFix : MonoBehaviour
{
    [SerializeField]
    Text text_preview;
    string typing;
    // Start is called before the first frame update
    void Start()
    {
        typing = ArabicSupport.Fix(typing);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<TMP_InputField>().isFocused && Input.anyKeyDown)
        {
            text_preview.text = ArabicSupport.Fix(GetComponent<TMP_InputField>().text);
            print(typing);
        }

    }
}
