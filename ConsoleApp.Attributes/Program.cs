// See https://aka.ms/new-console-template for more information
using ConsoleApp.Attributes;
using System;
using System.Linq;

var attributes = typeof(SampleClass).Attributes;
Console.WriteLine(attributes);
var attributesMethod = typeof(SampleClass).GetMethod("SomeMethod").Attributes;
Console.WriteLine(attributesMethod);
var propertyAttributes = Attribute.GetCustomAttributes(typeof(SampleClass).GetProperty("Description"), true);
Console.WriteLine(string.Concat(propertyAttributes.Select(x => x.ToString())));
Console.ReadLine();
