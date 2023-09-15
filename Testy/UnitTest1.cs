using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SysZarzGr;

namespace Testy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CzyEquatableDzialaPoprawnie_ZwracaTrue()
        {
            // Arrange
            Student student1 = new Student();
            Student student2 = new Student();
            string pesel1 = "01234567891";
            student1.Pesel = pesel1;
            string pesel2 = "01234567891";
            student2.Pesel = pesel2;

            // Act
            bool result = student1.Equals(student2);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
