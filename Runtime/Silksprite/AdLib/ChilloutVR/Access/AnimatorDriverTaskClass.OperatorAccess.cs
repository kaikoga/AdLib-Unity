using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class AnimatorDriverTaskClass
    {
        public class OperatorAccess : EnumAccessBase<OperatorAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriverTask+Operator");
            public static Type ActualType => CachedType.ActualType;

            public static readonly OperatorAccess Shared = new OperatorAccess();
            OperatorAccess() : base(CachedType) { }

            public enum EnumValues
            {
                Set,
                Addition,
                Subtraction,
                Multiplication,
                Division,
                Modulo,
                Power,
                Log,
                Equal,
                NotEqual,
                LessThen,
                LessEqual,
                MoreThen,
                MoreEqual,
                IPart,
                FPart,
                LogicalAnd,
                LogicalOr,
                BitwiseAnd,
                BitwiseOr,
                BitwiseXor,
                LeftShift,
                RightShift,
                RotateLeft,
                RotateRight,
                Conditional
            }
        }
    }
}
