using projekt;
using System.Text.Json.Nodes;
using System.Text.Json;



Init.Read();

Init.students[36].DisplayInfo();

Console.WriteLine("Department Name Check:");
Console.WriteLine(Init.departments[2].DepartmentNotation);
Console.WriteLine("");
Console.WriteLine("Course Name check");
Console.WriteLine(Init.courses[2].Name);
Console.WriteLine("");
Console.WriteLine("Hooman info display check");
Console.WriteLine(Init.courses[2].Lecturer.DisplayInfo());
Console.WriteLine("");
Console.WriteLine("Class ID check");
Console.WriteLine(Init.departments[2].Classes[1].ID);



JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
string json = JsonSerializer.Serialize(Init.departments, options);

//Console.WriteLine(json);
//File.WriteAllText("M:\\Projekt\\Proojekt\\tempdb_struct.json", json);