using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basetBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;
    public static int score = 0;    //分数

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject>();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGo = Instantiate (basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basetBottomY + (basketSpacingY * i);
			tBasketGo.transform.position = pos;
			basketList.Add (tBasketGo);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AppleDestroyed() {
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple");

		foreach (GameObject tGo in tAppleArray) {
			Destroy (tGo);
		}

		int basketIndex = basketList.Count - 1;
		GameObject tBasketGo = basketList [basketIndex];

		basketList.RemoveAt (basketIndex);
		Destroy (tBasketGo);

        //重启游戏，添加头文件UnityEngin.Scenemanager
        if (basketList.Count == 0) {
            SceneManager.LoadScene("_Scene_0");
        }
	}

    public void StartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}
