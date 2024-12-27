var ts = TypeScript.Definitions()
    .For<Product>();
File.WriteAllText("output.ts", ts.Generate());
