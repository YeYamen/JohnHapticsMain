using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : Raycastables
{
    public override void Casted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);   
    }
}
