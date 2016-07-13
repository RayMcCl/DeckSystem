using System.Collections;
using UnityEngine;
using System.Text;
using System.Collections.Generic;

public static class Parser {

	public static string[] ParseText (string path)
    {
        TextAsset bindata = Resources.Load(path) as TextAsset;
        string document = bindata.text;
        List<string> tempArr = new List<string>(0);
        StringBuilder token = new StringBuilder();
        int x = 0;
        //Skip the Header of CSV file
		while(document[x] != '\n' && x <= document.Length){
            x++;
        }
        x++;
        for ( ; x < document.Length; x++)
        {
            if (document[x] == ',' || document[x] == '\n')
            {
                tempArr.Add(token.ToString());
                token.Length = 0;
            }
            else
                token.Append(document[x]);
        }
        string[] data = new string[tempArr.Count];
        for(x = 0; x < data.Length; x++)
        {
            data[x] = tempArr[x];
        }
        return data;
    }
}
