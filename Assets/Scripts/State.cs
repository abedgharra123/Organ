using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
   [SerializeField] string Title;

   [TextArea(10,14)] [SerializeField] string DataText;
   [SerializeField] Sprite image; 

   public string GetTitle(){return Title;}
   public string GetDataText(){return DataText;}
   public Sprite GetImage(){return image;}
}
