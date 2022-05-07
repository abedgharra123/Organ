using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
   [SerializeField] string Title;
   [SerializeField] Sprite image;
   [SerializeField] string url;
   public string GetTitle(){return Title;}
   public Sprite GetImage(){return image;}
   public string GetURL(){return url;}
}
