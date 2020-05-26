
#region EquationSolving
public VennDiagramHelper(string Equation)
		{
			_strEquation = Equation;
		}
    
		public Geometry Solve()
		{
			FormatEquation(ref _strEquation);
			_iCircleCount = CalculateCircleCount(_strEquation);
			CheckCircleCount(_iCircleCount);
			InitializeOperandVisuals();
			
			Geometry result =  ProcessEquation(_strEquation);
			return result;
		}

		private Geometry ProcessEquation(string equation)
		{
			string equ = equation;
			equ = EndWithDelim(equ);

			Stack<Geometry> oprn = new Stack<Geometry>();
			Stack<Operators> oprt = new Stack<Operators>();
			oprt.Push(Operators.Delim);

			int pointer = 0;

			while (pointer < equ.Count())
			{
				Operators curOprt;
				if (_dictNormalOperators.TryGetValue(equ[pointer], out curOprt))
				{
					int curIndex = _oprtOperatorsPriorityIndexer.IndexOf(curOprt);
					int stackIndex = _oprtOperatorsPriorityIndexer.IndexOf(oprt.Peek());
					OperatorsPriority op = _oprtOperatorsPriority[stackIndex, curIndex];
					switch (op)
					{
						case OperatorsPriority.Bigger:

							if (oprn.Count < 2)
							{
								throw gVennDiagramException.InvalidEquation;
							}

							Console.WriteLine(curOprt);

							Geometry operand2 = oprn.Pop();
							Geometry operand1 = oprn.Pop();

							Geometry result = Operate(operand1, operand2, oprt.Pop());
							oprn.Push(result);

							break;
						case OperatorsPriority.Smaller:
							oprt.Push(curOprt);
							pointer++;
							break;
						case OperatorsPriority.Equal:
							oprt.Pop();
							pointer++;
							break;
						case OperatorsPriority.Invalid:
							throw gVennDiagramException.InvalidEquation;
					}

				}
				else if (_dictSpecialOperators.TryGetValue(equ[pointer],out curOprt))
				{
					if (curOprt == Operators.Not)
					{
						Geometry operand = oprn.Pop();
						Geometry result = Operate(operand, Operators.Not);
						oprn.Push(result);
						pointer++;
					}
				}
				else
				{
					oprn.Push(_dictOperandVisual[equ[pointer]]);
					pointer++;
				}
			}
			return oprn.Pop();
		}
              private Geometry Operate(Geometry operand, Operators operators)
		{
			CombinedGeometry cg = new CombinedGeometry(GeometryCombineMode.Exclude, _rgRect, operand);
			return cg;
		}

		private Geometry Operate(Geometry operand1, Geometry operand2, Operators operators)
		{
			CombinedGeometry cg = new CombinedGeometry();
			switch (operators)
			{
				case Operators.Intersect:
					cg.GeometryCombineMode = GeometryCombineMode.Intersect;
					break;
				case Operators.Union:
					cg.GeometryCombineMode = GeometryCombineMode.Union;
					break;
			}
			cg.Geometry1 = operand1;
			cg.Geometry2 = operand2;
			return cg;
		}

