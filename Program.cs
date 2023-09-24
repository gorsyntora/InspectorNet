﻿// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");


string param = "netstat -alpnt";

string result = RunCommandWithBash(param);
Console.WriteLine(result);

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

