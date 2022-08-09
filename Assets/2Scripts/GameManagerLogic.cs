using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    
    public TextMeshProUGUI stageCountText;
    public TextMeshProUGUI playerCountText;

    void Awake()
    {
        stageCountText.text = "/" + totalItemCount;
    }

    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(stage);
        // LoadScene의 매개변수는 장면 순서(int)도 가능함
        // -> 매개변수를 string형인 Scene 이름으로 전달해도 되고, int형 변수인 stage를 넣어도 됨
    }
}
