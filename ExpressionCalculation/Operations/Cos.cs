using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionCalculation.Interfaces;
using ExpressionCalculation.Operands;

namespace ExpressionCalculation.Operations
{
    /// <summary>
    /// �����, �������������� ����� ���������� �������������� �������� �������� �����
    /// </summary>
    public class Cos : IOperation
    {
        /// <summary>
        /// ��������� �������� ����� ����
        /// </summary>
        public int Priority => 2;
        /// <summary>
        /// ���������� ��������� ������ 1
        /// </summary>
        public int OperandsCount => 1;
        /// <summary>
        /// ��������� ��������� � ��������, ����������� ����� 1 �������
        /// </summary>
        public IList<IOperand> Operands { get; }
        /// <summary>
        /// �����������, ���������������� ������ �������� �������� � ��������� ��������� ���������
        /// </summary>
        public Cos()
        {
            Operands = new List<IOperand>();
        }
        /// <summary>
        /// �����, ����������� ���������� �������� ��� 1 ��������, ������������ � ��������� Operands
        /// </summary>
        /// <returns>������ ���� IOperand, � ������� �������� ��������� ���������� �������� �����</returns>
        /// <exception cref="InvalidOperationException">����������, ���� �������� Operands �� �������� ��������� ��� �������� null ��� ������ ������� �������� null</exception>
        public IOperand Execute()
        {
            if (Operands == null || !Operands.Any()) throw new InvalidOperationException("������ ��������� �������� ��� ���������");
            if (Operands[0] == null) throw new InvalidOperationException("���� �� ��������� ���� ��� �� ����������");
            return new Operand((float)Math.Cos(Operands[0].Value));
        }
    }
}