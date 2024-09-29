using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBlendShape
    {
        public readonly string BlendShapeName;
        public readonly float FrameWeight;
        public readonly List<Vector3> DeltaVertices = new List<Vector3>();
        public readonly List<Vector3> DeltaNormals = new List<Vector3>();
        public readonly List<Vector3> DeltaTangents = new List<Vector3>();

        public MutableBlendShape(string blendShapeName, float frameWeight, int zeroCount = 0)
        {
            BlendShapeName = blendShapeName;
            FrameWeight = frameWeight;
            if (zeroCount > 0) Add(zeroCount);
        }

        public MutableBlendShape(string blendShapeName, float frameWeight, IEnumerable<Vector3> deltaVertices, IEnumerable<Vector3> deltaNormals, IEnumerable<Vector3> deltaTangents)
        {
            BlendShapeName = blendShapeName;
            FrameWeight = frameWeight;
            DeltaVertices.AddRange(deltaVertices);
            DeltaNormals.AddRange(deltaNormals);
            DeltaTangents.AddRange(deltaTangents);
        }

        public void Add(MutableBlendShape source)
        {
            DeltaVertices.AddRange(source.DeltaVertices);
            DeltaNormals.AddRange(source.DeltaNormals);
            DeltaTangents.AddRange(source.DeltaTangents);
        }

        public void Add(int zeroCount)
        {
            // ReSharper disable PossibleMultipleEnumeration
            var zeros = Enumerable.Repeat(Vector3.zero, zeroCount);
            DeltaVertices.AddRange(zeros);
            DeltaNormals.AddRange(zeros);
            DeltaTangents.AddRange(zeros);
            // ReSharper enable PossibleMultipleEnumeration
        }
    }
}