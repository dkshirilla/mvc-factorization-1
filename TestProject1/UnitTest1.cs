using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            using (var sw = new StringWriter())
            {
                var obj = new mvc_factorization_1.Controllers.HomeController();


                //test for no factors found
                var t = obj.GetFactorization("{\"Value\":\"1\"}");

                Assert.AreEqual("none",t.Value);


                //test for factor found
                var t2 = obj.GetFactorization("{\"Value\":\"9\"}");
                List<string> testList = new List<string>();
                testList.Add("3");
                Assert.AreEqual(testList, t2.Value);
            }
        }
    }
}