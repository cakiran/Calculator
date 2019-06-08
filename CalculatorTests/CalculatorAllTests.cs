using Calculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorAllTests
    {
        private CalculatorFrameViewModel calculatorFrameViewModel;
        [SetUp]
        public void Setup()
        {
            calculatorFrameViewModel = new CalculatorFrameViewModel();
        }
        [TearDown]
        public void Cleanup()
        {
            calculatorFrameViewModel = null;
        }
        [TestCase("+","6")]
        [TestCase("-", "2")]
        [TestCase("*", "8")]
        [TestCase("/", "2")]
        public void AddSubtractMultiplyDivide_Operation_4_And_2(string inputOperation,string expectedResult)
        {
            //arrange
             
            CalculatorKeyData calculatorKeyData1 = new CalculatorKeyData() { KeyName = "4" };
            CalculatorKeyData calculatorKeyData2 = new CalculatorKeyData() { KeyName = inputOperation };
            CalculatorKeyData calculatorKeyData3 = new CalculatorKeyData() { KeyName = "2" };
            CalculatorKeyData calculatorKeyData4 = new CalculatorKeyData() { KeyName = "=" };
            //act
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData1);
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData2);
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData3);
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData4);
            //assert
            Assert.AreEqual(calculatorFrameViewModel.ResultString, expectedResult);
        }

        [Test]
        public void Divide_Operation_1_By_0_Result_Infinity()
        {
            //arrange
            //CalculatorFrameViewModel calculatorFrameViewModel = new CalculatorFrameViewModel();
            CalculatorKeyData calculatorKeyData1 = new CalculatorKeyData() { KeyName = "1" };
            CalculatorKeyData calculatorKeyData2 = new CalculatorKeyData() { KeyName = "/" };
            CalculatorKeyData calculatorKeyData3 = new CalculatorKeyData() { KeyName = "0" };
            CalculatorKeyData calculatorKeyData4 = new CalculatorKeyData() { KeyName = "=" };
            //act
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData1);
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData2);
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData3);
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData4);
            //assert
            Assert.AreEqual(calculatorFrameViewModel.ResultString, "∞");
        }

        [Test]
        public void Divide_Operation_0_By_1_Result_Error()
        {
            //arrange
           // CalculatorFrameViewModel calculatorFrameViewModel = new CalculatorFrameViewModel();
            CalculatorKeyData calculatorKeyData1 = new CalculatorKeyData() { KeyName = "0" };
            CalculatorKeyData calculatorKeyData2 = new CalculatorKeyData() { KeyName = "/" };
            CalculatorKeyData calculatorKeyData3 = new CalculatorKeyData() { KeyName = "1" };
            CalculatorKeyData calculatorKeyData4 = new CalculatorKeyData() { KeyName = "=" };
            //act
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData1);
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData2);
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData3);
            calculatorFrameViewModel.CalculatorButtonClicked(calculatorKeyData4);
            //assert
            Assert.AreEqual(calculatorFrameViewModel.ResultString, "E");
        }
    }
}
