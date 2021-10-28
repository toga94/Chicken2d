using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public Text coinUI;
    public float currentCoins; 
    // Start is called before the first frame update
    void Start()
    {
        coinUI.text = MinifyCurrency(currentCoins);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void AddCoin (float value)
    {
        currentCoins += value;
        coinUI.text = MinifyCurrency(currentCoins);
    }
    public string MinifyCurrency(float value)
    {
        if (value >= 10000000)
            return (value / 1000000).ToString("#,0") + "M";
        if (value >= 1000000)
            return (value / 1000000D).ToString("0.#") + "M";
        if (value >= 100000)
            return (value / 1000).ToString("#,0") + "K";
        if (value >= 1000)
            return (value / 1000D).ToString("0.#") + "K";
        return value.ToString("#,0");
    }



    private static List<Tuple<int, string>> ZeroesAndLetters = new List<Tuple<int, string>>()
{
    new Tuple<int, string>(9, "B"),
    new Tuple<int, string>(6, "M"),
    new Tuple<int, string>(3, "K"),
};

    public static string GetPointsShortened(float num)
    {
        int zeroCount = num.ToString().Length;
        for (int i = 0; i < ZeroesAndLetters.Count; i++)
            if (zeroCount >= ZeroesAndLetters[i].Item1)
                return (num / Math.Pow(10, ZeroesAndLetters[i].Item1)).ToString() + ZeroesAndLetters[i].Item2;
        return num.ToString();
    }
}
