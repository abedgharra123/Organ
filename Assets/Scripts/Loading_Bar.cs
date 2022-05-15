using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Bar : MonoBehaviour
{
    [SerializeField] RectTransform FxHolder;
    [SerializeField] Image CircleImg;
    [SerializeField] Text txtProgress;
    [SerializeField] [Range(0, 1)] float progress = 0f;

    private float Rnd_Num;

    void Start()
    {
      Rnd_Num= Random.Range(3,6); 
      Invoke("Game_Field_Transfoorm", Rnd_Num);
    }


    // Update is called once per frame
    void Update()
    {
        if (Mathf.Floor(progress * 100) < 100)
        { 
        CircleImg.fillAmount = progress;
        txtProgress.text = Mathf.Floor(progress * 100).ToString();
        FxHolder.rotation = Quaternion.Euler(new Vector3(0f, 0f, -progress * 360));
        if (Mathf.Floor(progress * 100) != 99)
           progress += 0.0085f;
        else
           progress += 1f;

        }
        else
             SceneManager.LoadScene("Game_Field");
    }

    private void Game_Field_Transfoorm()
    {
       SceneManager.LoadScene("Game_Field");
    }
}
