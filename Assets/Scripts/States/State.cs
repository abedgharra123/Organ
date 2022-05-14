using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
   [SerializeField] Sprite image;
   [SerializeField] string[] url;
   public Sprite GetImage(){return image;}
   public string[] GetURL(){return url;}
}
