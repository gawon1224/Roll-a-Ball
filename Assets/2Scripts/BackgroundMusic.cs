using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    void Awake()
    {
        if(backgroundMusic == null) // backgroundMusic이 없으면
        {
            backgroundMusic = this; //해당 음악파일을 backgroundMusic으로 해라.
            DontDestroyOnLoad(backgroundMusic);
        }

        else
        {
            Destroy(gameObject);
        }
    }

}
