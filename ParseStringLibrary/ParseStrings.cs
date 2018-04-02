using System;
using System.Collections.Generic;

namespace ParseStringLibrary
{
    public class ParseStrings
    {
        public string res;
        public bool string_valid;  /// is the string valid?
        public bool arrays_valid;  /// are the inputs array valid?
        public ParseStrings(string s,string[] X,string[] Y)
        {
            try
            {     
                if (X.Length != Y.Length)
                {
                    throw new DifferentLengthException();  /// Custom exception
                }

                if (s.IndexOf('{')==-1 && s.IndexOf('}')!=-1)
                {
                    throw new OddNumberBracketsException();
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

                    if (n>m) {
                        throw new OddNumberBracketsException();
                    } 
                    string s1 = s.Substring(0,n);   
                    res = res + s1 + dictionary[s.Substring(n+1,m-n-1)];
                    s = s.Substring(m+1,s.Length-m-1);  /// Cutting to analyse the rest of the string
                }

                arrays_valid = true;
                string_valid = true;
                res += s;
            }
            
            catch(DifferentLengthException) /// The Length of two arrays are different
            {
                arrays_valid = false;
                res = "";
            }
            catch(OddNumberBracketsException)
            {
                arrays_valid = false;
                res = "";
            }
            catch(NullReferenceException)  ///  Null Input
            {
                res = "";
                if (s==null)   string_valid = false;
                else string_valid = true;
                
                if (X==null || Y==null)  arrays_valid = false;
                else arrays_valid = true;

            }   
            catch(KeyNotFoundException)  /// No Key found in Dictionary
            {
                string_valid = false;
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
    [Serializable]
    public class OddNumberBracketsException : Exception
    {
        public OddNumberBracketsException()
        {         
        }
    }
}
