using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CongraturationsText_Script : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextMesh;

    private string TResource = "CONGRATULATIONS";
    private float Times = 0.0f;
    private float Alpha = 1.0f;
    private int Phase = 0;
    private int Position = 0;

    void Start()
    {
        TextMesh.text = "";
        Times = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Phase) {
            case 0:
                Times += Time.deltaTime;
                if (Times >= 0.05f){

                    TextMesh.text += TResource.Substring(Position, 1);
                    Position++;
                    Times = 0.0f;

                    if (Position >= TResource.Length)
                    {
                        Phase = 1;
                    }
                }
                break;
            case 1:
                if (Alpha > 0.0f){
                    Alpha -= 0.01f;
                }else{
                    Phase = 2;
                }
                break;
            case 2:
                Timer.countdownSecound = 240;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
                break;
        }


		TextMesh.color = new Color(1.0f, 1.0f, 1.0f, Alpha);
	}
}
