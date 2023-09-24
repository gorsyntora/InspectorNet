// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");


string param = "netstat -alpnt";

string result = RunCommandWithBash(param);
var splittedString = result.Split(new string[] { "\\n" }, StringSplitOptions.None);
string[] lines = result.Split(
    new[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
);

string example = lines[2];

var str = example.Split(' ', StringSplitOptions.RemoveEmptyEntries);


Console.WriteLine(lines.Length + " "+ lines[0]);
Console.WriteLine(lines.Length + " " + lines[1]);
Console.WriteLine(lines.Length + " " + lines[2]);

Console.WriteLine("Line info:" + str.Length+" " + str[0]+ str[1]+ str[2]);

string RunCommandWithBash(string command)
{
    var psi = new ProcessStartInfo();
    psi.FileName = "/bin/bash";
    psi.Arguments = $"-c \"{command}\"";
    psi.RedirectStandardOutput = true;
    psi.UseShellExecute = false;
    psi.CreateNoWindow = true;

    using var process = Process.Start(psi);

    process.WaitForExit();

    var output = process.StandardOutput.ReadToEnd();

    return output;
}

