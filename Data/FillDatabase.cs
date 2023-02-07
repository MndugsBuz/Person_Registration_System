namespace Person_Registration_System.Data
{
    public class FillDatabase
    {
/*
        var dbContext = new DepartamentContext();

        void CreateNewDepartament()
        {

            string dpName = Console.ReadLine();
            string dpCity = Console.ReadLine();
            string dpAddress = Console.ReadLine();

            var departament = new Departament { Name = dpName, City = dpCity, Address = dpAddress };
            departament.Lectures = new List<Lecture>();
            departament.Students = new List<Student>();

            string lectureName = Console.ReadLine();
            departament.Lectures.Add(new Lecture { Name = lectureName });

            string StName = Console.ReadLine();

            string StSurname = Console.ReadLine();
            string Stdate = Console.ReadLine();
            departament.Students.Add(new Student() { Name = StName, Surname = StSurname, DateOfBirth = new DateTime(2004, 01, 03) });

            dbContext.Departaments.Add(departament);
            dbContext.SaveChanges();

        }
        void CreateNewStudentToExistingDepartament()
        {

            var consoleresult = dbContext.Departaments;

            int dpId = int.Parse(Console.ReadLine());
            string StName = Console.ReadLine();
            string StSurname = Console.ReadLine();

            string Stdate = Console.ReadLine();

            dbContext.AddRange
                (
                  new Student() { Name = StName, Surname = StSurname, DateOfBirth = new DateTime(1999, 02, 16), DepartamentId = dpId }
                );
            dbContext.SaveChanges();
        }

        void CreateNewLecturesToNewDepartament()
        {
            Console.WriteLine("3.(1,2,3) Create a New department:");
            Console.WriteLine("3.1. Please enter departament name:");
            string dpName = Console.ReadLine();
            Console.WriteLine("3.2. Please enter departament address (City):");
            string dpCity = Console.ReadLine();
            Console.WriteLine("3.3. Please enter departament address (Street name and number):");
            string dpAddress = Console.ReadLine();

            var departament = new Departament { Name = dpName, City = dpCity, Address = dpAddress };

            Console.WriteLine("3.1. Please enter Lecture name:");
            string lectureName = Console.ReadLine();

            Console.WriteLine("3. Creating new Lectures...");
            dbContext.AddRange
                        (
                            new Lecture { Name = lectureName, Departaments = new List<Departament> { departament } }
                        );
            dbContext.SaveChanges();
        }

        void CreateNewLecturesToExistingDepartament()
        {
            Console.WriteLine("3.1.1 List of Departaments:");
            var consoleresult = dbContext.Departaments;
            Console.WriteLine("| Departament ID | Departament Name | Departament City | Departament Address");
            foreach (var item in consoleresult)
            {
                Console.Write(item.Id + " | ");
                Console.Write(item.Name + " | ");
                Console.Write(item.City + " |  ");
                Console.Write(item.Address + " |  ");
                Console.WriteLine();
            }

            Console.WriteLine("3.1.1 Please choose Departament ID:");
            int dpId = int.Parse(Console.ReadLine());

            var resultDpId = dbContext.Departaments.Include(x => x.Lectures).Where(d => d.Id == dpId).FirstOrDefault();
            Console.WriteLine("3.1.1 Please Enter New Lecture Name");
            string lectureName = Console.ReadLine();
            dbContext.AddRange
                       (
                            new Lecture { Name = lectureName, Departaments = new List<Departament> { resultDpId } }
                       );
            dbContext.SaveChanges();
        }

        void TransferStudentToAnotherDepartament()
        {

            Console.WriteLine("5. List of Departaments:");
            var consoleresult = dbContext.Departaments;
            Console.WriteLine("| No | Departament ID | Departament Name | Departament City | Departament Address");
            foreach (var item in consoleresult)
            {
                Console.Write(item.Id + " | ");
                Console.Write(item.Name + " | ");
                Console.Write(item.City + " |  ");
                Console.Write(item.Address + " |  ");
                Console.WriteLine();
            }

            Console.WriteLine("5. Students of department. Please choose Departament ID (2,3,4,8,9...):");
            int dpId = int.Parse(Console.ReadLine());

            var result = dbContext.Departaments.Include(d => d.Students).Where(x => x.Id == dpId).FirstOrDefault();

            var students = result.Students;
            Console.WriteLine("| Student ID | Student Name | Student Surname | Student Data of Birth |");

            foreach (var item in students)
            {
                Console.Write(item.Id + " ");
                Console.Write(item.Name + " ");
                Console.Write(item.Surname + " ");
                Console.WriteLine(item.DateOfBirth + " ");
                Console.WriteLine();
            }
            Console.WriteLine("********");

            Console.WriteLine("5. Move Student To another Departament. Please choose Student ID:");
            int stId = int.Parse(Console.ReadLine());

            var student = dbContext.Students.Where(n => n.DepartamentId == dpId).Where(na => na.Id == stId).Single();

            Console.Write(student.Id + " ");
            Console.Write(student.Name + " ");
            Console.Write(student.Surname + " | ");
            Console.Write(student.DateOfBirth + " | ");
            Console.WriteLine();

            Console.WriteLine("5. New studet department. Please choose departament ID (2,3,4,8,9...):");
            int newDpId = int.Parse(Console.ReadLine());

            dbContext.AddRange
               (
                 new Student() { Name = student.Name, Surname = student.Surname, DateOfBirth = new DateTime(1999, 02, 16), DepartamentId = newDpId }
               );

            var studentToRemove = dbContext.Students.Where(n => n.DepartamentId == dpId).Where(na => na.Id == stId).Single();
            if (studentToRemove != null)
            {
                dbContext.Students.Remove(studentToRemove);
            }

            dbContext.SaveChanges();

            Console.WriteLine("5. List Students department number:  " + newDpId);

            var resultNew = dbContext.Departaments.Include(d => d.Students).Where(x => x.Id == dpId).FirstOrDefault();

            var studentsNew = result.Students;
            Console.WriteLine("| Student ID | Student Name | Student Surname | Student Data of Birth |");

            foreach (var item in studentsNew)
            {
                Console.Write(item.Id + " ");
                Console.Write(item.Name + " ");
                Console.Write(item.Surname + " ");
                Console.WriteLine(item.DateOfBirth + " ");
                Console.WriteLine();
            }
            Console.WriteLine("********");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        void ConsoleStudentsOfDepartament()
        {
            Console.WriteLine("6. List of Departaments:");
            var consoleresult = dbContext.Departaments;
            Console.WriteLine("| No | Departament ID | Departament Name | Departament City | Departament Address");

            foreach (var item in consoleresult)
            {
                Console.Write(item.Id + " | ");
                Console.Write(item.Name + " | ");
                Console.Write(item.City + " |  ");
                Console.Write(item.Address + " |  ");
                Console.WriteLine();
            }

            Console.WriteLine("6. Students of department please choose (2,3,4,8,9...):");
            int dpId = int.Parse(Console.ReadLine());

            var result = dbContext.Departaments.Include(d => d.Students).Where(x => x.Id == dpId).FirstOrDefault();
            var students = result.Students;

            Console.WriteLine("| Student ID | Student Name | Student Surname | Student Data of Birth |");

            foreach (var item in students)
            {
                Console.Write(item.Name + " ");
                Console.Write(item.Surname + " ");
                Console.WriteLine(item.DateOfBirth + " ");
                Console.WriteLine();
            }
            Console.WriteLine("********");
        }



        void ConsoleLecturesOfDepartament()
        {
            Console.WriteLine("7. Lectures of department please choose (2,3,4,8,9):");
            int dp = int.Parse(Console.ReadLine());
            var consoleresult = dbContext.Departaments.Include(x => x.Lectures).Where(d => d.Id == dp).FirstOrDefault();
            var dplectures = consoleresult.Lectures;

            foreach (var item in dplectures)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("*************");
        }

        void ConsoleLecturesByStudent()
        {
            Console.WriteLine("List of students:");
            var consoleresult = dbContext.Students;
            Console.WriteLine("| Student ID | Student Name | Student Surname |");
            foreach (var item in consoleresult)
            {
                Console.Write(item.Id + " | ");
                Console.Write(item.Name + " | ");
                Console.Write(item.Surname + " |  ");
                Console.WriteLine();
            }

            Console.WriteLine("8. Lectures of student please choose Student ID:");
            int stId = int.Parse(Console.ReadLine());
            var studentDep = dbContext.Students.Where(x => x.Id == stId).Select(x => x.DepartamentId).FirstOrDefault();
            var result = dbContext.Departaments.Include(d => d.Lectures).Include(d => d.Students).Where(x => x.Id == studentDep).FirstOrDefault();

            var lectures = result.Lectures;

            foreach (var item in lectures)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("*******");

        }

        */
        // CreateNewStudentToExistingDepartament();
        //CreateNewLecturesToExistingDepartament();
        //TransferStudentToAnotherDepartament();
        //CreateNewLecturesToNewDepartament();
        //CreateNewDepartament();
        //ConsoleLecturesOfDepartament();
        //ConsoleLecturesByStudent();
        //ConsoleStudentsOfDepartament();


        

            /*


             var departament2 = new Departament { Name = "Matematikos ir gamtos mokslų fakultetas", City = "Kaunas", Address = "Studentų g. 50-218" };

               dbContext.AddRange
                   (
                        new Lecture { Name = "Dirbtinis intelektas", Departaments = new List<Departament> { departament1 }},
                        new Lecture { Name = "Informacinės sistemos", Departaments = new List<Departament> { departament1 }},
                        new Lecture { Name = "Informatika", Departaments = new List<Departament> { departament1 }},
                        new Lecture { Name = "Informatikos inžinerija", Departaments = new List<Departament> { departament1 }},
                        new Lecture { Name = "Informatikos inžinerija", Departaments = new List<Departament> { departament1 }},
                        new Lecture { Name = "Multimedijos technologijos", Departaments = new List<Departament> { departament1 }},
                        new Lecture { Name = "Programų sistemos", Departaments = new List<Departament> { departament1 }},

                        new Lecture { Name = "Diskrečioji matematika", Departaments = new List<Departament> { departament2 } },
                        new Lecture { Name = "Įvadas į matricų teoriją ir geometriją", Departaments = new List<Departament> { departament2 } },
                        new Lecture { Name = "Matematikos ir informatikos studijų įvadas", Departaments = new List<Departament> { departament2 } },
                        new Lecture { Name = "Matematinė analizė", Departaments = new List<Departament> { departament2 } },
                        new Lecture { Name = "Objektinio programavimo alternatyvos", Departaments = new List<Departament> { departament2 } },
                        new Lecture { Name = "Objektinio programavimo pagrindai", Departaments = new List<Departament> { departament2 } },
                        new Lecture { Name = "Objektinis programavimas", Departaments = new List<Departament> { departament2 } }
                      );

             */


            /*

            dbContext.Students.Add(new Student { Name = "Tadas", Surname = "Lietuvaitis", DateOfBirth = new DateTime(1999 - 12 - 21) });
            dbContext.Students.Add(new Student { Name = "Matas", Surname = "Petraitis", DateOfBirth = new DateTime(2000 - 01 - 22) });
            dbContext.Students.Add(new Student { Name = "Vidas", Surname = "Jonaitis", DateOfBirth = new DateTime(2001 - 02 - 23) });
            dbContext.Students.Add(new Student { Name = "Gedas", Surname = "Pavardenis", DateOfBirth = new DateTime(1998 - 03 - 24) });
            dbContext.Students.Add(new Student { Name = "Tomas", Surname = "Kalnietis", DateOfBirth = new DateTime(1997 - 04 - 25) });
            dbContext.Students.Add(new Student { Name = "Tajus", Surname = "Berankis", DateOfBirth = new DateTime(1996 - 05 - 26) });
            dbContext.Students.Add(new Student { Name = "Rojus", Surname = "Sudeikis", DateOfBirth = new DateTime(1997 - 06 - 27) });
            dbContext.Students.Add(new Student { Name = "Nojus", Surname = "Zymantas", DateOfBirth = new DateTime(1998 - 07 - 28) });
            dbContext.Students.Add(new Student { Name = "Titas", Surname = "Smith", DateOfBirth = new DateTime(1999 - 08 - 29) });
            dbContext.Students.Add(new Student { Name = "Jorė", Surname = "Lietuvaite", DateOfBirth = new DateTime(2000 - 09 - 30) });
            dbContext.Students.Add(new Student { Name = "Jurga", Surname = "Jonaityte", DateOfBirth = new DateTime(2001 - 10 - 29) });
            dbContext.Students.Add(new Student { Name = "Vaida", Surname = "Petraityte", DateOfBirth = new DateTime(2001 - 11 - 30) });
            dbContext.Students.Add(new Student { Name = "Daiva", Surname = "Murze", DateOfBirth = new DateTime(2002 - 12 - 31) });

            dbContext.SaveChanges();

            new Student { Name = "Tadas", Surname = "Lietuvaitis", DateOfBirth = new DateTime(1999 - 12 - 21) };
            new Student { Name = "Matas", Surname = "Petraitis", DateOfBirth = new DateTime(2000 - 01 - 22) };
            new Student { Name = "Vidas", Surname = "Jonaitis", DateOfBirth = new DateTime(2001 - 02 - 23) };
            new Student { Name = "Gedas", Surname = "Pavardenis", DateOfBirth = new DateTime(1998 - 03 - 24) };
            new Student { Name = "Tomas", Surname = "Kalnietis", DateOfBirth = new DateTime(1997 - 04 - 25) };
            new Student { Name = "Tajus", Surname = "Berankis", DateOfBirth = new DateTime(1996 - 05 - 26) };
            new Student { Name = "Rojus", Surname = "Sudeikis", DateOfBirth = new DateTime(1997 - 06 - 27) };
            new Student { Name = "Nojus", Surname = "Zymantas", DateOfBirth = new DateTime(1998 - 07 - 28) };
            new Student { Name = "Titas", Surname = "Smith", DateOfBirth = new DateTime(1999 - 08 - 29) };
            new Student { Name = "Jorė", Surname = "Lietuvaite", DateOfBirth = new DateTime(2000 - 09 - 30) };
            new Student { Name = "Jurga", Surname = "Jonaityte", DateOfBirth = new DateTime(2001 - 10 - 29) };
            new Student { Name = "Vaida", Surname = "Petraityte", DateOfBirth = new DateTime(2001 - 11 - 30) };
            new Student { Name = "Daiva", Surname = "Murze", DateOfBirth = new DateTime(2002 - 12 - 31) };

            */



            /*

            var departament4 = new Departament { Name = "Mechanikos inžinerijos ir dizaino fakultetas", City = "Kaunas", Address = "Studentų g. 56-142" };
            var departament3 = new Departament { Name = "CHEMINĖS TECHNOLOGIJOS FAKULTETAS", City = "Kaunas", Address = "Radvilėnų pl. 19 C-236" };

            foreach (var item in studentslist1)
            {
                Console.Write(item.Name);
                Console.Write(item.Surname);
                Console.Write(item.DateOfBirth);
                Console.WriteLine();
            }


            dbContext.AddRange
            (
            new Lecture { Name = "Įvadas į cheminę technologiją ir inžineriją", Departaments = new List<Departament> { departament3 } }
            );

            dbContext.SaveChanges();

            }
            */

            /*

            var departament4 = new Departament { Name = "Mechanikos inžinerijos ir dizaino fakultetas", City = "Kaunas", Address = "Studentų g. 56-142" };
            var departament3 = new Departament { Name = "CHEMINĖS TECHNOLOGIJOS FAKULTETAS", City = "Kaunas", Address = "Radvilėnų pl. 19 C-236" };


             dbContext.AddRange
            (
            new Student { Name = "Daiva", Surname = "Murze", DateOfBirth = new DateTime(2002, 12, 31), Departaments = new List<Departament> { departament4 } },
            new Student() { Name = "Vidas", Surname = "Jonaitis", DateOfBirth = new DateTime(2001, 02, 23), Departaments = new List<Departament> { departament4 } }, 
            new Student() { Name = "Gedas", Surname = "Pavardenis", DateOfBirth = new DateTime(1998, 03, 24), Departaments = new List<Departament> { departament4 } },
            new Student() { Name = "Tomas", Surname = "Kalnietis", DateOfBirth = new DateTime(1997, 04, 25), Departaments = new List<Departament> { departament4 } },
            new Student() { Name = "Tajus", Surname = "Berankis", DateOfBirth = new DateTime(1996, 05, 26), Departaments = new List<Departament> { departament4 } },
            new Student() { Name = "Rojus", Surname = "Sudeikis", DateOfBirth = new DateTime(1997, 06, 27), Departaments = new List<Departament> { departament3 } },
            new Student() { Name = "Nojus", Surname = "Zymantas", DateOfBirth = new DateTime(1998, 07, 28), Departaments = new List<Departament> { departament3 } },
            new Student() { Name = "Titas", Surname = "Smith", DateOfBirth = new DateTime(1999, 08, 29), Departaments = new List<Departament> { departament3 } },
            new Student() { Name = "Jorė", Surname = "Lietuvaite", DateOfBirth = new DateTime(2000, 09, 30), Departaments = new List<Departament> { departament3 } },
            new Student() { Name = "Jurga", Surname = "Jonaityte", DateOfBirth = new DateTime(2001, 10, 29), Departaments = new List<Departament> { departament3 } },
            new Student() { Name = "Vaida", Surname = "Petraityte", DateOfBirth = new DateTime(2001, 11, 30), Departaments = new List<Departament> { departament3 } },
            new Student() { Name = "Daiva", Surname = "Murze", DateOfBirth = new DateTime(2002, 12, 31), Departaments = new List<Departament> { departament3 } }

            );

            dbContext.SaveChanges(); 



                    */

            /*
            var studentslist1 = new List<Student>
    {

    new Student( "Vidas", "Jonaitis",    new DateTime(2001, 02, 23) ),
    new Student( "Gedas", "Pavardenis",  new DateTime(1998, 03, 24) ),
    new Student( "Tomas", "Kalnietis",   new DateTime(1997, 04, 25) ),
    new Student( "Tajus", "Berankis",    new DateTime(1996, 05, 26) ),
    new Student( "Rojus", "Sudeikis",    new DateTime(1997, 06, 27) ),
    new Student( "Nojus", "Zymantas",    new DateTime(1998, 07, 28) ),
    new Student( "Titas", "Smith",       new DateTime(1999, 08, 29) ),
    new Student( "Jorė",  "Lietuvaite",  new DateTime(2000, 09, 30) ),
    new Student( "Jurga", "Jonaityte",   new DateTime(2001, 10, 29) ),
    new Student( "Vaida", "Petraityte",  new DateTime(2001, 11, 30) ),
    new Student( "Daiva", "Murze",       new DateTime(2002, 12, 31) ),

    };

            departament1.Students.AddRange(studentslist1);
    dbContext.Departaments.AddRange(departament1);
    dbContext.SaveChanges();

            */

            /*

            dbContext.AddRange
       (
        new Student() { Name = "Tadas", Surname = "Lietuvaitis", DateOfBirth = new DateTime(2000, 01, 15), DepartamentId = 3 },
        new Student() { Name = "Matas", Surname = "Petronis", DateOfBirth = new DateTime(1999, 02, 25), DepartamentId = 2 },
        new Student() { Name = "Vidas", Surname = "Jonaitis", DateOfBirth = new DateTime(2001, 02, 23), DepartamentId = 2 },
        new Student() { Name = "Gedas", Surname = "Kalnietis", DateOfBirth = new DateTime(1998, 03, 24), DepartamentId = 2 },
        new Student() { Name = "Tomas", Surname = "Berankis", DateOfBirth = new DateTime(1997, 04, 25), DepartamentId = 2 },
        new Student() { Name = "Tajus", Surname = "Sudeikis", DateOfBirth = new DateTime(1996, 05, 26), DepartamentId = 2 },
        new Student() { Name = "Rojus", Surname = "Zymantas", DateOfBirth = new DateTime(1997, 06, 27), DepartamentId = 2 },
        new Student() { Name = "Nojus", Surname = "Smith", DateOfBirth = new DateTime(1998, 07, 28), DepartamentId = 2 },
        new Student() { Name = "Titas", Surname = "Lietuvaitis", DateOfBirth = new DateTime(1999, 08, 29), DepartamentId = 2 },
        new Student() { Name = "Jorė",  Surname = "Jonaityte", DateOfBirth = new DateTime(2000, 09, 30), DepartamentId = 2 },
        new Student() { Name = "Jurga", Surname = "Jonaityte", DateOfBirth = new DateTime(2001, 10, 29), DepartamentId = 4 } ,
        new Student() { Name = "Vaida", Surname = "Petraityte", DateOfBirth = new DateTime(2001, 11, 30), DepartamentId = 4 } ,
        new Student() { Name = "Daiva", Surname = "Murze", DateOfBirth = new DateTime(2002, 12, 31), DepartamentId = 4 }
       );

    dbContext.SaveChanges();
            */

            /*
    var departament4 = new Departament { Name = "Mechanikos inžinerijos ir dizaino fakultetas", City = "Kaunas", Address = "Studentų g. 56-142" };
    var departament3 = new Departament { Name = "CHEMINĖS TECHNOLOGIJOS FAKULTETAS", City = "Kaunas", Address = "Radvilėnų pl. 19 C-236" };
    */

            /*
            dbContext.AddRange
               (
                new Student() { Name = "Ridas", Surname = "Rusaitis", DateOfBirth = new DateTime(1999, 02, 16), DepartamentId = 4 },
                new Student() { Name = "Ramas", Surname = "Matronis", DateOfBirth = new DateTime(2001, 03, 26), DepartamentId = 3 },
                new Student() { Name = "Gvidas", Surname = "Momaitis", DateOfBirth = new DateTime(2002, 03, 01), DepartamentId = 3 },
                new Student() { Name = "Getz", Surname = "Smith", DateOfBirth = new DateTime(1999, 02, 02), DepartamentId = 3 },
                new Student() { Name = "Tomek", Surname = "Rence", DateOfBirth = new DateTime(1997, 04, 25), DepartamentId = 3 },
                new Student() { Name = "Taj", Surname = "Suide", DateOfBirth = new DateTime(1996, 05, 26), DepartamentId = 3 },
                new Student() { Name = "Roj", Surname = "Mqueen", DateOfBirth = new DateTime(1997, 06, 27), DepartamentId = 3 },
                new Student() { Name = "Kajus", Surname = "Smith", DateOfBirth = new DateTime(1998, 07, 28), DepartamentId = 3 },
                new Student() { Name = "Tit", Surname = "Belarus", DateOfBirth = new DateTime(1999, 08, 29), DepartamentId = 3 },
                new Student() { Name = "Jorka",  Surname = "Morka", DateOfBirth = new DateTime(2000, 09, 30), DepartamentId = 3 },
                new Student() { Name = "Jura", Surname = "Dove", DateOfBirth = new DateTime(2001, 10, 29), DepartamentId = 2 } ,
                new Student() { Name = "Aida", Surname = "Raina", DateOfBirth = new DateTime(2001, 11, 30), DepartamentId = 2 } ,
                new Student() { Name = "Vaiva", Surname = "Prause", DateOfBirth = new DateTime(2002, 12, 31), DepartamentId = 2 }
                );

            dbContext.SaveChanges();
            */

            /*
            var studentslist1 = new List<Student>
             {
                new Student( "Vidas", "Jonaitis",    new DateTime(2000, 02, 23) ),
                new Student( "Gedas", "Pavardenis",  new DateTime(1999, 03, 24) ),
                new Student( "Tomas", "Kalnietis",   new DateTime(1998, 04, 25) ),
                new Student( "Tajus", "Berankis",    new DateTime(1997, 05, 26) ),
                new Student( "Rojus", "Sudeikis",    new DateTime(1998, 06, 27) ),
                new Student( "Nojus", "Zymantas",    new DateTime(1999, 07, 28) ),
                new Student( "Titas", "Smith",       new DateTime(2000, 08, 29) ),
                new Student( "Jorė",  "Lietuvaite",  new DateTime(2001, 09, 30) ),
                new Student( "Jurga", "Jonaityte",   new DateTime(2002, 10, 29) ),
                new Student( "Vaida", "Petraityte",  new DateTime(2003, 11, 30) ),
                new Student( "Daiva", "Murze",       new DateTime(2005, 12, 31) ),
             };
            */

            //dbContext.Students.Add(new Student("Vidas", "Jonaitis", new DateTime(2000, 02, 23)));
            //departament1.Students.AddRange(studentslist1);
            //dbContext.Departaments.AddRange(departament1);
            //dbContext.SaveChanges();


    }
}
