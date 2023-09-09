using DigitalExams.Models;

namespace DigitalExams.ReMark
{

    public class ScoringAlgorithm
    {
        public class Choice
        {
            public bool IsCorrect { get; set; }
        }

        public class MultipleChoiceQuestion
        {
            public List<Choice> Choices { get; set; }
        }

        public class MultipleChoiceResponse
        {
            public List<int> SelectedIndices { get; set; }
        }

        public class MultipleChoiceResult
        {
            public double Score { get; set; }
        }

        public MultipleChoiceResult GradeMultipleChoiceQuestion(MultipleChoiceQuestion question, MultipleChoiceResponse response)
        {
            double maxScore = 100.0; // Maximum possible score for the question
            double perChoiceScore = maxScore / question.Choices.Count;

            double score = 0.0;

            foreach (int selectedIndex in response.SelectedIndices)
            {
                if (selectedIndex >= 0 && selectedIndex < question.Choices.Count)
                {
                    Choice selectedChoice = question.Choices[selectedIndex];

                    if (selectedChoice.IsCorrect)
                    {
                        score += perChoiceScore; // Increase the score for correct choices
                    }
                }
            }

            return new MultipleChoiceResult
            {
                Score = Math.Round(score, 2) // Round the score to two decimal places
            };
        }
    }
}
