using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExpressionCalculation.Interfaces;

namespace ExpressionCalculation
{
    /// <summary>
	/// �����-�������� ��������� �� �����
	/// </summary>
	/// Autor:Oleg Golenischev
    public class ExpressionFileReader : IExpressionFileReader
    {
        private readonly IExpressionValidator _expressionValidator;

        public ExpressionFileReader()
        {
            _expressionValidator = new ExpressionValidator();

        }

        public ExpressionFileReader(IExpressionValidator expressionValidator)
        {
            _expressionValidator = expressionValidator;

        }
        /// <summary>
        /// ����� ������ ��������� �� �����
        /// </summary>
        /// <param name="filename">��� �����, �� �������� ����� ��������� ���������</param>
        /// <returns>������ �������������� ����� ���������</returns>
        /// <exception cref="Exception">��������� � ������ ������ ������ ��� �������������� ���������</exception>
        public string ReadExpressionFromFile(string filename)
        {
            string expression = null;
            try
            {
                using (var stream = new FileStream(filename, FileMode.Open))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        expression = reader.ReadToEnd();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception("��������� ����� �� ����������");
            }
            catch (DirectoryNotFoundException)
            {
               throw new Exception("�������� ����� �� ����������!");
            }
            catch (ArgumentNullException)
            {
                throw new Exception("�������� ������ �� ����� ���� ������");
            }
            catch (ArgumentException)
            {
               throw new Exception("������������ ��� �����");
            }
            catch (PathTooLongException)
            {
                throw new Exception("��� ����� ������� �������!");
            }
            _expressionValidator.ValidateExpression(expression);
            return expression;
        }
    }
}