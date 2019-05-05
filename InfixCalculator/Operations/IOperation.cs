using System.Collections.Generic;
using InfixCalculator.Interfaces;
using InfixCalculator.Operands;

namespace InfixCalculator.Operations
{
    /// <summary>
    /// ���������, �������������� ��������� �������-��������, �� ���� ������� ������������ ���������� ��� ����������
    /// </summary>
    public interface IOperation : IExpressionElement 
    {
        /// <summary>
        /// ��������� ��������
        /// </summary>
        int Priority { get; }
        /// <summary>
        /// ���������� ��������� � ��������
        /// </summary>
        int OperandsCount { get; }
        /// <summary>
        /// ��������� ��������� � ��������, ����������� ����� OperandCount ���������
        /// </summary>
        IList<IOperand> Operands { get; }
        /// <summary>
        /// �����, ����������� ���������� �������������� �������� ��� OperandsCount ��������, ������������ � ��������� Operands
        /// </summary>
        /// <returns>������ ���� IOperand, � ������� �������� ��������� ���������� ��������</returns>
        IOperand Execute();
    }
}
