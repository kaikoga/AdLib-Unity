using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBlendShape
    {
        public readonly string BlendShapeName;
        public IEnumerable<MutableBlendShapeFrame> Frames
        {
            get => _frames;
            set
            {
                _frames.Clear();
                _frames.AddRange(value);
            }
        }

        readonly List<MutableBlendShapeFrame> _frames = new List<MutableBlendShapeFrame>();
        int _vertexCount;

        public MutableBlendShape(string blendShapeName)
        {
            BlendShapeName = blendShapeName;
        }

        public void Add(MutableBlendShape blendShape)
        {
            _vertexCount += blendShape._vertexCount;
            var frames = new List<MutableBlendShapeFrame>();
            frames.AddRange(Frames.Concat(blendShape.Frames)
                .Select(frame => frame.FrameWeight)
                .Distinct()
                .OrderBy(frameWeight => frameWeight)
                .Select(frameWeight =>
                {
                    var newFrame = new MutableBlendShapeFrame(frameWeight);
                    newFrame.Add(GetState(frameWeight));
                    newFrame.Add(blendShape.GetState(frameWeight));
                    return newFrame;
                }));
            _frames.Clear();
            _frames.AddRange(frames);
        }

        public void FillZeros(int vertexCount)
        {
            _vertexCount += vertexCount;
            foreach (var frame in Frames)
            {
                frame.FillZeros(vertexCount);
            }
        }

        public MutableBlendShapeState GetState(float blendShapeWeight)
        {
            var framesCount = _frames.Count;
            switch (framesCount)
            {
                case 0:
                    throw new InvalidOperationException();
                case 1:
                    return Lerp1(_frames[0]);
            }
            var firstFrame = _frames[0];
            // multiple frames: inside range
            if (Mathf.Approximately(firstFrame.FrameWeight, blendShapeWeight))
            {
                return new MutableBlendShapeState(firstFrame, 1f, null, 0f);
            }
            for (var i = 1; i < framesCount; i++)
            {
                var frame2 = _frames[i];
                if (Mathf.Approximately(frame2.FrameWeight, blendShapeWeight))
                {
                    return new MutableBlendShapeState(frame2, 1f, null, 0f);
                }
                if (frame2.FrameWeight > blendShapeWeight)
                {
                    return Lerp2(_frames[i - 1], frame2);
                }
            }
            // multiple frames: outside range
            if (firstFrame.FrameWeight < blendShapeWeight)
            {
                var frame1 = _frames[0];
                if (frame1.FrameWeight > 0)
                {
                    return Lerp1(frame1);
                }
                var frame2 = _frames[1];
                return Lerp2(frame1, frame2);
            }
            else
            {
                var frame2 = _frames[framesCount - 1];
                if (frame2.FrameWeight < 0)
                {
                    return Lerp1(frame2);
                }
                var frame1 = _frames[framesCount - 2];
                return Lerp2(frame1, frame2);
            }

            static float InverseLerpUnclamped(float a, float b, float value) => (value - a) / (b - a);

            MutableBlendShapeState Lerp1(MutableBlendShapeFrame frame)
            {
                return new MutableBlendShapeState(frame, blendShapeWeight / frame.FrameWeight, frame, 0f);
            }
            
            MutableBlendShapeState Lerp2(MutableBlendShapeFrame frame1, MutableBlendShapeFrame frame2)
            {
                var t = InverseLerpUnclamped(frame1.FrameWeight, frame2.FrameWeight, blendShapeWeight);
                return new MutableBlendShapeState(frame1, 1f - t, frame2, t);
            }
        }
    }

    public readonly struct MutableBlendShapeState
    {
        readonly MutableBlendShapeFrame _frame1;
        readonly float _weight1;
        readonly MutableBlendShapeFrame _frame2;
        readonly float _weight2;

        public MutableBlendShapeState(MutableBlendShapeFrame frame1, float weight1, MutableBlendShapeFrame frame2, float weight2)
        {
            _frame1 = frame1;
            _weight1 = weight1;
            _frame2 = frame2;
            _weight2 = weight2;
        }

        public IEnumerable<Vector3> DeltaVertices() => _frame2 == null ? _frame1.DeltaVertices : DeltaVerticesSlow();

        IEnumerable<Vector3> DeltaVerticesSlow()
        {
            for (var i = 0; i < _frame1.DeltaVertices.Count; i++) yield return DeltaVertex(i);
        }

        internal Vector3 DeltaVertex(int i) => _frame1.DeltaVertices[i] * _weight1 + _frame2.DeltaVertices[i] * _weight2;

        public IEnumerable<Vector3> DeltaNormals() => _frame2 == null ? _frame1.DeltaNormals : DeltaNormalsSlow();

        IEnumerable<Vector3> DeltaNormalsSlow()
        {
            for (var i = 0; i < _frame1.DeltaNormals.Count; i++) yield return DeltaNormal(i);
        }
        internal Vector3 DeltaNormal(int i) => _frame1.DeltaNormals[i] * _weight1 + _frame2.DeltaNormals[i] * _weight2;

        public IEnumerable<Vector3> DeltaTangents() => _frame2 == null ? _frame1.DeltaTangents : DeltaTangentsSlow();

        IEnumerable<Vector3> DeltaTangentsSlow()
        {
            for (var i = 0; i < _frame1.DeltaTangents.Count; i++) yield return DeltaTangent(i);
        }

        internal Vector3 DeltaTangent(int i) => _frame1.DeltaTangents[i] * _weight1 + _frame2.DeltaTangents[i] * _weight2;

        internal MutableBlendShapeFrame BakeToFrame(float frameWeight) =>
            new MutableBlendShapeFrame(
                frameWeight,
                DeltaVertices(),
                DeltaNormals(),
                DeltaTangents());
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

        public void Add(MutableBlendShapeState state)
        {
            DeltaVertices.AddRange(state.DeltaVertices());
            DeltaNormals.AddRange(state.DeltaNormals());
            DeltaTangents.AddRange(state.DeltaTangents());
        }

        public void FillZeros(int zeroCount)
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