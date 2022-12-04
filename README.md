# Task2

> **_All:_**  dotnet test  --logger "console;verbosity=detailed" -c Release

> **_Benchmark:_**  dotnet test  --logger "console;verbosity=detailed" -c Release --filter Category=Benchmark

> **_Without benchmark:_**  dotnet test --filter Category!=Benchmark