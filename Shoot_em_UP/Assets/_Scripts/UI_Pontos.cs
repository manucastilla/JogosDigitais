
using UnityEngine;
using UnityEngine.UI;

public class UI_Pontos : MonoBehaviour
{
    Text textComp;
    GameManager gm;
    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        if (GameObject.FindWithTag("Player"))
        {
            textComp.text = $"Pontos: {gm.pontos}";
        }
    }
}