using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBlendShape
    {
        public readonly string BlendShapeName;
        // FIXME
        public readonly List<MutableBlendShapeFrame> SingleFrames = new List<MutableBlendShapeFrame>();
        int _vertexCount;

        public MutableBlendShape(string blendShapeName)
        {
            BlendShapeName = blendShapeName;
        }

        public void Add(MutableBlendShape blendShape)
        {
            var newFrames = new List<MutableBlendShapeFrame>();
            if (blendShape.SingleFrames.FirstOrDefault() is { } inFrame)
            {
                if (SingleFrames.Count == 0)
                {
                    var newFrame = new MutableBlendShapeFrame(inFrame.FrameWeight);
                    newFrame.AddZeros(_vertexCount);
                    newFrame.Add(inFrame);
                    newFrames.Add(newFrame);
                }
                else
                {
                    foreach (var frame in SingleFrames)
                    {
                        var newFrame = new MutableBlendShapeFrame(frame.FrameWeight, frame.DeltaVertices, frame.DeltaNormals, frame.DeltaTangents);
                        newFrame.Add(inFrame);
                        newFrames.Add(newFrame);
                    }
                }
            }
            _vertexCount += blendShape._vertexCount;
            SingleFrames.Clear();
            SingleFrames.AddRange(newFrames);
        }

        public void AddZeros(int vertexCount)
        {
            _vertexCount += vertexCount;
            foreach (var frame in SingleFrames)
            {
                frame.AddZeros(vertexCount);
            }
        }
    }
    
    public class MutableBlendShapeFrame
    {
        public readonly float FrameWeight;
        public readonly List<Vector3> DeltaVertices = new List<Vector3>();
        public readonly List<Vector3> DeltaNormals = new List<Vector3>();
        public readonly List<Vector3> DeltaTangents = new List<Vector3>();

        public MutableBlendShapeFrame(float frameWeight)
        {
            FrameWeight = frameWeight;
        }

        public MutableBlendShapeFrame(float frameWeight, IEnumerable<Vector3> deltaVertices, IEnumerable<Vector3> deltaNormals, IEnumerable<Vector3> deltaTangents)
        {
            FrameWeight = frameWeight;
            DeltaVertices.AddRange(deltaVertices);
            DeltaNormals.AddRange(deltaNormals);
            DeltaTangents.AddRange(deltaTangents);
        }

        public void Add(MutableBlendShapeFrame frame)
        {
            DeltaVertices.AddRange(frame.DeltaVertices);
            DeltaNormals.AddRange(frame.DeltaNormals);
            DeltaTangents.AddRange(frame.DeltaTangents);
        }

        public void AddZeros(int zeroCount)
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