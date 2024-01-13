namespace CalculatorConsoleApp
{
    public class CalculatorClass
	{
		public CalculatorClass()
		{
		}

		public string Calculate(string str)
		{
			return this.ShuntingYardMethod(str);
			
		}


		private string ShuntingYardMethod(string str)
		{

            return this.ExecuteCalc(StackExpression(str));
			
		}

        private string ExecuteCalc(string str)
        {
            int index = 0;
            string[] characters = str.Split();
            bool isNumber = false;
            var VarStack = new List<String>();

            for (int i = 0; i < str.Length; i++)
            {
                isNumber = int.TryParse(str.Substring(i, 1), out index);
                if (isNumber)
                {
                    VarStack.Add(index.ToString());
                }
                else
                {
                    string value = this.ExecuteOperation(VarStack[VarStack.Count - 1], VarStack[VarStack.Count - 2], str.Substring(i, 1)).ToString();
                    VarStack.RemoveAt(VarStack.Count - 1);
                    VarStack.RemoveAt(VarStack.Count - 1);
                    VarStack.Add(value);
                }
            }

            return string.Join("", VarStack);
        }

        private int ExecuteOperation(string last, string thlast, string oper)
        {
            int result = 0;
            if (oper == "+")
            {
                result = Int32.Parse(thlast) + Int32.Parse(last);
            }
            else
            {
                if (oper == "-")
                {
                    result = Int32.Parse(thlast) - Int32.Parse(last);
                }
                else
                {
                    if (oper == "*")
                    {
                        result = Int32.Parse(thlast) * Int32.Parse(last);
                    }
                    else
                    {
                        result = Int32.Parse(thlast) / Int32.Parse(last);
                    }
                }
            }
            return result;
        }

        private string StackExpression(string str)
		{
            int index = 0;
            string[] characters = str.Split();
            bool isNumber = false;
            var VarStack = new List<String>();
            var VarStackTemp = new List<String>();

            for (int i = 0; i < str.Length; i++)
            {
                isNumber = int.TryParse(str.Substring(i, 1), out index);
                if (isNumber)
                {
                    VarStack.Add(str.Substring(i, 1));
                    //i++;
                }
                else
                {
                    if (VarStackTemp.Count == 0)
                    {
                        VarStackTemp.Add(str.Substring(i, 1));
                    }
                    else
                    {
                        if (this.Precedence(str.Substring(i, 1), VarStackTemp[VarStackTemp.Count - 1]) == 0)
                        {
                            VarStackTemp.Add(str.Substring(i, 1));
                        }
                        else
                        {
                            VarStack.Add(VarStackTemp[VarStackTemp.Count - 1]);
                            VarStackTemp.RemoveAt(VarStackTemp.Count - 1);
                            VarStackTemp.Add(str.Substring(i, 1));
                        }
                    }
                }
            }


            if (VarStackTemp.Count > 0)
            {
                for (int i = VarStackTemp.Count; i > 0; i--)
                {
                    VarStack.Add(VarStackTemp[i - 1]);
                }
            }
            return string.Join("", VarStack);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="op1"></param>
		/// <param name="op2"></param>
		/// <returns>0 - operator 1 is equal or greater then operator 2, 1 - operator 2 is greater then operator 1</returns>
        private int Precedence(string op1, string op2)
        {
			int operator1 = 0;
            int operator2 = 0;
            if (op1.Equals("+") || op1.Equals("-"))
            {
				operator1 = 1;
			}
			else
			{
				operator1 = 2;
			}

            if (op2.Equals("+") || op2.Equals("-"))
            {
                operator2 = 1;
            }
            else
            {
                operator2 = 2;
            }

			if (operator1 > operator2)
			{
				return 0;
			}
			else
			{
				return 1;
			}

        }
    }
}

