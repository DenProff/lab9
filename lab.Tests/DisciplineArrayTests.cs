using lab9;
using Program = lab9.Program;

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
        public void DisciplineArrayFirstCalculateWeightedAverageCreditsTest()
        {
            // Arrange
            DisciplineArray disciplineArray = new DisciplineArray(0);
            double expectedAnswer = 0;

            // Act
            double actualAnswer = Program.CalculateWeightedAverageCredits(disciplineArray);

            // Assert
            Assert.AreEqual(expectedAnswer, actualAnswer);
        }

        [TestMethod]
        public void DisciplineArraySecondCalculateWeightedAverageCreditsTest()
        {
            // Arrange
            DisciplineArray disciplineArray = new DisciplineArray(6);
            disciplineArray[0] = new Discipline("1", 84, 182);
            disciplineArray[1] = new Discipline("2", 120, 184);
            disciplineArray[2] = new Discipline("3", 160, 144);
            disciplineArray[3] = new Discipline("4", 28, 86);
            disciplineArray[4] = new Discipline("5", 118, 262);
            disciplineArray[5] = new Discipline("1", 50, 102);
            double expectedAnswer = 7.55;

            // Act
            double actualAnswer = Program.CalculateWeightedAverageCredits(disciplineArray);

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
