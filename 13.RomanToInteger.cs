using System.Linq;
using System;
using System.Collections;
namespace RomanToInteger;
public class Problem13 {
  public class Solution {
    public int RomanToInt(string s) {
      Hashtable romanTable = new Hashtable();
      int sum = 0;
      romanTable.Add("I", 1);
      romanTable.Add("V", 5);
      romanTable.Add("X", 10);
      romanTable.Add("L", 50);
      romanTable.Add("C", 100);
      romanTable.Add("D", 500);
      romanTable.Add("M", 1000);
      romanTable.Add("IV", 4);
      romanTable.Add("IX", 9);
      romanTable.Add("XL", 40);
      romanTable.Add("XC", 90);
      romanTable.Add("CD", 400);
      romanTable.Add("CM", 900);
      for (int i = 0; i < s.Length; i++) {
        if (i < s.Length - 1 && romanTable.ContainsKey(s.Substring(i, 2))) {
          sum += (int)romanTable[s.Substring(i, 2)];
          i++;
        } else {
          sum += (int)romanTable[s.Substring(i, 1)];
        }
      }
      return sum;
    }
    public int RomanToIntTwo(string s) {
      Dictionary<char, int> romanTable = new Dictionary<char, int>
          {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

      s = s.Replace("IV", "IIII")
           .Replace("IX", "VIIII")
           .Replace("XL", "XXXX")
           .Replace("XC", "LXXXX")
           .Replace("CD", "CCCC")
           .Replace("CM", "DCCCC");

      int sum = 0;
      for (int i = 0; i < s.Length; i++) {
        sum += romanTable[s[i]];
      }
      return sum;
    }
    public int RomanToIntThree(string s) {
      Dictionary<char, int> romanTable = new Dictionary<char, int>
          {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
      int sum = 0;
      for (int i = 0; i < s.Length; i++) {
        if (i < s.Length - 1 && romanTable[s[i]] < romanTable[s[i + 1]]) {
          sum -= romanTable[s[i]];
        } else {
          sum += romanTable[s[i]];
        }
      }
      return sum;
    }
  }

}