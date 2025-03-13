using System;

class Program
{
    static void Main(string[] args)
    {
        Job firstJob = new()
        {
            _jobTitle = "Software Developer",
            _company = "IBM",
            _startYear = 2016,
            _endYear = 2020
        };

        Job secondJob = new()
        {
            _jobTitle = "Software Architech",
            _company = "Microsoft",
            _startYear = 2021,
            _endYear = 2024
        };

        Job thirdJob = new()
        {
            _jobTitle = "Software Engineer",
            _company = "Google",
            _startYear = 2021,
            _endYear = 2024
        };

        Resume myResume = new()
        {
            _name = "Benjamin Ruiz"
        };

        myResume._jobs.Add(firstJob);
        myResume._jobs.Add(secondJob);
        myResume._jobs.Add(thirdJob);

        myResume.Display();
    }
}