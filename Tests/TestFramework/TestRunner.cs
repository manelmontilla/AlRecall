using System;
using System.Reflection;
namespace  Alrecall
{
    
    public class  TestRunner
    {
        
        public string TestName{get;}
        public TestRunner(string TestName){
            this.TestName=TestName;
        }
    
        public void Run(System.IO.TextWriter writer){
         var t= Type.GetType(this.TestName);
         
         var cons=t.GetConstructors();
         //get first constructor
          object[] pars=new object[]{};
          var instance=cons[0].Invoke(pars);
         foreach ( var m  in t.GetMethods())
         {
             if(m.IsPublic && m.DeclaringType.FullName==t.FullName){
                writer.Write($"Runnig test {m.Name}");
                object[] testPars=new object[1];
                testPars[0]=writer;
                m.Invoke(instance,testPars);
                
             }
         }
        }
    
    };    


}