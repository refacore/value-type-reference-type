using ValueTypeReferenceType;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Value Type - Reference Type!");

var valueTypeExplaination = new ValueTypeExplaination();

valueTypeExplaination.Explain();

valueTypeExplaination.ExplainRef();

valueTypeExplaination.ExplainOut();

var referenceTypeExplaination = new ReferenceTypeExplaination();

referenceTypeExplaination.Explain();

referenceTypeExplaination.ExplainRef();

referenceTypeExplaination.ExplainOut();
