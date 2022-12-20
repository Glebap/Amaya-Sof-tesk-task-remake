using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using UnityEngine;

public class AnswerOptionCreator : MonoBehaviour
{
    private int[][] _unusedOptions;

    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            arr[a] = arr[a + 1];
        }
        Array.Resize(ref arr, arr.Length - 1);
    }

    public int[][] SetOptionsCapacity(CardBundleData[] _cardBundleData)
    {
        int[][] unusedOptions = new int[_cardBundleData.Length][];

        for (int i = 0; i < _cardBundleData.Length; i++)
        {
            unusedOptions[i] = new int[_cardBundleData[i].CardData.Length];
        }

        for (int i = 0; i < unusedOptions.Length; i++)
        {
            for (int j = 0; j < unusedOptions[i].Length; j++)
            {
                unusedOptions[i][j] = j;
            }
        }

        return _unusedOptions = unusedOptions;
    }

    public int GetUnusedAnswerOption(int bundleIndex)
    {
        int bundleRange = _unusedOptions[bundleIndex].Length;
        int index = Random.Range(0, bundleRange);
        int AnswerOption = _unusedOptions[bundleIndex][index];
        RemoveAt(ref _unusedOptions[bundleIndex], index);

        return AnswerOption;
    }
}
