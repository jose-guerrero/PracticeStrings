using System;
using System.Collections.Generic;

namespace ParseStringLibrary
{
    public class ParseStrings
    {
        public string res;
        public bool valid;
        public ParseStrings(string s,string[] X,string[] Y)
        {
            try
            {     
                if (X.Length != Y.Length)
                {
                    throw new DifferentLengthException();  /// Custom exception
                }

                Dictionary<string, string> dictionary = new Dictionary<string, string>(); 
                for (int i = 0; i < X.Length; i++)
                {
                    dictionary.Add(X[i],Y[i]);  
                }

                res = "";
                while (true)
                {
                    int n = s.IndexOf('{');   /// Searching for '{'
                    if (n==-1) break;         /// If it is not found then theres no more strings to change
                    int m = s.IndexOf('}');

                    string s1 = s.Substring(0,n);   
                    res = res + s1 + dictionary[s.Substring(n+1,m-n-1)];
                    s = s.Substring(m+1,s.Length-m-1);  /// Cutting to analyse the rest of the string
                }
                valid = true;
                res += s;
            }
            catch
            {
                valid = false;
                res = "";
            }          
        }       
    }

    [Serializable]
    public class DifferentLengthException : Exception
    {
        public DifferentLengthException()
        {         
        }
    }
}
