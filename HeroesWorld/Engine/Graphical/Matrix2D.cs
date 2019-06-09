using System;

namespace HeroesWorld.Engine.Graphical
{
    public class Matrix2D
    {
        private double[] _data = new double[9];

        public double this[int row, int col]
        {
            get => GetCell(row, col);
            set => SetCell(row, col, value);
        }

        public override string ToString()
        {
            return string.Join(",", _data);
        }

        public static Matrix2D MakeIdentity()
        {
            var result = new Matrix2D();
            for (var i = 0; i < 3; i++)
                result.SetCell(i, i, 1.0);
            return result;
        }

        private void SetCell(int row, int col, double val)
        {
            _data[row * 3 + col] = val;
        }

        private double GetCell(int row, int col)
        {
            return _data[row * 3 + col];
        }

        private Matrix2D Clone()
        {
            var data = new double[9];
            Array.Copy(_data, data, 9);
            return new Matrix2D
            {
                _data = data
            };
        }

        public void Multiply(Matrix2D other)
        {
            var a = Clone();

            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
            {
                var sum = 0.0;
                for (var k = 0; k < 3; k++)
                    sum += a[i, k] * other[k, j];
                this[i, j] = sum;
            }
        }

        public Matrix2D ScaleMatrix(double sx, double sy)
        {
            var scale = MakeIdentity();
            scale[0, 0] = sx;
            scale[1, 1] = sy;
            Multiply(scale);
            return this;
        }

        public Matrix2D TranslateMatrix(double tx, double ty)
        {
            var scale = MakeIdentity();
            scale[2, 0] = tx;
            scale[2, 1] = ty;
            Multiply(scale);
            return this;
        }

        public (int x, int y) TransformCoordinate((int x, int y) coord)
        {
            var resX = coord.x * this[0, 0] + coord.y * this[1, 0] + this[2, 0];
            var resY = coord.y * this[0, 1] + coord.y * this[1, 1] + this[2, 1];
            return ((int) resX, (int) resY);
        }
    }
}