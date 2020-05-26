#region Diagram
		private int _iRadius = 25;
		private RectangleGeometry _rgRect = new RectangleGeometry(new Rect(0, 0, 100, 100));
		private Brush _bFill = Brushes.SkyBlue;
        Union Union = new Union();
        Intersect Intersect = new Intersect();
        stackVenn stackIndex = new stackVenn(50);
		private List<List<Point>> _plCirclesPoint = new List<List<Point>>() { 
			{new List<Point>() { new Point(50, 50) }}, //one
			{new List<Point>() { new Point(33, 50), new Point(66, 50) }}, //two
			{new List<Point>() { new Point(48, 33), new Point(33, 66), new Point(66, 66) }} //three
		};
		#endregion

		#region Operators
		private enum Operators
		{
			Intersect,
			Union,
			LeftBracket,
			RightBracket,
			Not,
			Delim
		}

		private Dictionary<char, Operators> _dictNormalOperators = new Dictionary<char, Operators>(){
			{'n',Operators.Intersect},
			{'u', Operators.Union},
			{'(',Operators.LeftBracket},
			{')',Operators.RightBracket},
			{'#',Operators.Delim}};
		private Dictionary<char, Operators> _dictSpecialOperators = new Dictionary<char, Operators>(){
				  {'\'',Operators.Not}};

		private enum OperatorsPriority
		{
			Bigger,
			Smaller,
			Equal,
			Invalid
		}
		//  n u ( ) # 
		//n > > < > >
		//u > > < > >
		//( < < < = X
		//) > > X > >
		//# < < < X =
		private List<Operators> _oprtOperatorsPriorityIndexer = new List<Operators>() { Operators.Intersect, Operators.Union, Operators.LeftBracket, Operators.RightBracket, Operators.Delim };
		// [stack, current]
		private OperatorsPriority[,] _oprtOperatorsPriority = {
													{OperatorsPriority.Bigger,OperatorsPriority.Bigger,OperatorsPriority.Smaller,OperatorsPriority.Bigger,OperatorsPriority.Bigger},
													{OperatorsPriority.Bigger,OperatorsPriority.Bigger,OperatorsPriority.Smaller,OperatorsPriority.Bigger,OperatorsPriority.Bigger},
													{OperatorsPriority.Smaller,OperatorsPriority.Smaller,OperatorsPriority.Smaller,OperatorsPriority.Equal,OperatorsPriority.Invalid},
													{OperatorsPriority.Bigger,OperatorsPriority.Bigger,OperatorsPriority.Invalid,OperatorsPriority.Bigger,OperatorsPriority.Bigger},
													{OperatorsPriority.Smaller,OperatorsPriority.Smaller,OperatorsPriority.Smaller,OperatorsPriority.Invalid,OperatorsPriority.Equal}
												  };

		private string[] _strAllAvailableOperators = { "n", "u", "'", "(", ")" };
		private string[] _strLongOperators = { "intersect", "union" };
		private int _iCircleLimit = 3;
		#endregion

		#region Private Field
		private string _strEquation;
		private int _iCircleCount;	//operands
		private List<char> _clOperands;
		private Dictionary<char, Geometry> _dictOperandVisual = new Dictionary<char, Geometry>();
		#endregion

		#region Execption
		static class gVennDiagramException
		{
			public static Exception OutOfCircleLimit = new Exception("The number of circle used is more than limit.");

			public static Exception NoCircleIsUsed = new Exception("No circle is used.");

			public static Exception InvalidEquation = new Exception("Invalid equation");
		}
		#endregion


#region PreOperate

		#region FormatEquation
		private void FormatEquation(ref string equation)
		{
			equation = ConvertToLowerCase(equation);
			equation = ReplaceWhiteSpace(equation);
			equation = ReplaceLongOperators(equation);
		}

		private string ReplaceWhiteSpace(string equation)
		{
			return Regex.Replace(equation, " ", "");
		}

		private string ReplaceLongOperators(string equation)
		{
			string equ = equation;
			for (int i = 0; i < _strLongOperators.Count(); i++)
			{
				equ = Regex.Replace(equ, _strLongOperators[i], _strAllAvailableOperators[i]);
			}
			return equ;
		}

		private string ConvertToLowerCase(string equation)
		{
			return equation.ToLower();
		}

		private string EndWithDelim(string equation)
		{
			return equation + _dictNormalOperators.First(item=>item.Value == Operators.Delim).Key.ToString();
		}
		#endregion

		#region CircleCount
		private int CalculateCircleCount(string equation)
		{
			string equ = equation;
			_strAllAvailableOperators.ToList().ForEach(item => equ = equ.Replace(item, ""));
			//unportable.
			_clOperands = equ.Distinct().ToList();
			return _clOperands.Count;
		}

		#region CheckCircleCount
		private void CheckCircleCount(string equation)
		{
			CheckCircleCount(CalculateCircleCount(equation));
		}

		private void CheckCircleCount(int count)
		{
			if (count > _iCircleLimit)
			{
				throw gVennDiagramException.OutOfCircleLimit;
			}
			else if (count <= 0)
			{
				throw gVennDiagramException.NoCircleIsUsed;
			}
		}
		#endregion
		#endregion
		#endregion