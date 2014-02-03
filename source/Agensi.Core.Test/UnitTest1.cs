using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agensi.Core.Util;

namespace Agensi.Core.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var str1 = "My name is michiwaki shohei . I don't speak English";
            var str2 = "My name is shohei michiwaki shohei michiwaki shohei michiwaki　TESTSETEST  LSKJFSLDK; LKJSDf LSKJ lKSDFJLSFJ SLKJFSLKD+FJs KLS+JFl Sdf";

            var result = StringUtil.Compare(3, str2, str1);
        }
    }
}
