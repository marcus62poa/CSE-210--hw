using System;

class Program
{
    static void Main(string[] args)
    {
        Job trabalho1 = new Job();
        trabalho1._company = "Facebook";
        trabalho1._jobTitle = "Software Engenier";
        trabalho1._startYear = 2020;
        trabalho1._endYear = 2023;


        Job work2 = new Job();
        work2._company = "NVIDIA";
        work2._jobTitle = "Programer";
        work2._startYear = 2021;
        work2._endYear = 2025;

        Resume meuCurriculo = new Resume();
        meuCurriculo._nameFirst = "Marcus";
        meuCurriculo._jobs.Add(trabalho1);

        Resume megcurriculo = new Resume();
        megcurriculo._nameFirst = "Meg";
        megcurriculo._jobs.Add(work2);



        meuCurriculo.Display();
        megcurriculo.Display();




    }
}
