using System;
using System.Collections.Generic;
using System.Linq;
using InfixCalculator.Operands;
namespace InfixCalculator.Operations
{
    /// <summary>
    /// �����, �������������� ����� ���������� �������������� �������� �������� ������ �����, �� ���� ������ ����� � ��������������� ������
    /// </summary>
    public class UnaryMinus : IOperation
    {
        /// <summary>
        /// ��������� �������� ����� ������
        /// </summary>
        public int Priority => 4;
        /// <summary>
        /// ���������� ��������� ������ 1
        /// </summary>
        public int OperandsCount => 1;
        /// <summary>
        /// ��������� ��������� � ��������, ����������� ����� 1 �������
        /// </summary>
        public IList<IOperand> Operands { get; }
        /// <summary>
        /// �����������, ���������������� ������ �������� �������� ������ � ��������� ��������� ���������
        /// </summary>
        public UnaryMinus()
        {
            Operands = new List<IOperand>();
        }
        /// <summary>
        /// �����, ����������� ���������� �������� ������ ��� 1 ��������, ������������ � ��������� Operands
        /// </summary>
        /// <returns>������ ���� IOperand, � ������� �������� ��������� ���������� �������� ������ �����</returns>
        /// <exception cref="InvalidOperationException">����������, ���� �������� Operands �� �������� ��������� ��� �������� null ��� ������ ������� �������� null</exception>
        public IOperand Execute()
        {
            if (Operands == null || !Operands.Any()) throw new InvalidOperationException("������ ��������� �������� ��� ���������");
            if (Operands[0] == null) throw new InvalidOperationException("���� �� ��������� ���� ��� �� ����������");
            return new Operand(-Operands[0].Value);
        }
    }
}