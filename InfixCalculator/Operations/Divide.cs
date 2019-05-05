using System;
using System.Collections.Generic;
using System.Linq;
using InfixCalculator.Operands;

namespace InfixCalculator.Operations
{
    /// <summary>
    /// �����, �������������� ����� ���������� �������������� �������� ���������� �������� ���� �����
    /// </summary>
    public class Divide : IOperation
    {
        /// <summary>
        /// ��������� �������� ����� ���
        /// </summary>
        public int Priority => 3;
        /// <summary>
        /// ���������� ��������� ������ 2
        /// </summary>
        public int OperandsCount => 2;
        /// <summary>
        /// ��������� ��������� � ��������, ����������� ����� 2 ��������
        /// </summary>
        public IList<IOperand> Operands { get; }
        /// <summary>
        /// �����������, ���������������� ������ �������� ������ �������� ���� ����� � ��������� ��������� ���������
        /// </summary>
        public Divide()
        {
            Operands= new List<IOperand>();
        }
        /// <summary>
        /// �����, ����������� ���������� ��������  ��� 2 ���������, ������������ � ��������� Operands
        /// </summary>
        /// <returns>������ ���� IOperand, � ������� �������� ��������� ���������� �������� �����</returns>
        /// <exception cref="InvalidOperationException">����������, ���� �������� Operands �� �������� ��������� ��� �������� null ��� ������ ��� ������ ������� �������� null</exception>
        /// <exception cref="DivideByZeroException">���������� ���� ������ ������� ������ �������� 0</exception>
        public IOperand Execute()
        {
            if (Operands == null || !Operands.Any()) throw new InvalidOperationException("������ ��������� �������� ��� ���������");
            if (Operands[0] == null || Operands[1] == null) throw new InvalidOperationException("���� �� ��������� ���� ��� �� ����������");
            if(Operands[0].Value==0) throw new DivideByZeroException("������ ������� �� ����� ���� ����");
            return new Operand(Operands[1].Value / Operands[0].Value);
        }
    }
}