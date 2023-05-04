using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instancen;
    private Rigidbody2D mybody;
    public Text scoreUi,bestScore;
    string score = "0";
    // Start is called before the first frame update
    void Awake()
    {
        MakeInstances();
        mybody = GetComponent<Rigidbody2D>();
        scoreUi.text = scores(score);
    }
    void MakeInstances()
    {
        if (instancen == null)
        {
            instancen = this;
        }
    }
    public string scores(string score)
    {
        return score;
    }
}
