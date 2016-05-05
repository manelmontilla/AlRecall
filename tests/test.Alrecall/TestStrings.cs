using System;
using AlRecall.Structures.Strings;
using Xunit;
namespace  test.Alrecall
{
    public class TestStrings
    {
        public TestStrings()
        {
            
        }
        [Fact]
        public void TestShortPattern()
        {
            string s="abcdddef";
            string pattern="bcd";
            Assert.Equal(s.IndexOf(pattern),s.PatternMatch(pattern)); 
             
        }
        [Fact]
        public void TestNoMatchPattern()
        {
            string s="abcdddef";
            string pattern="zz";
            Assert.Equal(s.IndexOf(pattern),s.PatternMatch(pattern)); 
             
        }
        [Fact]
        public void TestReturnFirstOccurrence()
        {
            string s="abcdddefdd";
            string pattern="dd";
            var indexOfPos=s.IndexOf(pattern);
            var zAlgPoos=s.PatternMatch(pattern);
            Assert.Equal(indexOfPos,zAlgPoos); 
             
        }
        
       
    }
}