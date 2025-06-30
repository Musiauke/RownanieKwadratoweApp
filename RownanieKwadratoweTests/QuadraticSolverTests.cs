using System;
using Xunit;
using RownanieKwadratoweApp;

namespace RownanieKwadratoweTests
{
    public class QuadraticSolverTests
    {
        [Theory]
        [InlineData(1, 2, 5)]
        [InlineData(1, 0, 1)]
        public void BrakPierwiastkow(double a, double b, double c)
        {
            var wynik = QuadraticSolver.ObliczPierwiastki(a, b, c);
            Assert.Equal(0, wynik.liczbaPierwiastkow);
            Assert.Null(wynik.x1); 
            Assert.Null(wynik.x2); 
        }


        [Theory]
        [InlineData(1, 2, 1, -1)]
        [InlineData(4, 4, 1, -0.5)]
        public void JedenPierwiastek(double a, double b, double c, double oczekiwaneX)
        {
            var wynik = QuadraticSolver.ObliczPierwiastki(a, b, c);
            Assert.Equal(1, wynik.liczbaPierwiastkow);
            Assert.True(Math.Abs(wynik.x1.GetValueOrDefault() - oczekiwaneX) < 0.00001);
            Assert.Null(wynik.x2);
        }

        [Theory]
        [InlineData(1, -3, 2, 1, 2)]
        [InlineData(1, 0, -4, -2, 2)]
        public void DwaPierwiastki(double a, double b, double c, double oczekiwaneX1, double oczekiwaneX2)
        {
            var wynik = QuadraticSolver.ObliczPierwiastki(a, b, c);
            Assert.Equal(2, wynik.liczbaPierwiastkow);
            Assert.NotNull(wynik.x1);
            Assert.NotNull(wynik.x2);
            Assert.Contains(wynik.x1!.Value, new[] { oczekiwaneX1, oczekiwaneX2 });
            Assert.Contains(wynik.x2!.Value, new[] { oczekiwaneX1, oczekiwaneX2 });
        }

        [Fact]
        public void WyjatekDlaZera()
        {
            Assert.Throws<ArgumentException>(() => QuadraticSolver.ObliczPierwiastki(0, 2, 3));
        }
    }
}