using lab9;

namespace DisciplineTestProject
{
    [TestClass]
    public class DisciplineTests
    {
        [TestMethod]
        public void DisciplineDefaultConstructorTest()
        {
            // Arrange
            Discipline expectedDiscipline = new Discipline();

            // Act
            Discipline actualDiscipline = new Discipline("Nameless", 0, 0);

            // Assert
            Assert.AreEqual(expectedDiscipline, actualDiscipline);

        }

        [TestMethod]
        public void DisciplineDeepCopyConstructorTest()
        {
            // Arrange
            Discipline actualDiscipline = new Discipline("123", 10, 295);

            // Act
            Discipline expectedDiscipline = new Discipline(actualDiscipline);

            // Assert
            Assert.AreEqual(expectedDiscipline, actualDiscipline);
        }

        [TestMethod]
        public void DisciplineEmptyNameTest()
        {
            // Arrange
            Discipline actualDiscipline = new Discipline("\t \t    \t ", 66, 23);

            // Act
            Discipline expectedDiscipline = new Discipline("Nameless", 66, 23);

            // Assert
            Assert.AreEqual(expectedDiscipline, actualDiscipline);
        }

        [TestMethod]
        public void DisciplineContactHoursFirstExceptionTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Discipline discipline = new Discipline("Test1", -1, 0);
            });
        }

        [TestMethod]
        public void DisciplineContactHoursSecondExceptionTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Discipline discipline = new Discipline("Test2", 3, 0);
            });
        }

        [TestMethod]
        public void DisciplineSelfHoursExceptionTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Discipline discipline = new Discipline("Test2", 0, -1);
            });
        }

        [TestMethod]
        public void DisciplineOverflowExceptionTest()
        {
            Assert.ThrowsException<OverflowException>(() =>
            {
                Discipline discipline1 = new Discipline("Test1", 2147483646, 9999);
                int credits = discipline1.CalculateCredits();
            });
        }


        [TestMethod]
        public void DisciplineGetAttributesTest()
        {
            // Arrange
            Discipline discipline = new Discipline("Math", 936, 9);
            string expectedString = "\nДисциплина: Math, часы аудиторной работы: 936, часы самостоятельной работы: 9";

            // Act
            string actualString = discipline.GetAttributes();

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void DisciplineCalculateCreditsTest()
        {
            // Arrange
            Discipline discipline = new Discipline("Test", 150, 52);
            int expectedCredits = 5;

            // Act
            int actualCredits = discipline.CalculateCredits();

            // Assert
            Assert.AreEqual(expectedCredits, actualCredits);
        }

        [TestMethod]
        public void DisciplineCalculateCreditsStaticTest()
        {
            // Arrange
            Discipline discipline = new Discipline("Test", 10000, 52);
            int expectedCredits = 264;

            // Act
            int actualCredits = Discipline.CalculateCredits(discipline);

            // Assert
            Assert.AreEqual(expectedCredits, actualCredits);
        }

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(6, 8, 57)]
        public void DisciplineNegationOperatorTest(int contactHours, int selfHours, int expectedFraction)
        {
            // Arrange
            Discipline discipline = new Discipline("Test", contactHours, selfHours);

            // Act
            double actualFraction = !discipline;

            // Assert
            Assert.AreEqual(expectedFraction, actualFraction, 0.15);
        }

        [TestMethod]
        [DataRow(6, 4, 8, 2)]
        [DataRow(50, 1, 50, 1)]
        public void DisciplineIncrementOperatorTest(int contactHours, int selfHours, int expectedContactHours, int expectedSelfHours)
        {
            // Arrange
            Discipline discipline = new Discipline("Test", contactHours, selfHours);
            Discipline expectedDiscipline = new Discipline("Test", expectedContactHours, expectedSelfHours);

            // Act
            Discipline actualDiscipline = ++discipline;

            // Assert
            Assert.AreEqual(expectedDiscipline, actualDiscipline);
        }

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(6, 17, 0.26)]
        public void DisciplineExplicitOperatorTest(int contactHours, int selfHours, double expectedFraction)
        {
            // Arrange
            Discipline discipline = new Discipline("Test", contactHours, selfHours);

            // Act
            double actualFraction = (double)discipline;

            // Assert
            Assert.AreEqual(expectedFraction, actualFraction, 0.0009);
        }

        [TestMethod]
        public void DisciplineImplicitOperatorTest()
        {
            // Arrange
            Discipline discipline = new Discipline("Test", 10, 3232323);
            int expectedClassroomLessons = 5;

            // Act
            int actualClassroomLessons = discipline;

            // Assert
            Assert.AreEqual(expectedClassroomLessons, actualClassroomLessons);
        }

        [TestMethod]
        [DataRow(14, 17, 10, 21)]
        [DataRow(6, 17, 68, 0)]
        public void DisciplineFirstComparisonOperatorTest(int firstContactHours, int firstSelfHours, int secondContactHours, int secondSelfHours)
        {
            // Arrange
            Discipline firstDiscipline = new Discipline("Test1", firstContactHours, firstSelfHours);
            Discipline secondDiscipline = new Discipline("Test2", secondContactHours, secondSelfHours);

            // Act
            bool actualAnswer = firstDiscipline <= secondDiscipline;

            // Assert
            Assert.IsTrue(actualAnswer);
        }

        [TestMethod]
        [DataRow(98, 347, 166, 279)]
        [DataRow(148, 65, 200, 11)]
        public void DisciplineSecondComparisonOperatorTest(int firstContactHours, int firstSelfHours, int secondContactHours, int secondSelfHours)
        {
            // Arrange
            Discipline firstDiscipline = new Discipline("Test1", firstContactHours, firstSelfHours);
            Discipline secondDiscipline = new Discipline("Test2", secondContactHours, secondSelfHours);

            // Act
            bool actualAnswer = firstDiscipline >= secondDiscipline;

            // Assert
            Assert.IsTrue(actualAnswer);
        }

        [TestMethod]
        public void DisciplineEqualsTest()
        {
            // Arrange
            Discipline firstDiscipline = new Discipline("Test", 164, 526);
            Discipline secondDiscipline = new Discipline("Test", 124, 53454);

            // Act
            bool actualAnswer = firstDiscipline.Equals(secondDiscipline);

            // Assert
            Assert.IsFalse(actualAnswer);
        }

        [TestMethod]
        [DoNotParallelize]
        public void DisciplineCountTest()
        {
            // Arrange
            Discipline.ClearCount();
            int expectedCount = 3;

            // Act
            Discipline firstDiscipline = new Discipline("Test", 2, 26546);
            Discipline secondDiscipline = new Discipline(firstDiscipline);
            Discipline thirdDiscipline = new Discipline();
            int actualCount = Discipline.GetCount;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
