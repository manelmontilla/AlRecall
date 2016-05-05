namespace AlRecall.Structures.Strings
{

    public static class Util
    {
            public static int PatternMatch(this string text,string pattern)
            {
               string s=string.Concat(pattern,text);
               var z=CalcZArray(s);
               int res=-1;
               for(int i=pattern.Length;i<s.Length;i++)
               {
                   if(z[i]>=pattern.Length)
                   {
                       res=i-pattern.Length;
                       break;
                   }
               }
               return(res);
            }

            public static int[] CalcZArray(string s)
            {
                int[] z=new int[s.Length];
                int l=0;
                int r=0;
                for(int i=0;i<s.Length;i++)
                {
                    if(i>r)
                    {
                        bool found=false;
                        int j=0;
                        r=i;
                        while(!found && r<s.Length)
                        {
                            if(s[j]!=s[r])
                            {
                                found=true;
                            }
                            else
                                {
                                    r++;
                                    j++;
                                }
                        }
                        l=i;
                        r=r-1;
                        z[i]=r-l+1;
                    }
                    else
                    {
                        int k=i-l;
                        if(z[k]<r-i+1)
                            z[i]=z[k];
                        else
                        {
                            
                            r=k;
                            int j=0;
                            bool found=false;
                            while(!found && r<s.Length)
                            {
                               if(s[j]!=s[r])
                                    found=true;
                                else
                                    {
                                        r++;
                                        j++;
                                    }
                            }
                             r--;
                             l=k;
                             z[i]=r-l+1;   
                        }
                    }
                }
            return(z);
            }
    }

}
