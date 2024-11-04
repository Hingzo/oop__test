using projekt;
using System.Text.Json.Nodes;
using System.Text.Json;



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


JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented=true};
string json = JsonSerializer.Serialize(Init.departments, options);

//Console.WriteLine(json);
File.WriteAllText("M:\\Projekt\\Proojekt\\tempdb_struct.json", json);