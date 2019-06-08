using MVVMTreeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorFrameViewModel : BaseViewModel
    {
        private string[] operationStringArr = new string[] { "+", "-", "*", "/", "=" };
        private string _resultString;
        public string ResultString
        {
            get{ return _resultString;}
            set{
                _resultString = value;
                OnPropertyChanged("ResultString");
            }
        }
        public ObservableCollection<CalculatorKeyData> Keys { get; set; }
        public CommandWithParameter KeyPressedCommand { get; set; }
        public CalculatorFrameViewModel()
        {
            ResultString = "0";
            Keys = new ObservableCollection<CalculatorKeyData>();
            KeyPressedCommand = new CommandWithParameter(CalculatorButtonClicked);
            InitializeKeys();
        }
        private void InitializeKeys()
        {
            CalculatorKeyData calculatorData0 = new CalculatorKeyData() { KeyName = "0" };
            CalculatorKeyData calculatorData1 = new CalculatorKeyData() { KeyName = "1" };
            CalculatorKeyData calculatorData2 = new CalculatorKeyData() { KeyName = "2" };
            CalculatorKeyData calculatorData3 = new CalculatorKeyData() { KeyName = "3" };
            CalculatorKeyData calculatorData4 = new CalculatorKeyData() { KeyName = "4" };
            CalculatorKeyData calculatorData5 = new CalculatorKeyData() { KeyName = "5" };
            CalculatorKeyData calculatorData6 = new CalculatorKeyData() { KeyName = "6" };
            CalculatorKeyData calculatorData7 = new CalculatorKeyData() { KeyName = "7" };
            CalculatorKeyData calculatorData8 = new CalculatorKeyData() { KeyName = "8" };
            CalculatorKeyData calculatorData9 = new CalculatorKeyData() { KeyName = "9" };
            CalculatorKeyData calculatorData10 = new CalculatorKeyData() { KeyName = "+" };
            CalculatorKeyData calculatorData11 = new CalculatorKeyData() { KeyName = "-" };
            CalculatorKeyData calculatorData13 = new CalculatorKeyData() { KeyName = "*" };
            CalculatorKeyData calculatorData14 = new CalculatorKeyData() { KeyName = "/" };
            CalculatorKeyData calculatorData12 = new CalculatorKeyData() { KeyName = "=" };
            CalculatorKeyData calculatorData15 = new CalculatorKeyData() { KeyName = "C" };
            Keys.Add(calculatorData1);
            Keys.Add(calculatorData2);
            Keys.Add(calculatorData3);
            Keys.Add(calculatorData4);
            Keys.Add(calculatorData5);
            Keys.Add(calculatorData6);
            Keys.Add(calculatorData7);
            Keys.Add(calculatorData8);
            Keys.Add(calculatorData9);
            Keys.Add(calculatorData0);
            Keys.Add(calculatorData10);
            Keys.Add(calculatorData11);
            Keys.Add(calculatorData13);
            Keys.Add(calculatorData14);
            Keys.Add(calculatorData15);
            Keys.Add(calculatorData12);
        }
       
        public void CalculatorButtonClicked(object keyData)
        {
            CalculatorKeyData calculatorKeyData = (CalculatorKeyData)keyData;
            var value = calculatorKeyData.KeyName;
            if (operationStringArr.Any(x => ResultString.EndsWith(x) && ResultString.EndsWith(value)))
                return;
            if (value == "C"){
                ResultString = "0";
                return;
            }
            if (ResultString == "0" || ResultString == "E")
                ResultString = "";
            //restricts the calculator input to max of 15 character length
            if (ResultString.Length >= 15 && !operationStringArr.Any(x => ResultString.Contains(x)))
                return;
            else if (ResultString.Length >= 15 && value != "="){
                return;
            }
            ResultString += Convert.ToString(value);
            if (value == "="){
                try{
                    ResultString = new DataTable().Compute(ResultString.TrimEnd('='), null).ToString();
                }
                catch (Exception ex){
                    //returns error to user if any operation in the screen results in and error during parsing and computation
                    ResultString = "E";
                }
            }
        }
    }
}
