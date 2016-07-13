using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class SpriteManager {
    
    static string[] spriteNames = { "52Deck", "UnoDeck" };
    static Sprite[][] spriteLibrary = null;

    //Get the Index of the string within SpriteNames
    public static int GetSpriteIndex (string spriteName)
    {
        int i = Array.IndexOf(spriteNames, spriteName);
        return i;
    }
    
    //Load the Sprite Library
    static void LoadSpriteLibrary(string spriteName, int spriteInd)
    {
        spriteLibrary[spriteInd] = Resources.LoadAll<Sprite>(spriteName);
    }

    // Returns the Sprite associated with the Card Name and Sprite Library index
    public static Sprite GetCardSprite(string cardName, int spriteInd)
    {
        if(spriteInd < spriteNames.Length)
        {
            if (spriteLibrary == null)
                spriteLibrary = new Sprite[spriteNames.Length][];
            if(spriteLibrary[spriteInd] == null)
                LoadSpriteLibrary(spriteNames[spriteInd], spriteInd);
            Sprite sprite = null;
            for (int x = 0; x < spriteLibrary[spriteInd].Length; x++)
            {
                if (spriteLibrary[spriteInd][x].name == cardName)
                {
                    sprite = spriteLibrary[spriteInd][x];
                    break;
                }
            }
            return sprite;
        }
        else
            return null;
    }
}
