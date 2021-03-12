using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_FimDeJogo : MonoBehaviour
{
    public Text message;

    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
        message.text = "Game Over!!!";
    }

    public void Voltar()
    {
        gm.ChangeState(GameManager.GameState.MENU);
        SceneManager.LoadScene(0);
    }
}