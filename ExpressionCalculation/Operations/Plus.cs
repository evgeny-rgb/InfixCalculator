using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionCalculation.Interfaces;
using ExpressionCalculation.Operands;

namespace ExpressionCalculation.Operations
{
    /// <summary>
    /// �����, �������������� ����� ���������� �������������� �������� ���������� ����� ���� �����
    /// </summary>
    public class Plus : IOperation
    {
        /// <summary>
        /// ��������� �������� ����� ����
        /// </summary>
        public int Priority => 2;
        /// <summary>
        /// ��������� ��������� � ��������, ����������� ����� 2 ��������
        /// </summary>
        public IList<IOperand> Operands { get; }
        /// <summary>
        /// ���������� ��������� ������ 2
        /// </summary>
        public int OperandsCount => 2;
        /// <summary>
        /// �����������, ���������������� ������ �������� ������ ����� ���� ����� � ��������� ��������� ���������
        /// </summary>
        public Plus()
        {
            Operands = new List<IOperand>();
        }
        /// <summary>
        /// �����, ����������� ���������� ����� ��� 2 ���������, ������������ � ��������� Operands
        /// </summary>
        /// <returns>������ ���� IOperand, � ������� �������� ��������� ���������� ����� ���� �����</returns>
        /// <exception cref="InvalidOperationException">����������, ���� �������� Operands �� �������� ��������� ��� �������� null ��� ������ ��� ������ ������� �������� null</exception>
        public IOperand Execute()
        {
            if(Operands==null || !Operands.Any()) throw new InvalidOperationException("������ ��������� �������� ��� ���������");
            if(Operands[0]==null || Operands[1]==null) throw new InvalidOperationException("���� �� ��������� ���� ��� �� ����������");
            return new Operand(Operands[0].Value + Operands[1].Value);
        }
    }
}