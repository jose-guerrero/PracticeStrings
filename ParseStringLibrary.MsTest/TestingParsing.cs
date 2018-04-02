using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ParseStringLibrary.MsTest
{
    [TestClass]
    public class TestingParsing
    {
        [TestMethod]
        public void SimpleTest(){
            string[] s1 = {"X","Y","Z"};
            string[] s2 = {"1","2","3"};
            var string1 = new ParseStrings("no{X}and{Y}and{Z}we",s1,s2);
            Assert.IsTrue("no1and2and3we"==string1.res);
        }

        [TestMethod]
        public void NullSimpleTest(){
            string[] s1 = {"X","Y","Z"};
            string[] s2 = {"0",null,"3"};
            var string1 = new ParseStrings("no{X}and{Y}and{X}we",s1,s2);
            Assert.IsTrue("no0andand0we"==string1.res);
        }

        [TestMethod]
        public void OddNumberBrackets(){
            string[] s1 = {"X","Y","Z"};
            string[] s2 = {"1","2","3"};
            var string1 = new ParseStrings("no{X}and{Yand{X}we",s1,s2);
            Assert.IsTrue(false==string1.valid);
        }

        [TestMethod]
        public void NullInputs(){
            var string1 = new ParseStrings("no{X}and{Y}and{X}we",null,null);
            Assert.IsTrue(false==string1.valid);
        }
        
        [TestMethod]
        public void CustomException(){
            string[] s1 = {"X","Y","Z","A"};
            string[] s2 = {"1","2"};
            var string1 = new ParseStrings("no{X}and{Y}awe",s1,s2);
            Assert.IsTrue(false==string1.valid);
        }
    }
}
