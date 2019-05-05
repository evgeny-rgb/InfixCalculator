using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InfixCalculator
{
    /// <summary>
	/// �����-�������� ��������� �� �����
	/// </summary>
	/// Autor:Oleg Golenischev
    internal class ExpressionFileReader
    {
        /// <summary>
        /// ���� ����������, ��������� ���������� �������� ��� ������ ���������
        /// </summary>
        private readonly HashSet<char> _symbols;
        /// <summary>
        /// ���� ���������� ��������� ��������, ���������� ���������
        /// </summary>
        private readonly HashSet<char> _operations;
        /// <summary>
        /// �����, ������� ������������ �������� ��������� �� ������������
        /// </summary>
        /// <param name="expression">������� ���������, ������� ���� ��������� �� ������������</param>
        /// <exception cref="ArgumentNullException">���������� � ������, ���� ������ ����� null ��� �����</exception>
        /// <exception cref="ArgumentException">���������� ����:
        /// <list type="bullet">
        /// <item>
        /// <term>������ �� �������� ���������� ��������� �������������������</term>
        /// <description>���������� ������������� � ������������� ������ � ������ �� �����</description>
        /// </item>
        /// <item>
        /// <term>�������� ������������ ������</term>
        /// <description>��������� �������, �� ���������� ����������� �������, �������� ��������, ������ ���������� ��������</description>
        /// </item>
        /// <item>
        /// <term>���������� � ��������, ����� �������� ������ ��� ������������� ������� ������</term>
        /// </item>
        /// <item>
        /// <term>�������� ����� ����� ������������� ������� �������</term>
        /// </item>
        /// <item>
        /// <term>�������� ����� ����� ������������� ������� ������</term>
        /// </item>
        /// <item>
        ///<term>�������� ��� �������� �������� ������</term>
        /// </item>
        /// </list>
        /// </exception>
        private void ValidateExpression(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentNullException(nameof(expression), "������ �� ����� ���� null ��� ������");
            var depth = 0;
            foreach (var t in expression)
            {
                switch (t)
                {
                    case '(':
                        depth++;
                        break;
                    case ')':
                        depth--;
                        if(depth<0) throw new ArgumentException("������ ������ ���� ���������� ��������� �������������������");
                        break;
                    default:
                        if(!_symbols.Contains(t))
                            throw new ArgumentException("������ �������� ������������ ��������");
                        break;
                }
            }
            if(depth!=0) throw new ArgumentException("������ ������ ���� ���������� ��������� �������������������");
            if(_operations.Contains(expression[0]) && expression[0]!='-' && expression[0]!='(')
                throw new ArgumentException("������ �� ����� ���������� � �������� ����� - ��� (");
            while (expression.Length > 1)
            {
                var index = expression.IndexOfAny(_operations.ToArray());
                if(index==-1) return;
                if(index-1>=0 && expression[index]=='(' && !_operations.Contains(expression[index-1]))
                    throw new Exception("����� ( ����� ����������� ������ ��������");
                if(index+1<expression.Length && expression[index]=='(' && expression[index+1]!='(' && expression[index+1]!='-' && (expression[index+1]<'0' || expression[index+1]>'9'))
                    throw new ArgumentException("��������� �� ����� ��������� ���� �������� ������");
                if(index+1<expression.Length && expression[index]!='(' && expression[index]!=')' && expression[index+1]!='(' && _operations.Contains(expression[index+1]))
                    throw new ArgumentException("��������� �� ����� ��������� ���� �������� ������");
                if(index+1<expression.Length && expression[index]==')' && !_operations.Contains(expression[index+1]))
                    throw new ArgumentException("��c�� ) ����� ���� ������ ��������");
                expression = index + 1 < expression.Length ? expression.Substring(index + 1) : "";
            }

        }

        public ExpressionFileReader()
        {
            _symbols= new HashSet<char>();
            for(var i=0;i<=9;i++)
                _symbols.Add((char)('0'+i));
            _symbols.Add('+');
            _symbols.Add('-');
            _symbols.Add('*');
            _symbols.Add('/');
            _symbols.Add('(');
            _symbols.Add(')');
            _symbols.Add('s');
            _symbols.Add('i');
            _symbols.Add('n');
            _symbols.Add(',');
            _symbols.Add('c');
            _symbols.Add('o');
            _operations = new HashSet<char>
            {
                '+',
                '-',
                '*',
                '/',
                '(',
                ')',
                'n',
                's'
            };
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
            ValidateExpression(expression);
            return expression;
        }
    }
}