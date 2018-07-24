using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    static public int highScore = 100;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text highScoreText = this.GetComponent<Text>();
        highScoreText.text = "HighScore:" + highScore.ToString();
        //感觉在每次游戏结束时更新本地数据要好些，因此移至Applepicker
        //后来发现可能人为将程序终止，那样的话就记录不了最高成绩了，又移了回来
        //此处存入本地数据
        if (HighScore.highScore > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", HighScore.highScore);
        }
    }

    void Awake()
    {
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        PlayerPrefs.SetInt("ApplePickerHighScore", highScore);
    }
}
