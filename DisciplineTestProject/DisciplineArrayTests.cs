using lab9;
using Microsoft.VisualStudio.TestPlatform.TestHost;
namespace DisciplineTestProject
{
    [TestClass]
    public class DisciplineArrayTests
    {
        [TestMethod]
        public void DisciplineArrayDefaultConstructorTest()
        {
            // Arrange
            DisciplineArray expectedDisciplineArray = new DisciplineArray();

            // Act
            DisciplineArray actualDisciplineArray = new DisciplineArray(0);

            // Assert
            Assert.AreEqual(expectedDisciplineArray, actualDisciplineArray);
        }

        [TestMethod]
        public void DisciplineArrayDeepCopyConstructorTest()
        {
            // Arrange
            DisciplineArray expectedDisciplineArray = new DisciplineArray(5);

            // Act
            DisciplineArray actualDisciplineArray = new DisciplineArray(expectedDisciplineArray);

            // Assert
            Assert.AreEqual(expectedDisciplineArray, actualDisciplineArray);
        }

        [TestMethod]
        public void DisciplineArrayGetElementsTest()
        {
            // Arrange
            DisciplineArray disciplineArray = new DisciplineArray(3);
            string expectedResult = $"\nДисциплина: {disciplineArray[0].Name}, часы аудиторной работы: {disciplineArray[0].ContactHours}, часы самостоятельной работы: {disciplineArray[0].SelfHours}"
                                    + $"\nДисциплина: {disciplineArray[1].Name}, часы аудиторной работы: {disciplineArray[1].ContactHours}, часы самостоятельной работы: {disciplineArray[1].SelfHours}"
                                    + $"\nДисциплина: {disciplineArray[2].Name}, часы аудиторной работы: {disciplineArray[2].ContactHours}, часы самостоятельной работы: {disciplineArray[2].SelfHours}";

            // Act
            string actualResult = disciplineArray.GetElements();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DisciplineArrayIndexerSetterTest()
        {
            // Arrange
            DisciplineArray disciplineArray = new DisciplineArray(4);
            Discipline discipline = new Discipline("Test", 12, 13);

            // Act
            disciplineArray[2] = discipline;

            // Assert
            Assert.AreEqual(discipline, disciplineArray[2]);
        }

        [TestMethod]
        public void DisciplineArrayIndexerGetterFirstExceptionTest()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                DisciplineArray disciplineArray = new DisciplineArray(4);
                string name = disciplineArray[-10].Name;
            });
        }

        [TestMethod]
        public void DisciplineArrayIndexerGetterSecondExceptionTest()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                DisciplineArray disciplineArray = new DisciplineArray(4);
                string name = disciplineArray[53].Name;
            });
        }

        [TestMethod]
        public void DisciplineArrayIndexerSetterFirstExceptionTest()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                DisciplineArray disciplineArray = new DisciplineArray(4);
                disciplineArray[-10] = new Discipline("Test", 12, 10);
            });
        }

        [TestMethod]
        public void DisciplineArrayIndexerSetterSecondExceptionTest()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() =>
            {
                DisciplineArray disciplineArray = new DisciplineArray(4);
                disciplineArray[19] = new Discipline("Test", 12, 10);
            });
        }

        [TestMethod]
        public void DisciplineArrayFirstEqualsTest()
        {
            // Arrange
            DisciplineArray disciplineArray = new DisciplineArray(4);
            Discipline discipline = new Discipline("Test", 12, 13);
            bool expectedAnswer = false;

            // Act
            bool actualAnswer = disciplineArray.Equals(discipline);

            // Assert
            Assert.AreEqual(expectedAnswer, actualAnswer);
        }

        [TestMethod]
        public void DisciplineArraySecondEqualsTest()
        {
            // Arrange
            DisciplineArray firstDisciplineArray = new DisciplineArray(4);
            DisciplineArray secondDisciplineArray = new DisciplineArray(5);
            bool expectedAnswer = false;

            // Act
            bool actualAnswer = firstDisciplineArray.Equals(secondDisciplineArray);

            // Assert
            Assert.AreEqual(expectedAnswer, actualAnswer);
        }

        [TestMethod]
        public void DisciplineArrayThirdEqualsTest()
        {
            // Arrange
            DisciplineArray firstDisciplineArray = new DisciplineArray(4);
            DisciplineArray secondDisciplineArray = new DisciplineArray(firstDisciplineArray);
            secondDisciplineArray[0] = new Discipline();
            bool expectedAnswer = false;

            // Act
            bool actualAnswer = firstDisciplineArray.Equals(secondDisciplineArray);

            // Assert
            Assert.AreEqual(expectedAnswer, actualAnswer);
        }

        [TestMethod]
        [DoNotParallelize]
        public void DisciplineArrayCountTest()
        {
            // Arrange
            DisciplineArray.ClearCount();
            int expectedCount = 3;

            // Act
            DisciplineArray firstDisciplineArray = new DisciplineArray();
            DisciplineArray secondDisciplineArray = new DisciplineArray(5);
            DisciplineArray thirdDisciplineArray = new DisciplineArray(secondDisciplineArray);
            int actualCount = DisciplineArray.GetCount;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
