BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19045</br>
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores</br>
.NET SDK=7.0.100-rc.1.22431.12<br>
[Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT</br>
DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT</br>


|                     Method |       Mean |     Error |    StdDev |     Median |  Gen 0 | Allocated |
|--------------------------- |-----------:|----------:|----------:|-----------:|-------:|----------:|
|                 DirectCall |  0.0006 ns | 0.0015 ns | 0.0014 ns |  0.0000 ns |      - |         - |
|          ReflectionClassic | 65.7594 ns | 0.5757 ns | 0.5386 ns | 65.7821 ns | 0.0014 |      24 B |
|       ReflectionCachedInfo | 46.1522 ns | 0.4068 ns | 0.3606 ns | 46.0547 ns | 0.0014 |      24 B |
| ReflectionCompiledDelegate |  0.8573 ns | 0.0118 ns | 0.0104 ns |  0.8541 ns |      - |         - |
|           EmittedIlVersion |  1.5068 ns | 0.0211 ns | 0.0176 ns |  1.5022 ns |      - |         - |
