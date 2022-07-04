namespace WebApp2._3.Models
{
    public class QuizViewModel
    {
        string[] operations = { "+", "-", "*" };

        private int X;
        private int Y;
        private string operation;
        private int rightAnswer { get; set; }
        public string question;
        public List<string> Results { get; set; } = new List<string>();

        public int answersCount = 0;
        public int rightAnswersCount = 0;


        public void SetRandomValues()
        {
            Random rand = new Random();
            X = rand.Next(0, 15);
            Y = rand.Next(0, 15);
            operation = operations[rand.Next(0, 3)];
            switch (operation)
            {
                case "+":
                    rightAnswer = X + Y; break;
                case "-":
                    rightAnswer = X - Y; break;
                case "*":
                    rightAnswer = X * Y; break;
            };
            question = $"{X} {operation} {Y} = ";
        }

        public void UppdateResults(int answer)
        {
            answersCount++;
            if (answer == rightAnswer)
            {
                rightAnswersCount++;
            }
            Results.Add($"{question} {answer}");
        }
    }
}
