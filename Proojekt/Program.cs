using projekt;



Init.Read();

Init.students[36].DisplayInfo();

Console.WriteLine("");
Console.WriteLine(Init.departments[2].DepartmentName);
Console.WriteLine("");
Console.WriteLine(Init.departments[0].CourseOffered[1].CourseName);
Console.WriteLine("");
Console.WriteLine(Init.departments[2].MajorClasses[1].ID);
Console.WriteLine("");
Init.departments[1].MajorClasses[2].students[0].DisplayInfo();