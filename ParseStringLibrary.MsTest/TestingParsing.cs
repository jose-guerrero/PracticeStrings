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
        public void OddNumberBrackets1(){
            string[] s1 = {"X","Y","Z"};
            string[] s2 = {"1","2","3"};
            var string1 = new ParseStrings("no{X}and{Yand{X}we",s1,s2);
            Assert.IsTrue(false==string1.string_valid);
        }

        [TestMethod]
        public void AreNullInputs(){
            var string1 = new ParseStrings("no{X}and{Y}and{X}we",null,null);
            Assert.IsTrue(false==string1.arrays_valid);
        }

        [TestMethod]
        public void IsValidString(){
            var string1 = new ParseStrings("no{X}and{Y}and{X}we",null,null);
            Assert.IsTrue(true==string1.string_valid);
        }
        
        [TestMethod]
        public void ArraysDifferentLength(){
            string[] s1 = {"X","Y","Z","A"};
            string[] s2 = {"1","2"};
            var string1 = new ParseStrings("no{X}and{Y}awe",s1,s2);
            Assert.IsTrue(false==string1.arrays_valid);
        }

         [TestMethod]
        public void NoClosedBracket(){
            string[] s1 = {"X","Y","Z"};
            string[] s2 = {"1","2","3"};
            var string1 = new ParseStrings("no{XandYandXwe",s1,s2);
            Assert.IsTrue(false==string1.string_valid);
        }

        [TestMethod]
        public void NoOpenBracket(){
            string[] s1 = {"X","Y","Z"};
            string[] s2 = {"1","2","3"};
            var string1 = new ParseStrings("noX}and{Yand{X}we",s1,s2);
            Assert.IsTrue(false==string1.string_valid);
        }

        [TestMethod]
        public void ManyClosedBrackets(){
            string[] s1 = {"X","Y","Z"};
            string[] s2 = {"1","2","3"};
            var string1 = new ParseStrings("noX}and{Y}}}}}}}and{X}we",s1,s2);
            Assert.IsTrue(false==string1.string_valid);
        }

        
        [TestMethod]
        public void MoreClosedBrackets(){
            string[] s1 = {"X","Y","Z"};
            string[] s2 = {"1","2","3"};
            var string1 = new ParseStrings("noX}and{Y}and{X}w}ee}",s1,s2);
            Assert.IsTrue(false==string1.string_valid);
        }
    }
}
