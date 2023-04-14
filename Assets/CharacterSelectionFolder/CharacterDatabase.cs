using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public CHARACTER[] character;
    public int characterCount
    {
        get
        {
            return character.Length;
        }
    }
    public CHARACTER GetCHARACTER(int index)
    {
        return (character[index]);
    }
}
