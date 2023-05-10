using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_UI_Control : MonoBehaviour
{
    [SerializeField] GameObject SelectCursol; Vector2 SCPos; private int Select = 0;

    //45
    void Start()
    {
        SCPos = SelectCursol.GetComponent<RectTransform>().anchoredPosition;
    }

    void Update()
    {
        if (gameObject.activeInHierarchy)
		{
            if (Input.GetKeyDown(KeyCode.UpArrow)) Select--;
            if (Input.GetKeyDown(KeyCode.DownArrow)) Select++;

            if (Select < 0) Select = 4;
            if (Select > 4) Select = 0;

            SelectCursol.GetComponent<RectTransform>().anchoredPosition = new Vector2(SCPos.x, SCPos.y - (Select * 45.0f));

		}
    }
}
