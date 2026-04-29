using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    public static partial class AnimatorDriverTaskClass
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [ReflectionAccess("ABI.CCK.Components.AnimatorDriverTask+Operator", "Assembly-CSharp")]
        public class OperatorAccess : EnumAccessBase<OperatorAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriverTask+Operator");
            static CachedType CachedType___ => CachedType;
            public static Type ActualType => CachedType.ActualType;
            public static bool IsImplemented => CachedType.IsImplemented;
            
            public static readonly OperatorAccess Shared = new OperatorAccess();
            OperatorAccess() : base(CachedType) { }
            
            public enum EnumValues
            {
                Set = 0,
                Addition = 1,
                Subtraction = 2,
                Multiplication = 3,
                Division = 4,
                Modulo = 5,
                Power = 6,
                Log = 7,
                Equal = 8,
                NotEqual = 9,
                LessThen = 10,
                LessEqual = 11,
                MoreThen = 12,
                MoreEqual = 13,
                IPart = 14,
                FPart = 15,
                LogicalAnd = 16,
                LogicalOr = 17,
                BitwiseAnd = 18,
                BitwiseOr = 19,
                BitwiseXor = 20,
                LeftShift = 21,
                RightShift = 22,
                RotateLeft = 23,
                RotateRight = 24,
                Conditional = 25,
            }
        }
    }
}
