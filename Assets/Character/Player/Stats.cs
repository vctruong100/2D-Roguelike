using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stats
{
    [SerializeField]
    private int baseValue;
    private List<int> modifiers = new List<int>();
    public int GetValue () {
        return baseValue;
    }
    public void AddModifier (int modifier) {
        if(modifier != 0) {
            modifiers.Add(modifier);
        }
    }
    public void RemoveModifier (int modifier) {
        if(modifier != 0) {
            modifiers.Remove(modifier);
        }
    }
    public void SetAttributes (int attribute) {
        baseValue = attribute;
    }

    public void AddAttributes (int attribute) {
        baseValue += attribute;
    }
}
