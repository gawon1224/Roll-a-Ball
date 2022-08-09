using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    void Awake()
    {
        if(backgroundMusic == null) // backgroundMusic�� ������
        {
            backgroundMusic = this; //�ش� ���������� backgroundMusic���� �ض�.
            DontDestroyOnLoad(backgroundMusic);
        }

        else
        {
            Destroy(gameObject);
        }
    }

}
