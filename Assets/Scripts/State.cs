using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
   [SerializeField] string Title;
   [TextArea(10,14)] [SerializeField] string DataText;

   public string GetTitle(){return Title;}
   public string GetDataText(){return DataText;}
}
