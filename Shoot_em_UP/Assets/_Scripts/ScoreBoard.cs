using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// referência para fazer o scoreboard: 
// https://www.grimoirehex.com/unity-3d-local-leaderboard/

public class PlayerInfo
{
    public string name;
    public int score;

    public PlayerInfo(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
public class ScoreBoard : MonoBehaviour
{
    public InputField userName;
    public Text NAME;
    public Text RANKING;
    public Text SCORE;
    List<PlayerInfo> collectedStats;

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        collectedStats = new List<PlayerInfo>();
        LoadLeaderBoard();
    }

    public void SubmitButton()
    {
        // PlayerInfo stats = new PlayerInfo(userName.text, int.Parse(score.text));
        PlayerInfo stats = new PlayerInfo(userName.text, gm.pontos);
        //Add The New Player Info To The List
        collectedStats.Add(stats);

        //Clear InputFields Now That The Object Has Been Created
        userName.text = "";

        //Start Sorting Method To Place Object In Correct Index Of List
        SortStats();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SortStats()
    {
        //Start At The End Of The List And Compare The Score To The Number Above It
        for (int i = collectedStats.Count - 1; i > 0; i--)
        {
            //If The Current Score Is Higher Than The Score Above It , Swap
            if (collectedStats[i].score > collectedStats[i - 1].score)
            {
                //Temporary variable to hold small score
                PlayerInfo tempInfo = collectedStats[i - 1];

                // Replace small score with big score
                collectedStats[i - 1] = collectedStats[i];
                //Set small score closer to the end of the list by placing it at "i" rather than "i-1" 
                collectedStats[i] = tempInfo;
            }
        }

        //Update PlayerPref That Stores Leaderboard Values
        UpdatePlayerPrefsString();
    }

    void UpdatePlayerPrefsString()
    {
        //Start With A Blank String
        string stats = "";

        //Add Each Name And Score From The Collection To The String
        for (int i = 0; i < collectedStats.Count; i++)
        {
            //Be Sure To Add A Comma To Both The Name And Score, It Will Be Used To Separate The String Later
            stats += collectedStats[i].name + ",";
            stats += collectedStats[i].score + ",";
        }

        //Add The String To The PlayerPrefs, This Allows The Information To Be Saved Even When The Game Is Turned Off
        PlayerPrefs.SetString("LeaderBoards", stats);

        //Now Update The On Screen LeaderBoard
        UpdateLeaderBoardVisual();
    }

    void UpdateLeaderBoardVisual()
    {
        //Clear Current Displayed LeaderBoard
        NAME.text = "";
        SCORE.text = "";
        RANKING.text = "";

        //Simply Loop Through The List And Add The Name And Score To The Display Text
        for (int i = 0; i <= collectedStats.Count - 1; i++)
        {
            NAME.text += collectedStats[i].name + "\n";
            SCORE.text += collectedStats[i].score + "\n";
            RANKING.text += (i + 1) + "\n";

        }
    }

    void LoadLeaderBoard()
    {
        //Load The String Of The Leaderboard That Was Saved In The "UpdatePlayerPrefsString" Method
        string stats = PlayerPrefs.GetString("LeaderBoards", "");

        //Assign The String To An Array And Split Using The Comma Character
        //This Will Remove The Comma From The String, And Leave Behind The Separated Name And Score
        string[] stats2 = stats.Split(',');

        //Loop Through The Array 2 At A Time Collecting Both The Name And Score
        for (int i = 0; i < stats2.Length - 2; i += 2)
        {
            //Use The Collected Information To Create An Object
            PlayerInfo loadedInfo = new PlayerInfo(stats2[i], int.Parse(stats2[i + 1]));

            //Add The Object To The List
            collectedStats.Add(loadedInfo);

            //Update On Screen LeaderBoard
            UpdateLeaderBoardVisual();
        }
    }

    public void ClearPrefs()
    {
        //Use This To Delete All Names And Scores From The LeaderBoard
        PlayerPrefs.DeleteAll();

        //Clear Current Displayed LeaderBoard
        NAME.text = "";
        SCORE.text = "";
    }

}
